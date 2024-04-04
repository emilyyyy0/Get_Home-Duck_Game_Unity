using Cinemachine;
using UnityEngine;

public class FreeAndFollowCameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera followCam, freeCam;
    public float boundary = 10.0f;
    private readonly int moveSpeed = 20;
    private bool followCamActive = true;
    private bool spaceHeld;

    private void Start()
    {
        followCam.gameObject.SetActive(true);
        freeCam.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        // Check if Space is held. If so, center on Duck.
        // HoldSpaceToCenterFeature();

        // Check if Y is pressed. Y will toggle between free and follow cameras.
        // PressYToToggleFeature();

        // Update Camera & Position
        if (followCamActive)
        {
            followCam.gameObject.SetActive(true);
            freeCam.gameObject.SetActive(false);
        }
        else
        {
            if (followCam.gameObject.activeSelf)
            {
                freeCam.transform.position = followCam.transform.position;
                followCam.gameObject.SetActive(false);
            }

            freeCam.gameObject.SetActive(true);
            MoveFreeCamera();
        }
    }

    private void MoveFreeCamera()
    {
        // Calculate the camera's new position
        var newPosition = freeCam.transform.position;
        var moveAmt = moveSpeed * Time.deltaTime;

        if (Input.mousePosition.y <= boundary) // Down
        {
            newPosition.z += moveAmt;
            newPosition.x -= moveAmt;
        }
        else if (Input.mousePosition.y >= Screen.height - boundary) // Up
        {
            newPosition.z -= moveAmt;
            newPosition.x += moveAmt;
        }
        else if (Input.mousePosition.x >= Screen.width - boundary) // Right
        {
            newPosition.x -= moveAmt;
            newPosition.z -= moveAmt;
        }
        else if (Input.mousePosition.x <= boundary) // Left
        {
            newPosition.x += moveAmt;
            newPosition.z += moveAmt;
        }

        // Apply the new position to the camera
        freeCam.transform.position = newPosition;
    }

    private void HoldSpaceToCenterFeature()
    {
        if (Input.GetKey(KeyCode.Space)) // If space is held
        {
            spaceHeld = true;
            followCamActive = true;
        }
        else if (followCamActive && spaceHeld)
        {
            spaceHeld = false;
            followCamActive = false;
        }
    }

    private void PressYToToggleFeature()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            spaceHeld = false;
            followCamActive = !followCamActive;
        }
    }
}