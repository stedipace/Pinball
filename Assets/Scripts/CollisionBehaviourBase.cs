using UnityEngine;

public abstract class CollisionBehaviourBase : MonoBehaviour
{
    protected abstract void OnCollision(Collider2D collider);

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(Tags.Ball))
        {
            return;
        }

        Debug.Log($"{name} collided with {collision.gameObject.name}");
        OnCollision(collision.collider);
    }
}