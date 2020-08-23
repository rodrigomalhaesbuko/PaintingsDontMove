using UnityEngine;
using UnityEngine.SceneManagement;

/* Para usar a classe GameManger sem criar um referencia forte utilize o método
 * FindObjectOfType<GameManager>();
 */

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public int score;
    public float gameOverDelay = 1f;

    void Start()
    {
        score = 0;
    }

    //public void SetHighScore()
    //{
    //    score += 15;
    //}

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("GameOver", gameOverDelay);
            // Chamar tela de Game Over
        }
    }

    public void GameOver()
    {
        //save highScore
        Debug.Log("SCOREEE::::" + score.ToString());
        PlayerPrefs.SetInt("score", score);
        SceneManager.LoadScene("GameOver");
        // Precisa fazer a Scene Game Over aparecer
    }

    public void IncreasePoints()
    {
        // Adiciona pontos ao placar e muda a UI
    }

    public void Update()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "Main")
        {
            
            if(AdmireComponent.isAdmiring)
            {
                if(!timeManipulation.ZAWARUDO)
                {
                    GameOver();
                }
            }
        }
    }
}
