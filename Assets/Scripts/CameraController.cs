using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cameraObject;
    public GameObject target;

    void FixedUpdate()
    {
        SelectTarget();
        CenterTarget();
        RotateWithMouse();
    }

    void SelectTarget()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var raycastHit, Camera.main.farClipPlane))
                if (raycastHit.transform.gameObject)
                    target = raycastHit.transform.gameObject;
        }
    }

    void CenterTarget()
    {
        transform.position = Vector3.Slerp(
            transform.position,
            target.transform.position,
            Time.deltaTime * 10
        );
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
