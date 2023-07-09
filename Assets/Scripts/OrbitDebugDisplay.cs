using UnityEngine;

[ExecuteInEditMode]
public class OrbitDebugDisplay : MonoBehaviour
{
    [Range(1, 10000)]
    public int numberOfSteps = 1000;
    public float timeStep = 0.01f;
    public bool showWhenPlaying = false;

    void Update()
    {
        DrawOrbits(FindObjectsByType<CelestialBody>(FindObjectsSortMode.None));
    }

    void DrawOrbits(CelestialBody[] bodies)
    {
        var virtualBodies = new VirtualBody[bodies.Length];
        var drawPoints = new Vector3[bodies.Length][];

        // Initialize virtual bodies (don't want to move the actual bodies)
        for (int i = 0; i < virtualBodies.Length; i++)
        {
            virtualBodies[i] = new VirtualBody(bodies[i]);
            drawPoints[i] = new Vector3[numberOfSteps];
        }

        // Simulate
        for (int step = 0; step < numberOfSteps; step++)
        {
            // Update velocities
            for (int i = 0; i < virtualBodies.Length; i++)
            {
                Vector3 acceleration = Vector3.zero;

                for (int j = 0; j < virtualBodies.Length; j++)
                {
                    acceleration += GravityController.CalculateAcceleration(
                        virtualBodies[i],
                        virtualBodies[j]
                    );
                }

                virtualBodies[i].velocity += acceleration * timeStep;
            }

            // Update positions
            for (int i = 0; i < virtualBodies.Length; i++)
            {
                virtualBodies[i].position += virtualBodies[i].velocity * timeStep;
                drawPoints[i][step] = virtualBodies[i].position;
            }
        }

        // Draw paths
        for (int bodyIndex = 0; bodyIndex < virtualBodies.Length; bodyIndex++)
        {
            Color pathColour = bodies[bodyIndex]
                .GetComponentInChildren<MeshRenderer>()
                .sharedMaterial.color;

            Vector3[] points = drawPoints[bodyIndex];
            for (int i = 0; i < points.Length - 1; i++)
            {
                Debug.DrawLine(drawPoints[bodyIndex][i], drawPoints[bodyIndex][i + 1], pathColour);
            }
        }
    }
}
