using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cameraObject;

    public GameObject center;

    void Update()
    {
        RotateWithMouse();
    }

    void RotateWithMouse()
    {
        if (Input.GetMouseButton(1))
        {
            cameraObject.transform.RotateAround(
                center.transform.position,
                cameraObject.transform.up,
                Input.GetAxis("Mouse X") * 10
            );

            cameraObject.transform.RotateAround(
                center.transform.position,
                cameraObject.transform.right,
                Input.GetAxis("Mouse Y") * -10
            );
        }
    }
}
