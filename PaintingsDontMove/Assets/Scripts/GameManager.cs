using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/* Para usar a classe GameManger sem criar um referencia forte utilize o método
 * FindObjectOfType<GameManager>();
 */

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public int score;
    public float gameOverDelay = 0f;
    public Text scoreText;
    void Start()
    {
        score = 0;
    }

    //public void SetHighScore()
    //{
    //    score += 15;
    //}

    public void GameOver()
    {
        //save highScore
        Debug.Log("SCOREEE::::" + score.ToString());
        PlayerPrefs.SetInt("score", score);

        SceneManager.LoadScene("GameOver");
        // Precisa fazer a Scene Game Over aparecer
    }

    public void GameOverSeenMoving()
    {
        //save highScore
        Debug.Log("SCOREEE::::" + score.ToString());
        PlayerPrefs.SetInt("score", score);
        Invoke("LoadGameOverSeenMoving", gameOverDelay);
        // Precisa fazer a Scene Game Over aparecer
    }

    private void LoadGameOverSeenMoving()
    {
        SceneManager.LoadScene("GameOverSeenMoving");
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
                    GameOverSeenMoving();
                }
            }

        }
        scoreText.text = score.ToString();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }
}
