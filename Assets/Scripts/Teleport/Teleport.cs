using Unity.VisualScripting;
using UnityEngine;

//Teleporter between Cryocombs Rooms
//Title: Making a 2D Platformer In Unity 6 - Episode 36 (Simple Teleporter)
//Author: Unity Unlocked
//Date: 06/04/2026
//Availability: https://www.youtube.com/watch?v=ucqDDUSMuiY

public class Teleport : MonoBehaviour
{
    public Transform destination;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //call Player tag, Rigidbody attatched to it moves to the destination

        if (collision.CompareTag("Player") )
        {
          
            collision.attachedRigidbody.position = destination.position;
          
          
        }
  

    }
}