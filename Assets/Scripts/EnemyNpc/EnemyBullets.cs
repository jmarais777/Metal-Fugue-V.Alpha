
using Unity.Cinemachine;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class EnemyBullets : MonoBehaviour
{
    Rigidbody2D rb;
    //Speed setting
    public float LinearVelocity = 50.0f;
    //time setting for bullet destruction
    private float time = 1;
    



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //direction and speed of bullet once fired
        rb.linearVelocity = transform.up * LinearVelocity;
        //this destoryes the bullet after time has passed
        Destroy(gameObject, time);
        //test


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //destroys objects containing the "Obstacle" tag, on collision.
        if (collision.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Scrapheap"))
        {

            Destroy(gameObject);
        }
    }
}