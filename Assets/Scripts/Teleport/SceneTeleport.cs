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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Debug.Log("Registers");

        }
        else if (collision.tag == "FromCryocombs")
        {
            SceneManager.sceneLoaded += MovePlayerToFromCryo;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (collision.tag == "ToShuttle")
        {
            SceneManager.sceneLoaded += MovePlayerToShuttleEntrance;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

        }
        else if (collision.tag == "FromShuttle")
        {
            SceneManager.sceneLoaded += MovePlayerToFromShuttle;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        

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

    //moves player to the entrance of the shuttle, after the scene has loaded    
    private void MovePlayerToShuttleEntrance(Scene scene, LoadSceneMode mode)
    {
        GameObject shuttleEntrance = GameObject.Find("ShuttleEntrance");

        if (shuttleEntrance != null)
        {
            transform.position = shuttleEntrance.transform.position;
        }

        SceneManager.sceneLoaded -= MovePlayerToShuttleEntrance;
    }

    //moves player to the exterior of the shuttle, after the scene has loaded
    private void MovePlayerToFromShuttle(Scene scene, LoadSceneMode mode)
    {
        GameObject fromShuttleSpawn = GameObject.Find("FromShuttle");

        if (fromShuttleSpawn != null)
        {
            transform.position = fromShuttleSpawn.transform.position;
         
        }

        SceneManager.sceneLoaded -= MovePlayerToFromShuttle;
    


    }
}

