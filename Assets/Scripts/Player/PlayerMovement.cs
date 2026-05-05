using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using Animator = UnityEngine.Animator;

public class PlayerMovement : MonoBehaviour
{
   
    //Basic Player Movement
    //Title: Top Down Movement In UNITY 6
    //Author: Unity Unlocked
    //Date: 02/04/2026
    //Availability: https://www.youtube.com/watch?v=Rs8Wy9jH8iA

    //Player Dash
    //Title: Simple DASH Mechanic in Unity
    //Author: BMo
    //Date: 03/04/2026
    //Availability: https://www.youtube.com/watch?v=VWaiU7W5HdE

    public float MovementSpeed = 5f;
    public Rigidbody2D RigBod;

   private Animator animator;
    private Vector2 moveInput;

    Vector2 movement;
    
    float dashSpeed = 20f;
    float dashDuration = 0.1f;
    float dashCooldown = 0.5f;
    public bool IsDashing;
    bool canDash = true;

   bool IsWalking = false;

    void Start()
    {
      RigBod = GetComponent<Rigidbody2D>();
     
    }


   
    void Update()

    
    {

       IsWalking = false;
        //Checking WASD for Animator

        if (Input.GetKey(KeyCode.W))

        {

            IsWalking = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            IsWalking = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            IsWalking = true;
        }

        else if (Input.GetKey(KeyCode.D))

        if (Input.GetKey(KeyCode.A))
        {
            IsWalking = true;
        }
        if (Input.GetKey(KeyCode.D))

        {
            IsWalking = true;
        }


        //mapping movement controls for dash
        if (IsDashing)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
        

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
       
    }
   


    private void FixedUpdate()
    {
       //defining dash position shift
        if (IsDashing)
        {
            return;
        }

        RigBod.MovePosition(RigBod.position + movement.normalized * MovementSpeed * Time.deltaTime);
    }

    private IEnumerator Dash()
    {
        //establishing  dash velocity & cooldown
        canDash = false;
        IsDashing = true;
        RigBod.linearVelocity = new Vector2(movement.x * dashSpeed, movement.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        IsDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
