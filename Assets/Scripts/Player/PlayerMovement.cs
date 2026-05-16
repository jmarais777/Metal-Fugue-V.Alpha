using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using Animator = UnityEngine.Animator;
using JetBrains.Annotations;

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
    private AudioSource Walking;
    private Vector2 moveInput;

    Vector2 movement;
    bool IsWalking = true;
    float dashSpeed = 20f;
    float dashDuration = 0.1f;
    float dashCooldown = 0.5f;
    public bool IsDashing;
    bool canDash = true;
    bool WalkF = true;
    bool WalkR = true;
    bool WalkB = true;
    bool WalkL = true;

    void Start()
    {
        RigBod = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Walking = GetComponent<AudioSource>();
        
    }



    void Update()


    {
        RigBod.linearVelocity = moveInput * MovementSpeed;

        //Checking WASD for Animator

        /* if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))

         {
             animator.SetBool("IsWalking", IsWalking);
             //IsWalking = true;
         }
         else
             { animator.SetBool("IsWalking", false); } */

        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("WalkF", WalkF);
            WalkF = true;
           
        }
        else
        {
            animator.SetBool("WalkF", false);
            WalkF = false;
          
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("WalkR", WalkR);
            WalkR = true;
        
        }
        else
        {
            animator.SetBool("WalkR", false);
            WalkR = false;
          
        }
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("WalkB", WalkB);
            WalkB = true;
            
        }
        else
        {
            animator.SetBool("WalkB", false);
            WalkB = false;
          
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("WalkL", WalkL);
            WalkL = true;
           
        }
        else
        {
            animator.SetBool("WalkL", false);
            WalkL = false;
     
        }
        //Sound Conditions
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            Walking.mute = false;       
        }
        else
        {
            Walking.mute = true;
        }

            //mapping movement controls for dash
            if (IsDashing)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
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




