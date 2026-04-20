
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class EnemyBullets : MonoBehaviour
{
    Rigidbody2D RigBod;
    //Speed setting
    public float LinearVelocity = 50.0f;
    //time setting for bullet destruction
    private float time = 1;
   
    public EnergyPool ForCurrentEnergy;
 



    void Start()
    {
        RigBod = GetComponent<Rigidbody2D>();
        //direction and speed of bullet once fired
        RigBod.linearVelocity = transform.up * LinearVelocity;
        //this destoryes the bullet after time has passed
        Destroy(gameObject, time);
        //test
     

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        //destroys objects containing the "Obstacle" tag, on collision.
        if (collision.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Scrapheap"))
        {

            
        }
       
    }
}