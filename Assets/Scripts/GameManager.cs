using UnityEngine;
using UnityEngine.SceneManagement;

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
            //ball.transform.position = startPos;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
