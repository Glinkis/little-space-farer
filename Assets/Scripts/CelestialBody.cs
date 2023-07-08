using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Rigidbody))]
public class CelestialBody : MonoBehaviour
{
    public Vector3 initialVelocity;

    public float Mass => rigidBody.mass;
    public Vector3 Position => rigidBody.position;
    public RigidbodyConstraints Constraints => rigidBody.constraints;

    public Vector3 Velocity { get; private set; }

    Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        Velocity = initialVelocity;
    }

    public void UpdateVelocity(Vector3 acceleration, float timeStep)
    {
        Velocity += acceleration * timeStep;

        Debug.DrawLine(Position, Position + acceleration, Color.red);
        Debug.DrawLine(Position, Position + Velocity, Color.blue);
    }

    public void UpdatePosition(float timeStep)
    {
        rigidBody.MovePosition(Position + Velocity * timeStep);
    }
}
