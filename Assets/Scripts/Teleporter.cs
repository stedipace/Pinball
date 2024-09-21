using System.Collections;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private float waitTime = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(Tags.Ball))
        {
            return;
        }

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

        StartCoroutine(TeleportAfterDelay(transform));
    }

    private IEnumerator TeleportAfterDelay(Transform ballTransform)
    {
        var animator = ballTransform.GetComponentInChildren<Animator>(true);
        animator.gameObject.SetActive(true);
        animator.Play("Teleport");

        //while (animator.GetCurrentAnimatorStateInfo(0).IsName("Teleport"))
        //{
        //    yield return null;
        //}
        yield return new WaitForSeconds(waitTime);

        ballTransform.position = destination.position;

        if (ballTransform.TryGetComponent<Rigidbody2D>(out var ballRb))
        {
            ballRb.isKinematic = false;
            ballRb.velocity = Vector2.zero;
            ballRb.angularVelocity = 0f;
        }
        animator.gameObject.SetActive(false);
    }
}
