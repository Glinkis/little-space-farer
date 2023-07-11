using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ship : MonoBehaviour
{
    public Vector3 velocity;
    public float thrust = 5f;
    public float torque = 1f;

    void Awake()
    {
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = velocity;
    }

    void FixedUpdate()
    {
        var particles = GetComponentInChildren<ParticleSystem>();
        var rigidBody = GetComponent<Rigidbody>();

        if (Input.GetKey(KeyCode.Space))
        {
            particles.Play();
            Vector3 thrustDir = transform.TransformVector(0, thrust, 0);
            rigidBody.AddForce(thrustDir, ForceMode.Acceleration);
        }
        else
        {
            particles.Stop();
        }

        if (Input.GetKey(KeyCode.W))
            rigidBody.AddRelativeTorque(torque, 0, 0);

        if (Input.GetKey(KeyCode.A))
            rigidBody.AddRelativeTorque(0, 0, -torque);

        if (Input.GetKey(KeyCode.S))
            rigidBody.AddRelativeTorque(-torque, 0, 0);

        if (Input.GetKey(KeyCode.D))
            rigidBody.AddRelativeTorque(0, 0, torque);

        if (Input.GetKey(KeyCode.Q))
            rigidBody.AddRelativeTorque(0, torque, 0);

        if (Input.GetKey(KeyCode.E))
            rigidBody.AddRelativeTorque(0, -torque, 0);

        var bodies = FindObjectsByType<CelestialBody>(FindObjectsSortMode.None);

        Vector3 acceleration = Vector3.zero;

        for (int i = 0; i < bodies.Length; i++)
        {
            Vector3 relativePosition = bodies[i].Position - transform.position;
            float sqrMagnitude = relativePosition.sqrMagnitude;

            float gravity = 20f;

            acceleration += gravity * bodies[i].Mass / sqrMagnitude * relativePosition.normalized;
        }

        rigidBody.AddForce(acceleration, ForceMode.Acceleration);
    }
}
