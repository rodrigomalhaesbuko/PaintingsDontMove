using UnityEngine;
using UnityEngine.SceneManagement;

/* Para usar a classe GameManger sem criar um referencia forte utilize o método
 * FindObjectOfType<GameManager>();
 */

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float gameOverDelay = 1f;

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

    void GameOver()
    {
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
                if(!timeManipulation.ZAWARUDO || Input.GetKeyDown("up") || Input.GetKeyDown("down") || Input.GetKeyDown("right") || Input.GetKeyDown("left"))
                {
                    GameOver();
                }
            }

        }
    }
}
