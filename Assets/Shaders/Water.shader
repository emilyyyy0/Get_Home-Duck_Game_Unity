
Shader "Custom/Water" {
    Properties
    {	
        _Shallow("Depth Gradient Shallow", Color) = (0.325, 0.807, 0.971, 0.725)
        _Deep ("Depth Gradient Deep", Color) = (0.086, 0.407, 1, 0.749)
        _DepthDistance ("Depth Maximum Distance", Float) = 1
        _SurfaceNoise("Surface Noise", 2D) = "white" {}
        _NoiseCutOff("Noise Cutoff", Range(0, 1)) = 0.777
        _FoamDistance("Foam Maximum Distance", Float) = 1
        _FoamColor("Foam Color", Color) = (1,1,1,1)
        _SurfaceNoiseScroll("Surface Noise Scroll Amount", Vector) = (0.03, 0.03, 0, 0)
        _SurfaceDistortion("Surface Distortion", 2D) = "white" {}	
        _SurfaceDistortionAmount("Surface Distortion Amount", Range(0, 1)) = 0.27
        _Frequency("Frequency", Range(0, 200)) = 100
        _Amplitude("Amplitude", Range(0, 2)) = 1
        
    }   
    SubShader
    {
        Tags {
            "RenderType"="Transparent" 
            "Queue"="Transparent"
            "LightMode" = "ForwardBase"
	        "PassFlags" = "OnlyDirectional"
        }
        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            Cull Off 

			CGPROGRAM

            #define SMOOTHSTEP_AA 0.01

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            // normal blending - multiplying shader output by its SrcAlpha (top)
            // plus - multiplying on screen colour by 1-alpha of output (bottom)
            // this creates brighter foam that blends the water surface
            float4 alphaBlend(float4 top, float4 bottom) {
                float3 colour = (top.rgb * top.a) + (bottom.rgb * (1 - top.a));
                float alpha = top.a + bottom.a * (1 - top.a);

                return float4(colour, alpha);
            }

            float4 _Shallow;
            float4 _Deep;
            float _DepthDistance;
            float _FoamDistance;
            float4 _FoamColor;
            float _NoiseCutOff;
            float2 _SurfaceNoiseScroll;
            sampler2D _SurfaceDistortion;
            float4 _SurfaceDistortion_ST;
            float _SurfaceDistortAmount;
            float _Amplitude;
            float _Frequency;
            
            sampler2D _CameraDepthTexture;

            struct appdata
            {
                float4 vertex : POSITION;
                float4 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 screenPosition : TEXCOORD2;
                float2 noiseUV : TEXCOORD0;
                float2 distortUV : TEXCOORD1;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD3;
            };

            sampler2D _SurfaceNoise;
            float4 _SurfaceNoise_ST;
            sampler2D _CameraNormalsTexture;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.screenPosition = ComputeScreenPos(o.vertex);
                o.noiseUV = TRANSFORM_TEX(v.uv, _SurfaceNoise);
                o.distortUV = TRANSFORM_TEX(v.uv, _SurfaceDistortion);
                o.normal = UnityObjectToWorldNormal(v.normal);

                // wave movement 
                float4 worldPos = mul(unity_ObjectToWorld, v.vertex);
                float wave = (sin(worldPos.y) + sin(worldPos.x + (_Frequency * _Time)));
                worldPos.y = worldPos.y + (wave * _Amplitude);
                worldPos.x = worldPos.x + (wave * _Amplitude);
                o.vertex = mul(UNITY_MATRIX_VP, worldPos);

                o.uv = v.uv;

                return o;
            }

            float4 frag (v2f i) : SV_Target
            {

                // calculating depth relative to camera 
				float cameraDepth = LinearEyeDepth(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.screenPosition)));
                // depth relative to the surface of the water
                float relativeSurfaceDepth = cameraDepth - i.screenPosition.w; 
                
                // foam rendered by controlling noise cutoff based on water depth
                float foamDepth = saturate(relativeSurfaceDepth /  _FoamDistance);
                float surfaceNoiseCutoff = foamDepth * _NoiseCutOff;

                // interpolating between two colours to create a gradient 
                float waterColorDepth = saturate(relativeSurfaceDepth / _DepthDistance);
                float4 waterColor = lerp(_Shallow, _Deep, waterColorDepth);

                // movement that is created through a distortion texture
                // where the red and green channels of colour are used to pull 
                // the noise texture thus creating more movement
                float2 distortSample = (tex2D(_SurfaceDistortion, i.distortUV).xy * 2 - 1) * _SurfaceDistortAmount;
                float2 noiseUV = float2((i.noiseUV.x + _Time.y * _SurfaceNoiseScroll.x) + distortSample.x, (i.noiseUV.y + _Time.y * _SurfaceNoiseScroll.y) + distortSample.y);
                float surfaceNoiseSample = tex2D(_SurfaceNoise, noiseUV).r;
                
                // anti aliasing with smoothstep to smoothen foam edges 
                float surfaceNoise = smoothstep(surfaceNoiseCutoff - SMOOTHSTEP_AA, surfaceNoiseCutoff + SMOOTHSTEP_AA, surfaceNoiseSample);

                // alpha blend of foam so it maintains transparency
                float4 surfaceNoiseColor = _FoamColor;
                surfaceNoiseColor.a *= surfaceNoise;

                float4 finalWaveColor = alphaBlend(surfaceNoiseColor, waterColor);

                return finalWaveColor; 
            }
            ENDCG
        }
    }
}