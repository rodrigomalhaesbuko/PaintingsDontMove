using UnityEngine;
using UnityEngine.SceneManagement;


public class Credits : MonoBehaviour
{

    private void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
