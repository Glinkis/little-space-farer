using UnityEngine;

public class VirtualBody
{
    public float mass;
    public Vector3 velocity;
    public Vector3 position;
    public RigidbodyConstraints constraints;

    public VirtualBody(CelestialBody celestialBody)
    {
        mass = celestialBody.Mass;

        velocity = celestialBody.Velocity;

        position = celestialBody.Position;

        constraints = celestialBody.Constraints;
    }
}
