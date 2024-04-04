using UnityEngine;

public class BillboardCanvas : MonoBehaviour
{
    private Transform camTransform;

    // Start is called before the first frame update
    private void Start()
    {
        camTransform = Camera.main.transform;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.LookAt(
            transform.position + camTransform.rotation * -Vector3.forward,
            camTransform.rotation * Vector3.up
        );
    }
}