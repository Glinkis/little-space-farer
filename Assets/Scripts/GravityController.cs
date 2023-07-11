using UnityEngine;

public class GravityController : MonoBehaviour
{
    void FixedUpdate()
    {
        var bodies = FindObjectsByType<CelestialBody>(FindObjectsSortMode.None);

        for (int i = 0; i < bodies.Length; i++)
        {
            Vector3 acceleration = Vector3.zero;

            for (int j = 0; j < bodies.Length; j++)
            {
                acceleration += CalculateAcceleration(
                    new VirtualBody(bodies[i]),
                    new VirtualBody(bodies[j])
                );
            }

            bodies[i].UpdateVelocity(acceleration, Time.deltaTime);
        }

        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdatePosition(Time.deltaTime);
        }
    }

    public static Vector3 CalculateAcceleration(VirtualBody current, VirtualBody other)
    {
        // If the current body is the same as the other body, it won't move.
        if (current.celestialBody == other.celestialBody)
            return Vector3.zero;

        // If the current body is frozen, it won't move.
        if (current.celestialBody.Constraints == RigidbodyConstraints.FreezePosition)
            return Vector3.zero;

        // If the current body explicitly excludes the other body, it won't move.
        if (current.celestialBody.excludedBodies != null)
            for (int i = 0; i < current.celestialBody.excludedBodies.Length; i++)
                if (current.celestialBody.excludedBodies[i] == other.celestialBody)
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
