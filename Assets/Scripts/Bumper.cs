using System.Collections;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] private float force = 10f;
    [SerializeField] private float vibrationDuration = 0.2f;
    [SerializeField] private float vibrationAmount = 0.1f;
    [SerializeField] private float vibrationSpeed = 40f;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.localPosition;
    }

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

            StartCoroutine(Vibrate());
        }
    }

    private IEnumerator Vibrate()
    {
        var time = 0f;

        while (time < vibrationDuration)
        {
            var xOffset = Mathf.Sin(Time.time * vibrationSpeed) * vibrationAmount;
            var yOffset = Mathf.Cos(Time.time * vibrationSpeed) * vibrationAmount;

            transform.localPosition = startPos + new Vector3(xOffset, yOffset, 0f);

            time += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = startPos;
    }
}
