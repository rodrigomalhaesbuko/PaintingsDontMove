using UnityEngine;
using UnityEngine.SceneManagement;


public class Credits : MonoBehaviour
{

    public static bool gameOver = false;

    private void Update()
    {
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
