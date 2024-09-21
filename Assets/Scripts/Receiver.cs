using System.Collections;
using UnityEngine;

public abstract class ReceiverBase : MonoBehaviour
{
    [SerializeField] private float waitTime = 0.5f;

    protected virtual void OnEnter(Collider2D collision)
    {
        var transform = collision.transform;
        var ballRb = transform.GetComponent<Rigidbody2D>();

        transform.position = this.transform.position;

        if (ballRb != null)
        {
            ballRb.velocity = Vector2.zero;
            ballRb.angularVelocity = 0f;
            ballRb.isKinematic = true;

            var trail = ballRb.GetComponent<TrailRenderer>();
            trail.Clear();
        }
    }

    protected virtual void OnExit(Collider2D collision)
    {
        if (collision.TryGetComponent<Rigidbody2D>(out var ballRb))
        {
            ballRb.isKinematic = false;
            ballRb.velocity = Vector2.zero;
            ballRb.angularVelocity = 0f;
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(Tags.Ball))
        {
            return;
        }

        StartCoroutine(Receive(collision));
    }

    private IEnumerator Receive(Collider2D collision)
    {
        OnEnter(collision);
        yield return new WaitForSeconds(waitTime);
        OnExit(collision);
    }
}
