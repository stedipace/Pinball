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
            SetBallPos(startPos);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SetBallPos(mousePos);
        }
    }

    private void SetBallPos(Vector3 pos)
    {
        ball.transform.position = new Vector3(pos.x, pos.y, 0f);
        var ballRb = ball.GetComponent<Rigidbody2D>();
        ballRb.velocity = Vector2.zero;
        ballRb.angularVelocity = 0f;

        var trail = ball.GetComponent<TrailRenderer>();
        trail.Clear();
    }
}
