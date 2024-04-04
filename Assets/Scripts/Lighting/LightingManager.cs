using UnityEngine;

namespace Lighting

{
    [ExecuteAlways]
    public class LightingManager : MonoBehaviour
    {
        //Scene References
        [SerializeField] private Light DirectionalLight;
        [SerializeField] private LightingPreset Preset;

        [SerializeField] private CountdownTimer timer;

        //Variables
        [SerializeField] [Range(15, 24)] private float TimeOfDay;


        private void Update()
        {
            if (Preset == null)
                return;

            if (Application.isPlaying)
            {
                var gameProgress = timer is null
                    ? Time.time / (5 * 60) // Use Game Time
                    : 1 - timer.GetTimeRemaining() / 300f; // Use CountdownTimer

                // (Replace with a reference to the game time)
                TimeOfDay = Mathf.Lerp(15f, 24f, gameProgress);
                UpdateLighting(TimeOfDay / 24f);
            }
            else
            {
                UpdateLighting(TimeOfDay / 24f);
            }
        }

        //Try to find a directional light to use if we haven't set one
        private void OnValidate()
        {
            if (DirectionalLight != null)
                return;

            //Search for lighting tab sun
            if (RenderSettings.sun != null)
            {
                DirectionalLight = RenderSettings.sun;
            }
            //Search scene for light that fits criteria (directional)
            else
            {
                var lights = FindObjectsOfType<Light>();
                foreach (var light in lights)
                    if (light.type == LightType.Directional)
                    {
                        DirectionalLight = light;
                        return;
                    }
            }
        }


        private void UpdateLighting(float timePercent)
        {
            //Set ambient and fog
            RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
            RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

            //If the directional light is set then rotate and set it's color, I actually rarely use the rotation because it casts tall shadows unless you clamp the value
            if (DirectionalLight != null)
            {
                DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);

                DirectionalLight.transform.localRotation =
                    Quaternion.Euler(new Vector3(timePercent * 360f - 90f, 170f, 0));
            }
        }
    }
}