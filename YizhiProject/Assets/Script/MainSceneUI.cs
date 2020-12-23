using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneUI : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Application.Quit();
    }
}
