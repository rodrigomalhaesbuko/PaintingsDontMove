using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;

    public void Play()
    {
        Debug.Log("Welcome - Clicked Play Button");
        SceneManager.LoadScene("Main");
    }

    public void Credits()
    {
        Debug.Log("Welcome - Clicked Credits Button");
        SceneManager.LoadScene("Credits");
    }
}
