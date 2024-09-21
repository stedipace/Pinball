using UnityEngine;

public abstract class BounceBehaviourBase : MonoBehaviour
{
    [SerializeField] protected float force = 10f;

    protected virtual void ApplyForce(Collider2D collider)
    {
        if (collider.TryGetComponent<Rigidbody2D>(out var ballRb))
        {
            var direction = (collider.transform.position - transform.position).normalized;
            ballRb.AddForce(direction * force, ForceMode2D.Impulse);
        }
    }

    protected abstract void OnCollision(Collider2D collider);

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(Tags.Ball))
        {
            return;
        }

        Debug.Log($"{name} collided with {collision.gameObject.name}");
        ApplyForce(collision.collider);
        OnCollision(collision.collider);
    }
}