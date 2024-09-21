using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Vector3 startPos = new(10.5f, 6.5f, 0f);
    [SerializeField] private GameObject ballPrefab;
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
            ball = GameObject.FindWithTag(Tags.Ball);

            if (ball == null)
            {
                Instantiate(ballPrefab, mousePos, Quaternion.identity);
            }

            SetBallPos(mousePos);
        }
    }

    private void SetBallPos(Vector3 pos)
    {
        if (ball == null)
        {
            ball = GameObject.FindWithTag(Tags.Ball);
        }

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

    //    private void OnGUI()
    //    {
    //        var controlRect = new Rect(10, 10, 220, 110);

    //        var boxStyle = new GUIStyle(GUI.skin.box);
    //        boxStyle.normal.background = MakeTex(2, 2, new Color(0f, 0f, 0f, 0.5f));

    //        GUI.Box(controlRect, GUIContent.none, boxStyle);

    //        GUI.Label(new Rect(20, 20, 200, 20), "A/D: Left/Right Flipper");
    //        GUI.Label(new Rect(20, 40, 200, 20), "S: Both flippers");
    //        GUI.Label(new Rect(20, 60, 200, 20), "Space: Plunger");
    //        GUI.Label(new Rect(20, 80, 200, 20), "R: Reset balls");
    //        GUI.Label(new Rect(20, 100, 300, 20), "Click: Spawn ball at mouse position");
    //    }

    //    private Texture2D MakeTex(int width, int height, Color col)
    //    {
    //        var pix = new Color[width * height];
    //        for (var i = 0; i < pix.Length; i++)
    //        {
    //            pix[i] = col;
    //        }
    //        var result = new Texture2D(width, height);
    //        result.SetPixels(pix);
    //        result.Apply();
    //        return result;
    //    }
}

public static class Tags
{
    public static readonly string Ball = "Ball";
}
