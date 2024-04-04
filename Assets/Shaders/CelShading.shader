Shader "Custom/CelShading"
{
    Properties {
        _MainTex ("albedo", 2D) = "white" {}

        // main colours
        _Colour ("Tint Color", Color) = (0.5,0.5,0.5,1)
        _Antialiasing("Band Smoothing", Float) = 5.0
        _SpecularColor("Specular Color", Color) = (0.2941177,0.2862745,0.2862745,1.0)
        _Glossiness("Glossiness", Float) = 20
        _Ambient("Ambient Color", Color) = (0.4811321,0.5176471,0.8313726,1.0)
        // rim lighting properties
        _RimColor("Rim Color", Color) = (1,1,1,1)
        _RimAmount("Rim Amount", Range(0, 1)) = 0.716
        _RimThreshold("Rim Threshold", Range(0, 1)) = 0.1

        // outline properties
        // stencil ID to make sure  outlines dont vanish when overlapped
        _ID("Stencil ID", Int) = 1
        _OutlineSize("Outline Size", Float) = 0.01
        _OutlineColor("Outline Color", Color) = (0, 0, 0, 1)
    }

    SubShader {
        Tags { 
            "RenderType"="Opaque" 
            "LightMode"  = "ForwardBase"
            "PassFlags"  = "OnlyDirectional"
        }

        Pass {

            // setting stencil rendering and behaviour
            Stencil {
                Ref [_ID]
                Comp always
                Pass replace
                ZFail keep
            }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            // for shadows:
            #pragma multi_compile_fwdbase
            #include "AutoLight.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Colour;
            float _Antialiasing;
            float _Glossiness;
            float4 _SpecularColor;
            float4 _Ambient;
            float4 _RimColor;
            float _RimAmount;
            float _RimThreshold;

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 worldNormal : NORMAL;
                float3 viewDir : TEXCOORD1;
                unityShadowCoord4 _ShadowCoord : TEXCOORD2;
            };

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.viewDir = WorldSpaceViewDir(v.vertex);

                // transfering of shadow texture coordinates 
                o._ShadowCoord = ComputeScreenPos(UnityObjectToClipPos( v.vertex));
                return o;
            }


            float4 frag (v2f i) : SV_Target {
                // calculating directions, colour and diffuse lighting intensity
                float3 viewDir = normalize(i.viewDir);
                float4 albedo = tex2D(_MainTex, i.uv);
                float3 normal = normalize(i.worldNormal);
                float diffuse = dot(_WorldSpaceLightPos0, normal);

                // calculates shadow, apply anti aliasing and smoothens lighting 
                // based on shadows
                // smoothstep is used to 'toonify' the shadows and reflections
                fixed shadow = SHADOW_ATTENUATION(i);
                float delta = fwidth(diffuse) * _Antialiasing;
                float diffuseSmooth = smoothstep(0, delta, diffuse * shadow);
                float4 light = diffuseSmooth * _LightColor0;

                // specular lighting component of Blinn-Phong
                // specular colour (reflection tint) and glossiness (size of reflection)
                float3 halfVec = normalize(_WorldSpaceLightPos0 + viewDir);
                float lightDotP = dot(normal, halfVec);
                float specularIntensity = pow(lightDotP * diffuseSmooth, _Glossiness * _Glossiness);
                float specularSmooth = smoothstep(0, 0.01 * _Antialiasing, specularIntensity);
                float4 specular = specularSmooth * _SpecularColor;
                
                // rim lighting for simmulated reflected light
                // created from inverson of the dot product between normal and view direction
                float4 rimDotP = 1 - dot(viewDir, normal);
                float rimIntensity = rimDotP * pow(diffuse, _RimThreshold);
                rimIntensity = smoothstep(_RimAmount - 0.01, _RimAmount + 0.01, rimIntensity);
                float4 rim = rimIntensity * _RimColor;

                float4 colour = _Colour * albedo * (_Ambient + light + specular + rim);
                
                return colour;
            }
        ENDCG
        }
        UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
        
        Pass {
            // selective rendering through stencil to create outline
            Stencil {
				Ref [_ID]
				Comp notequal
				Fail keep
				Pass replace
			}

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            float _OutlineSize;
            float4 _OutlineColor;

            struct appdata {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f {
                float4 vertex : SV_POSITION;
            };

            // add outline effect through scaling normal by desired outline size then 
            // transformed to clip space to produce an outline
            v2f vert(appdata v) {
                v2f o;
                float3 normal = normalize(v.normal) * _OutlineSize;
                float3 position = v.vertex + normal;

                o.vertex = UnityObjectToClipPos(position);

                return o;
            }

            float4 frag(v2f i) : SV_Target {
                return _OutlineColor;
            }

            ENDCG
        }
        
    }
    FallBack "Diffuse"
}