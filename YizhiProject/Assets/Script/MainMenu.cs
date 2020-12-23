using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // called when StartButton pressed
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // called when ExitButton pressed
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        Application.Quit();
    }

    // called when CreditButton pressed
    public void Credit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
