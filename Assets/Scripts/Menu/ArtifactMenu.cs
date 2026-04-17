using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Title: PAUSE MENU in Unity
// Author: Brackeys
// Date: 20 December 2017
// Code Version: 8.0
// Availability: https://www.youtube.com/watch?v=JivuXdrIHK0&t=1s

public class ArtifactMenu : MonoBehaviour
{
    public GameObject artifactMenu;
    private bool artifactMenuIsPaused = false;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleartifactMenu();
        }
    }

    public void ToggleartifactMenu()
    {
        bool isActive = artifactMenu.activeSelf;
        artifactMenu.SetActive(!isActive);


        if (Input.GetKeyDown(KeyCode.Tab))
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
