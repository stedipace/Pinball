using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Vector3 startPos = new(10.5f, 6.5f, 0f);
    private GameObject ball;

    private void Start()
    {
        ball = GameObject.FindWithTag(Tags.Ball);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //SetBallPos(startPos);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            var balls = GameObject.FindGameObjectsWithTag(Tags.Ball);
            foreach (var ball in balls)
            {
                Destroy(ball);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SetBallPos(mousePos);
        }
    }

    private void SetBallPos(Vector3 pos)
    {
        ball = GameObject.FindWithTag(Tags.Ball);
        if (ball == null)
        {
            return;
        }

        ball.transform.position = new Vector3(pos.x, pos.y, 0f);
        var ballRb = ball.GetComponent<Rigidbody2D>();
        ballRb.velocity = Vector2.zero;
        ballRb.angularVelocity = 0f;

        var trail = ball.GetComponent<TrailRenderer>();
        trail.Clear();
    }
}

public static class Tags
{
    public static readonly string Ball = "Ball";
}
