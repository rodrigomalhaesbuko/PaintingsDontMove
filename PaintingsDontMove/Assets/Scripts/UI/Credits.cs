using UnityEngine;
using UnityEngine.SceneManagement;


public class Credits : MonoBehaviour
{

    public static bool gameOver = false;

    private float timer = 0;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.5f)
        {
            timer = 0.6f;

            if (Input.anyKey)
            {
                if (gameOver)
                {
                    SceneManager.LoadScene("GameOver");
                }
                else
                {
                    SceneManager.LoadScene("GameOverSeenMoving");
                }

            }
        }
    }
}
