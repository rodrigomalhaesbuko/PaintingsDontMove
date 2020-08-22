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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
