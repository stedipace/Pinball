using System.Collections;
using UnityEngine;

public class Kicker : MonoBehaviour
{
    [SerializeField] private float force = 10f;
    [SerializeField] private Color hitColor = Color.red;
    [SerializeField] private SpriteRenderer kickerEdgeSprite;
    [SerializeField] private float colorFlashDuration = 0.2f;

    private Color originalColor;

    private void Start()
    {
        if (kickerEdgeSprite != null)
        {
            originalColor = kickerEdgeSprite.color;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(Tags.Ball))
        {
            return;
        }

        if (collision.gameObject.TryGetComponent<Rigidbody2D>(out var ballRb))
        {
            var direction = (collision.transform.position - transform.position).normalized;
            ballRb.AddForce(direction * force, ForceMode2D.Impulse);
        }

        if (kickerEdgeSprite != null)
        {
            StartCoroutine(FlashColor());
        }

        //ContactPoint2D contact = collision.GetContact(0);
        //if (IsCollisionOnKickerEdge(contact.point))
        //{

        //}
    }

    //private bool IsCollisionOnKickerEdge(Vector2 collisionPoint)
    //{
    //    var edgePosition = kickerEdgeSprite.transform.position;
    //    return collisionPoint.x > edgePosition.x;
    //}

    private IEnumerator FlashColor()
    {
        kickerEdgeSprite.color = hitColor;
        yield return new WaitForSeconds(colorFlashDuration);
        kickerEdgeSprite.color = originalColor;
    }
}
