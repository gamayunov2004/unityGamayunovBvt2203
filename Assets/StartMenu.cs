using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenOptions()
    {
        Debug.Log("options");
    }



    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
