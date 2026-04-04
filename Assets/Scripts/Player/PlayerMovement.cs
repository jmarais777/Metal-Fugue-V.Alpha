using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    //Basic Player Movement
    //Title: Top Down Movement In UNITY 6
    //Author: Unity Unlocked
    //Date: 02/04/2026
    //Availiability: https://www.youtube.com/watch?v=Rs8Wy9jH8iA

    //Player Dash
    //Title: Simple DASH Mechanic in Unity
    //Author: BMo
    //Date: 03/04/2026
    //Availiability: https://www.youtube.com/watch?v=VWaiU7W5HdE

    public float movementSpeed = 5f;
    public Rigidbody2D rigBod;
    Vector2 movement;

    float dashSpeed = 20f;
    float dashDuration = 0.1f;
    float dashCooldown = 0.5f;
    bool isDashing;
    bool canDash = true;
    void Update()
    {
       if (isDashing)
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
        if (isDashing)
        {
            return;
        }

        rigBod.MovePosition(rigBod.position + movement.normalized * movementSpeed * Time.deltaTime);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rigBod.linearVelocity = new Vector2(movement.x * dashSpeed, movement.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
