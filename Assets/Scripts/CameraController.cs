using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cameraObject;
    public GameObject target;

    void Update()
    {
        transform.position = target.transform.position;
    }

    void FixedUpdate()
    {
        cameraObject.transform.LookAt(target.transform);

        RotateWithMouse();
    }

    void RotateWithMouse()
    {
        if (Input.GetMouseButton(1))
        {
            cameraObject.transform.RotateAround(
                transform.position,
                cameraObject.transform.up,
                Input.GetAxis("Mouse X") * 10
            );

            cameraObject.transform.RotateAround(
                transform.position,
                cameraObject.transform.right,
                Input.GetAxis("Mouse Y") * -10
            );
        }
    }
}
