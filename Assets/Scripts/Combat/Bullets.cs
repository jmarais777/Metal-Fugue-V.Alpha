
using System.Collections;
using Unity.Cinemachine;
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

        StartCoroutine(Self_Destruct_Timer());
       /* if (collision.gameObject.CompareTag("Scrapheap"))
        {

            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enviroment"))
        {  
            Destroy(gameObject); 
        }*/

    }
    public IEnumerator Self_Destruct_Timer()
    {
        yield return new WaitForSeconds(0.01f);
        Destroy(gameObject);
        yield return null;
    }

}