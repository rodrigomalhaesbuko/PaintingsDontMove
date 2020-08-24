using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;

    private void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
