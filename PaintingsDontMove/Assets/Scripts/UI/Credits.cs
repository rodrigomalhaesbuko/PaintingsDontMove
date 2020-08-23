using UnityEngine;
using UnityEngine.SceneManagement;


public class Credits : MonoBehaviour
{
    public void Back()
    {
        Debug.Log("Credits - Clicked Back Button");
        SceneManager.LoadScene("MainMenu");
    }
}
