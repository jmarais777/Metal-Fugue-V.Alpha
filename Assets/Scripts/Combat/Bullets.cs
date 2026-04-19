
using Unity.Cinemachine;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Bullet : MonoBehaviour
{
    Rigidbody2D RigBod;
    //Speed setting
    public float LinearVelocity = 50.0f;
    //time setting for bullet destruction
   // private float time = 1;
   




    

    void Start()
    {
        RigBod = GetComponent<Rigidbody2D>();

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());


        RigBod.linearVelocity = transform.up * LinearVelocity;
    


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
      
        if (collision.gameObject.CompareTag("Obstacles") && CompareTag("Scrapheap"))
        {

            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enviroment"))
        {  
            Destroy(this.gameObject); 
        }


      




    }
    
}