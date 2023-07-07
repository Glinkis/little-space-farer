using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cameraObject;

    public Vector3 center;

    public Vector2 speed;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RotateCamera();
        }
    }

    void RotateCamera()
    {
        cameraObject.transform.RotateAround(
           center,
           cameraObject.transform.up,
           Input.GetAxis("Mouse X") * speed.x
        );

        cameraObject.transform.RotateAround(
            center,
            cameraObject.transform.right,
            Input.GetAxis("Mouse Y") * speed.y
        );
    }
}
