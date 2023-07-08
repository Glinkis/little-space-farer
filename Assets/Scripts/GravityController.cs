using UnityEngine;

public class GravityController : MonoBehaviour
{
    void FixedUpdate()
    {
        Rigidbody[] rigidbodies = Object.FindObjectsByType<Rigidbody>(0);

        foreach (Rigidbody current in rigidbodies)
        {
            foreach (Rigidbody other in rigidbodies)
            {
                if (current == other)
                    continue;

                Vector3 relativePosition = other.position - current.position;
                float distance = relativePosition.magnitude;

                if (distance == 0)
                    continue;

                float magnitude = (current.mass * other.mass) / (distance * distance);
                Vector3 force = 9.82f * magnitude * relativePosition.normalized;

                current.AddForce(force);

                Debug.DrawLine(current.position, current.position + force, Color.red);
                Debug.DrawLine(current.position, current.position + current.velocity, Color.blue);
            }
        }
    }
}
