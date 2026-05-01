using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

// Title:  MENU in Unity
// Author: Brackeys
// Date: 17 april 2026
// Code Version: 8.0
// Availability: https://www.youtube.com/watch?v=JivuXdrIHK0&t=1sPAUSE

public class PauseManager : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenu;
    public ShootMech shooting;
    public GameObject resume;
  

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
           
            

           
            if (Time.timeScale == 1.0f)
            {
                Time.timeScale = 0f;
            }
        }
      
        return;
    }

   /* public void ToggleMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;

       // pauseMenu.acti == true;
       // pauseMenu.SetActive(!isActive);


        
     
  

    }*/
}








