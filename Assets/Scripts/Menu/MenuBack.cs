using UnityEngine;
using UnityEngine.SceneManagement;

//Title: Gameover screen in Unity
//Author: Coco Code
//Date: 20 April 2026
//Code Version: 9.0
//Availability:https://youtu.be/K4uOjb5p3Io

public class MenuBack : MonoBehaviour
{
    public void GoToMainMenu()
    {
      
        SceneManager.LoadScene("MainMenu");
     
    }
}

