using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleport : MonoBehaviour
{

    //Title: Unity 2D Platformer Tutorial 21 - Level management and teleporting between scenes
    //Author: Daniel Wood
    //Date: 17/04/2026
    //Availability: https://www.youtube.com/watch?v=ILUbcxfvEMk
   
    //Loading scenes on collider trigger by changing active scene
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ToCryocombs")
        {
            SceneManager.sceneLoaded += MovePlayerToCryoEntrance;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (collision.tag == "FromCryocombs")
        {
            SceneManager.sceneLoaded += MovePlayerToFromCryo;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    //moves player to entrance of cryocombs, after the scene has loaded    
    private void MovePlayerToCryoEntrance(Scene scene, LoadSceneMode mode)
    {
        GameObject cryoEntrance = GameObject.Find("CryoEntrance");

        if (cryoEntrance != null)
        {
            transform.position = cryoEntrance.transform.position;
        }

        SceneManager.sceneLoaded -= MovePlayerToCryoEntrance;
    }

    //moves player to the exterior of the cryocombs, after the scene has loaded
    private void MovePlayerToFromCryo(Scene scene, LoadSceneMode mode)
    {
        GameObject fromCryoSpawn = GameObject.Find("FromCryo");

        if (fromCryoSpawn != null)
        {
            transform.position = fromCryoSpawn.transform.position;
        }

        SceneManager.sceneLoaded -= MovePlayerToFromCryo;
    }
}

