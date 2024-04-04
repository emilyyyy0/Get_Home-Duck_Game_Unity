using Cinemachine;
using UnityEngine;

public class CameraScrollScript : MonoBehaviour
{
    public string cameraTag = "MainCamera"; // Tag assigned to the cameras
    public float fovSpeed = 50f; // Sensitivity of FOV change
    public float minFov = 30f, maxFov = 70f; // Max & Min FOV

    public float smoothTime = 0.1f; // Time taken to smoothly interpolate FOV changes
    public float momentum = 0.05f; // Controls the momentum effect

    // Variables used to control the FOV Animation
    private float currentVelocity;
    private bool isScrolling;
    private float targetFOV;

    private void Start()
    {
        targetFOV = maxFov; // Start at the maximum defined FOV.
    }

    private void Update()
    {
        // Get the mouse wheel input
        var scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
        // Update the 'targetFOV' based on the scroll wheel input.
        if (scrollWheelInput != 0f)
        {
            isScrolling = true;
            targetFOV -= scrollWheelInput * fovSpeed;
        }

        UpdateAllCameraFOVs(); // Update all cameras to the new FOV

        // Apply momentum effect
        if (!isScrolling)
        {
            targetFOV -= currentVelocity * momentum;
            currentVelocity = Mathf.Lerp(currentVelocity, 0f, smoothTime);
        }

        // Ensure the FOV stays within a reasonable range
        targetFOV = Mathf.Clamp(targetFOV, minFov, maxFov);
    }

    private void UpdateAllCameraFOVs()
    {
        // Find all GameObjects with the camera tag
        var taggedCameras = GameObject.FindGameObjectsWithTag(cameraTag);

        foreach (var taggedCamera in taggedCameras)
        {
            // Handle Cine Cameras (different way to update the FOV)
            var cineCam = taggedCamera.GetComponent<CinemachineVirtualCamera>();
            if (cineCam != null)
                cineCam.m_Lens.FieldOfView = Mathf.SmoothDamp(
                    cineCam.m_Lens.FieldOfView,
                    targetFOV,
                    ref currentVelocity,
                    smoothTime
                );
        }
    }
}