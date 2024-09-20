using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Vector3 startPos = new(10.5f, 6.5f, 0f);
    private GameObject ball;

    private void Start()
    {
        ball = GameObject.FindWithTag("Ball");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ball.transform.position = startPos;
            var ballRb = ball.GetComponent<Rigidbody2D>();
            ballRb.velocity = Vector2.zero;
            ballRb.angularVelocity = 0f;

            var trail = ball.GetComponent<TrailRenderer>();
            trail.Clear();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
