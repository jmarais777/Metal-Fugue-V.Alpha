using Unity.VisualScripting;
using UnityEngine;

//Teleporter between Cryocombs Rooms
//Title: Making a 2D Platformer In Unity 6 - Episode 36 (Simple Teleporter)
//Author: Unity Unlocked
//Date: 06/04/2026
//Availability: https://www.youtube.com/watch?v=ucqDDUSMuiY

public class ShuttleTeleport : MonoBehaviour
{

    public GameObject player;

    public Transform destination;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //call Player tag, Rigidbody attatched to it moves to the destination
        Debug.Log("Colliding with: " + collision.name);
        if (collision.CompareTag("Player"))
        {
            player.transform.position = destination.position;
            Debug.Log("playerrreg");
        }


    }
}