using UnityEngine;

public class VirtualBody
{
    public float mass;
    public Vector3 velocity;
    public Vector3 position;
    public RigidbodyConstraints constraints;
    public CelestialBody celestialBody;

    public VirtualBody(CelestialBody celestialBody)
    {
        mass = celestialBody.Mass;

        velocity = celestialBody.velocity;

        position = celestialBody.Position;

        constraints = celestialBody.Constraints;

        this.celestialBody = celestialBody;
    }
}
