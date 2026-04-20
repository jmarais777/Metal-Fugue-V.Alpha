using Unity.VisualScripting;
using UnityEngine;

//Title: Gameover screen in Unity
//Author: Coco Code
//Date: 20 April 2026
//Code Version: 9.0
//Availability:https://youtu.be/K4uOjb5p3Io
public class Gameoverscreen : MonoBehaviour
{
    public GameObject gameoverScreen;
    public float currentEnergy;

    void Start()
    {
        gameoverScreen.SetActive(false);
    }

    public void gameOver()
    {
        gameoverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    private float CurrentEnergy
    {
        get { return currentEnergy; }
        set
        {
            currentEnergy = value;
            if (currentEnergy <= 0)
            {
                gameOver();
            }
        }
    }
}



