using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera camera;

    public Vector3 center;

    public Vector2 speed;

    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        if (Input.GetMouseButton(0))
        {
            camera.transform.RotateAround(
                center,
                camera.transform.up,
                Input.GetAxis("Mouse X") * speed.x
            );

            camera.transform.RotateAround(
                center,
                camera.transform.right,
                Input.GetAxis("Mouse Y") * speed.y
            );
        }
    }
}
