using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform destination;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(Tags.Ball))
        {
            return;
        }

        var transform = collision.transform;
        transform.position = destination.position;

        if (transform.TryGetComponent<Rigidbody2D>(out var ballRb))
        {
            ballRb.velocity = Vector2.zero;
            ballRb.angularVelocity = 0f;
        }
    }
}
