using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 velocity;
    Collider collider;
    Collider[] birds;

    Vector3 cohesion;
    Vector3 separation;
    Vector3 alignment;

    float cohesionRadius = 8;
    float separationDistance = 10;
    float maxSpeed = 15;
    float flyRadius = 10;
    int separationCount;

    void Start()
    {
        collider = GetComponent<Collider>();
        InvokeRepeating("CalculateVelocity", 0, 0.1f);
    }

    void CalculateVelocity()
    {
        velocity = Vector3.zero;
        cohesion = Vector3.zero;
        separation = Vector3.zero;
        alignment = Vector3.zero;
        separationCount = 0;

        birds = Physics.OverlapSphere(transform.position, cohesionRadius);

        foreach (var bird in birds)
        {
            cohesion += bird.transform.position;
            alignment += bird.GetComponent<Boid>().velocity;

            if (bird != collider && (transform.position - bird.transform.position).magnitude < separationDistance)
            {
                separation += (transform.position - bird.transform.position) /
                    (transform.position - bird.transform.position).magnitude;

                separationCount++;
            }
        }

        cohesion /= birds.Length;
        cohesion -= transform.position;
        cohesion = Vector3.ClampMagnitude(cohesion, maxSpeed);

        if (separationCount > 3)
        {
            separation /= separationCount;
            separation = Vector3.ClampMagnitude(separation, maxSpeed);
        }

        alignment /= birds.Length;
        alignment = Vector3.ClampMagnitude(alignment, maxSpeed);

        velocity += cohesion + separation * 10 + alignment * 1.5f;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
    }

    void Update()
    {
        if (transform.position.magnitude > flyRadius)
            velocity += -transform.position.normalized;

        transform.position += velocity * Time.deltaTime;

        if (velocity != Vector3.zero && transform.forward != velocity.normalized)
        {
            transform.forward = Vector3.RotateTowards(transform.forward, velocity, 10, 5);
        }
    }
}
