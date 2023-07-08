using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera cameraObject;
    Transform center;
    Transform target;

    void Awake()
    {
        cameraObject = GetComponentInChildren<Camera>();
        center = GetComponent<Transform>();
        target = center;
    }

    void Update()
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
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit, Camera.main.farClipPlane))
                if (raycastHit.transform.gameObject)
                    target = raycastHit.transform;
        }
    }

    void CenterTarget()
    {
        center.transform.position = Vector3.Slerp(
            center.position,
            target.position,
            Time.deltaTime * 10
        );

        cameraObject.transform.LookAt(center.position);
    }

    void RotateWithMouse()
    {
        if (Input.GetMouseButton(1))
        {
            cameraObject.transform.RotateAround(
                center.position,
                cameraObject.transform.up,
                Input.GetAxis("Mouse X") * 10
            );

            cameraObject.transform.RotateAround(
                center.position,
                cameraObject.transform.right,
                Input.GetAxis("Mouse Y") * -10
            );
        }
    }
}
