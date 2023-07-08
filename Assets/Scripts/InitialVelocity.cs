using UnityEngine;

public class IntialVelocity : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 angularVelocity;

    void Awake()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = velocity;
        rigidbody.angularVelocity = angularVelocity;
    }
}
