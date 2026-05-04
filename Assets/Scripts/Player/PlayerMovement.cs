using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

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
<<<<<<< HEAD
    



=======
    private Animator animator;
    private Vector2 moveInput;
>>>>>>> 7527c3f8dd37d3056d7be23ec90369cb2f545b13
    Vector2 movement;
    private Vector2 moveInput;
    private Animator animator; 

    float dashSpeed = 20f;
    float dashDuration = 0.1f;
    float dashCooldown = 0.5f;
    public bool IsDashing;
    bool canDash = true;
<<<<<<< HEAD
   bool IsWalking = false;

    void Start()
    {
      RigBod = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

 void Update()
=======
    public bool isWalking;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Move(InputAction.CallbackContext context)
    {
       animator.SetBool("IsWalking", true);

        if (context.canceled)
        {
            animator.SetBool("IsWalking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }
        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", moveInput.x);
            animator.SetFloat("InputY", moveInput.y);
    }
    void Update()
>>>>>>> 7527c3f8dd37d3056d7be23ec90369cb2f545b13
    
    {

       IsWalking = false;
        //Checking WASD for Animator

        if (Input.GetKey(KeyCode.W))

        {

            IsWalking = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            isWalking = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            isWalking = true;
        }
<<<<<<< HEAD
        else if (Input.GetKey(KeyCode.D))
=======
        if (Input.GetKey(KeyCode.A))
        {
            isWalking = true;
        }
        if (Input.GetKey(KeyCode.D))
>>>>>>> 7527c3f8dd37d3056d7be23ec90369cb2f545b13
        {
            isWalking = true;
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
        animator.SetBool("IsWalking", IsWalking);

    }
    public void Move(InputAction.CallbackContext context)
    {
      animator.SetBool("IsWalking", true);

        if (context.canceled)
        {
            animator.SetBool("IsWalking", false);
            animator.SetFloat("LastInputX", movement.x);
            animator.SetFloat("LastInputY", movement.y);
        }
         
        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
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
