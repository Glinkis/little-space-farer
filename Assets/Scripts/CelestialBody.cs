using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Rigidbody))]
public class CelestialBody : MonoBehaviour
{
    public Vector3 velocity;
    public float Mass => rigidBody.mass;
    public Vector3 Position => rigidBody.position;
    public RigidbodyConstraints Constraints => rigidBody.constraints;
    public CelestialBody[] excludedBodies;

    Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void UpdateVelocity(Vector3 acceleration, float timeStep)
    {
        velocity += acceleration * timeStep;

        DrawLineToRelativePosition(acceleration, Color.red);
        DrawLineToRelativePosition(velocity, Color.blue);
    }

    public void UpdatePosition(float timeStep)
    {
        rigidBody.MovePosition(Position + velocity * timeStep);
    }

    public void DrawLineToRelativePosition(Vector3 position, Color color)
    {
        Debug.DrawLine(Position, Position + position, color);
    }
}
