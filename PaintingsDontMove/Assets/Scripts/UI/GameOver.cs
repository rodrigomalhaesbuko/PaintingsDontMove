using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text score;
    public Text highscore;

    private void Start()
    {
        int score = PlayerPrefs.GetInt("score");
        int highscore = PlayerPrefs.GetInt("highscore");
        if(score >= highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
        this.score.text = score.ToString();
        this.highscore.text = highscore.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }


}
