
using Unity.Cinemachine;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    //Speed setting
    public float LinearVelocity = 50.0f;
    //time setting for bullet destruction
   // private float time = 1;
   




    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        
 
        rb.linearVelocity = transform.up * LinearVelocity;
    


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      
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