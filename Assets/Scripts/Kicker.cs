using UnityEngine;

public class Kicker : MonoBehaviour
{
    [SerializeField] private float force = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball"))
        {
            return;
        }

        if (collision.gameObject.TryGetComponent<Rigidbody2D>(out var ballRb))
        {
            var direction = (collision.transform.position - transform.position).normalized;
            ballRb.AddForce(direction * force, ForceMode2D.Impulse);
        }
    }
}
