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
    public AudioSource Walking;
    public AudioSource Walking2;
   public AudioSource Dashing;
    private Vector2 moveInput;

    Vector2 movement;
    bool IsWalking = true;
    float dashSpeed = 40f;
    float dashDuration = 0.1f;
    float dashCooldown = 0.5f;
    public EnergyPool ForCurrentEnergy;

    public bool IsDashing;
    bool canDash = true;
    bool WalkF = true;
    bool WalkR = true;
    bool WalkB = true;
    bool WalkL = true;


    bool DashF = true;
    bool DashR = false;
    bool DashL = true;
    bool DashB = true;

  // public bool _inScrapyard;
    public enum WalkingSoundState
    {
        Walking,
        Walking2,
        HUSH,
    }
    public WalkingSoundState Walk_State;
    public GameObject ToShuttle;
    bool _hasDashed;

    void Start()
    {
        RigBod = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Walking = GetComponent<AudioSource>();
        Walking2 = GetComponent<AudioSource>();

       // _inScrapyard = true;
        _hasDashed = false;
        
    }



    void Update()
    {
        if (Input.GetKey(KeyCode.W) && Walk_State == WalkingSoundState.Walking2|| Input.GetKey(KeyCode.A) && Walk_State == WalkingSoundState.Walking2 || Input.GetKey(KeyCode.S) && Walk_State == WalkingSoundState.Walking2 || Input.GetKey(KeyCode.D) && Walk_State == WalkingSoundState.Walking2)
        {
            Walking2.mute = false;
        }
        else
        {
            Walking2.mute = true;
        }


        DashSound();
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

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
          
           Input.GetKey(KeyCode.Space);
            animator.SetBool("DashR", DashR);
          

        }
        else
        {
            animator.SetBool("WalkR", false);
            WalkR = false;
            animator.SetBool("DashR", false);
            DashR = false;

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
        /* if (Input.GetKey(KeyCode.W) && _inScrapyard == true || Input.GetKey(KeyCode.A) && _inScrapyard == true || Input.GetKey(KeyCode.S) && _inScrapyard == true || Input.GetKey(KeyCode.D) && _inScrapyard == true) 
         {
             Walking.mute = true;       
         }
         else
         {
             Walking.mute = false;
         }

         if (Input.GetKey(KeyCode.W) && _inScrapyard == false  || Input.GetKey(KeyCode.A) && _inScrapyard == false || Input.GetKey(KeyCode.S) && _inScrapyard == false || Input.GetKey(KeyCode.D) && _inScrapyard == false)
         {
             Walking2.mute = false;
         }
         else
         {
             Walking2.mute = true;
         }*/

        //mapping movement controls for dash
  

      
        
        if (IsDashing)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDash && ForCurrentEnergy.CurrentEnergy > 9 && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
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

        RigBod.linearVelocity = movement.normalized * MovementSpeed;
    }

    private IEnumerator Dash()
    {
        //establishing  dash velocity & cooldown
        canDash = false;
        IsDashing = true;
        RigBod.linearVelocity = movement.normalized * dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        IsDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }


    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "WalkCollider")
        {
            Walk_State = WalkingSoundState.Walking2;
        }
    }
    /*
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Walk2"))
        {
            _inScrapyard = false;

        }

        if (collider.gameObject.CompareTag("ToCryocombs"))
        {
            _inScrapyard = false;

        }

        if (collider.gameObject.CompareTag("FromShuttle"))
        {
            _inScrapyard = true;
        }

        if (collider.gameObject.CompareTag("FromCryocombs"))
        {
            _inScrapyard = true;
        }
    }*/

    public void DashSound()
    {
        if (IsDashing && !_hasDashed)
        {
            _hasDashed = true;
            Dashing.PlayOneShot(Dashing.clip);
        }

        if (!IsDashing)
        {
            _hasDashed = false;
        }
    } 

    }





