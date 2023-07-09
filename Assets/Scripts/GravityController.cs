using UnityEngine;

public class GravityController : MonoBehaviour
{
    public float timeStep = 0.01f;

    void Awake()
    {
        Time.fixedDeltaTime = timeStep;
    }

    void FixedUpdate()
    {
        var bodies = FindObjectsByType<CelestialBody>(FindObjectsSortMode.None);

        foreach (var current in bodies)
        {
            Vector3 acceleration = Vector3.zero;

            foreach (var other in bodies)
            {
                acceleration += CalculateAcceleration(
                    new VirtualBody(current),
                    new VirtualBody(other)
                );
            }

            current.UpdateVelocity(acceleration, timeStep);
        }

        foreach (var current in bodies)
        {
            current.UpdatePosition(timeStep);
        }
    }

    public static Vector3 CalculateAcceleration(VirtualBody current, VirtualBody other)
    {
        // If the current body is frozen, it won't move.
        if (current.constraints == RigidbodyConstraints.FreezePosition)
            return Vector3.zero;

        // If the current body is the same as the other body, it won't move.
        if (current.celestialBody == other.celestialBody)
            return Vector3.zero;

        Vector3 relativePosition = other.position - current.position;
        float sqrMagnitude = relativePosition.sqrMagnitude;

        // If the other body is too close, it won't move.
        if (sqrMagnitude < 0.1f)
            return Vector3.zero;

        float gravity = 9.82f;

        return gravity * other.mass / sqrMagnitude * relativePosition.normalized;
    }
}
