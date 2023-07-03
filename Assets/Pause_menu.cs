using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_menu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject canvas;
    public GameObject loseText;
    public Weapon playerWeapon;

    void Awake()
    {
        //playerWeapon = GetComponent<Weapon>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
            
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;

        canvas.SetActive(true);
        loseText.SetActive(true);

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audio in audios)
        {
            audio.UnPause();
        }

        //playerWeapon.enabled = true;
        playerWeapon.GetComponent<Weapon>().enabled = true;

        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        canvas.SetActive(false);
        loseText.SetActive(false);

        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        
        foreach (AudioSource audio in audios)
        {
            audio.Pause();
        }

        playerWeapon.GetComponent<Weapon>().enabled = false;

        GameIsPaused = true;
    }

    public void OpenOptions()
    {
        Debug.Log("options");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
