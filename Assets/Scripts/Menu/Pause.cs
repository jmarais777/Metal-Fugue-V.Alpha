using Unity.VisualScripting;
using UnityEngine;

// Title: PAUSE MENU in Unity
// Author: Brackeys
// Date: 20 December 2017
// Code Version: 8.0
// Availability: https://www.youtube.com/watch?v=JivuXdrIHK0&t=1s

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused = false;

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        bool isActive = pauseMenu.activeSelf;
        pauseMenu.SetActive(!isActive);


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            return;
        }
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }

    }
}








