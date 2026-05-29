using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyMovementFinalFin8 : MonoBehaviour
{
    //THE MOVEMNET STUFF
    public Rigidbody2D RigBod;

    public float Velocity_Constant = 0.01f;

    public ForceMode2D RecallForce;

    public float Follow_Speed = 5.0f;
    public float Pathfinding_Speed = 5.0f;

    public Light2D Enem_Detection_Light;

    public GameObject Player;
    public GameObject PlayerDetector;

    public Transform RecallStart;
    public Transform RecallP1;

    public Enemy_Trigger_EventsFin8 TriggEventFin2;
    public EnemyPlayerDetectingFin8 Enemy_Player_Detetction;
    public EnemySHootMech Enemy_Shoot_Mech;
    public Interact interact_;

    public Collider2D ForceField_Collider;
    public Collider2D Player_Detection_Collider;

    public Animator Enemy_Animator;
    public bool isWalkingF = false;
    public bool isWalkingR = false;
    public  bool isWalkingB = false;
    public bool isWalkingL = false;

    public enum EnemyMovementType
    {
        Chasing,
        Recalling,
        Recalling1,
        SystemFailure,
        FullDead,
        DeepSleep,
        //ADD NEW
        Damage,
    }
    public EnemyMovementType Move_Type;

    public void Start()
    {
       RigBod = GetComponent<Rigidbody2D>();
       Move_Type = EnemyMovementType.Chasing;

      
    }    
public void FixedUpdate()
    {
        float Absolute_Lin_X = Mathf.Abs(RigBod.linearVelocityX);
        float Absolute_Lin_Y = Mathf.Abs(RigBod.linearVelocityY);

        switch (RigBod.linearVelocityY)
        {
            case < 0:
                isWalkingB = false;
                isWalkingF = true;
                
            break;
            case > 0:
                isWalkingB = true;
                isWalkingF = false;
                break;
            
        }
        switch (RigBod.linearVelocityX)
        {
            case < 0:
                isWalkingL = true;
                isWalkingR = false;
            break;
            case > 0:
                isWalkingL = false;
                isWalkingR = true;
            break;
        }
        if (Absolute_Lin_X < Absolute_Lin_Y)
        {
            Debug.Log("+LinX < +LinY");
            isWalkingR = false;

        }
        else if (Absolute_Lin_X > Absolute_Lin_Y)
        {
            Debug.Log("+LinX > +LinY");
            isWalkingF = false;
        }
        if (-Absolute_Lin_X < -Absolute_Lin_Y)
        {
            Debug.Log("-LinX < -LinY");
            isWalkingB = false;
        }
        else if (-Absolute_Lin_X > -Absolute_Lin_Y)
        {
            Debug.Log("-LinX > -LinY");
            isWalkingL = false;
        }

        if (isWalkingF == true)
        {
            Enemy_Animator.SetBool("isWalkingF", isWalkingF);
        }
        else if (isWalkingF == false)
        {
            Enemy_Animator.SetBool("isWalkingF", false);
        }

        if (isWalkingB == true)
        {
            Enemy_Animator.SetBool("isWalkingB", isWalkingB);
        }
        else if (isWalkingB == false)
        {
            Enemy_Animator.SetBool("isWalkingB", false);
        }

        if (isWalkingR == true)
        {
            Enemy_Animator.SetBool("isWalkingR", isWalkingR);
        }
        else if (isWalkingR == false)
        {
            Enemy_Animator.SetBool("isWalkingR", false);
        }

        if (isWalkingL == true)
        {
            Enemy_Animator.SetBool("isWalkingL", isWalkingL);
        }
        else if (isWalkingL == false)
        {
            Enemy_Animator.SetBool("isWalkingL", false);
        }



        Debug.Log(Move_Type);
        switch (Move_Type)
        {
            case EnemyMovementType.Chasing: Chasing(); break;
            case EnemyMovementType.Recalling: Recalling(); break;
            case EnemyMovementType.Recalling1: Recall_Parent_One(); break;
            case EnemyMovementType.FullDead: FullDead(); break;
            case EnemyMovementType.DeepSleep: DeepSleep(); break;
            //ADD NEW (DELETE SYSTEM FAILURE ABOVE)
            case EnemyMovementType.SystemFailure: StartCoroutine(SystemFailureTimer3()); break;
            case EnemyMovementType.Damage: StartCoroutine(DamageEffect1()); break;
        }
    }
    //ADDD NEWW
    IEnumerator DamageEffect1()
    {
        Enem_Detection_Light.blendStyleIndex = 1;
        Enem_Detection_Light.intensity = 0.9f;
        Enem_Detection_Light.pointLightInnerRadius = 1.0f;
        Enem_Detection_Light.pointLightOuterRadius = 38f;
        Enem_Detection_Light.falloffIntensity = 1.0f;
        yield return new WaitForSeconds(0.1f);
        Move_Type = EnemyMovementType.Chasing;

    }
    public IEnumerator SystemFailureTimer3()
    {
        transform.eulerAngles = new Vector3(0.0f, 0.0f, 59.19f);
        TriggEventFin2.enabled = false;
        Enemy_Shoot_Mech.enabled = false;
        //Enemy_Player_Detetction.enabled = false;
        ForceField_Collider.enabled = false;
        Player_Detection_Collider.enabled = false;
        RigBod.mass = 50f;
        // RigBod.linearVelocity = Vector2.zero;
        Enem_Detection_Light.blendStyleIndex = 1;
        Enem_Detection_Light.pointLightInnerRadius = 15.13f;
        Enem_Detection_Light.pointLightOuterRadius = 75.46f;
        Enem_Detection_Light.intensity = 0.37f;
        yield return new WaitForSeconds(0.1f);
        Enem_Detection_Light.intensity = 1f;
        yield return new WaitForSeconds(0.1f);
        Enem_Detection_Light.intensity = 2f;
        this.gameObject.SetActive(false);
        yield return null;
    }
    //NEW END
    public void Chasing()
    {
        Vector3 Direction_To_Player = (Player.transform.position - transform.position).normalized;
        RigBod.linearVelocity = (Direction_To_Player * Follow_Speed);

        TriggEventFin2.enabled = true; //custom
        Enemy_Shoot_Mech.enabled = true;
        Enemy_Player_Detetction.enabled = true; //custom
        ForceField_Collider.enabled = true;
        Player_Detection_Collider.enabled = true;
        Debug.Log("Chasing()");

    }
    public void Recalling()
    {    
        RecallForce = ForceMode2D.Impulse;
        Vector3 Direction_To_RecallStart = (RecallStart.position - transform.position).normalized;
        RigBod.AddForce(Direction_To_RecallStart, ForceMode2D.Impulse);
        Debug.Log("Recalling()");
        TriggEventFin2.enabled = true; //custom
        Enemy_Shoot_Mech.enabled = true;
        Enemy_Player_Detetction.enabled = true; //custom
        ForceField_Collider.enabled = true;
        Player_Detection_Collider.enabled = true;
    }
    public void Recall_Parent_One()
    {
        RecallForce = ForceMode2D.Impulse;
        Vector3 Direction_To_RecallP1 = (RecallP1.position - transform.position ).normalized;
        RigBod.AddForce(Direction_To_RecallP1, ForceMode2D.Impulse);
        Debug.Log("RecallingP1()");
    }
    public void System_Failure() //set in EnemyHealth Script
    {
        transform.eulerAngles = new Vector3(0.0f, 0.0f, 59.19f);
        TriggEventFin2.enabled = false;
        Enemy_Shoot_Mech.enabled = false;
        //Enemy_Player_Detetction.enabled = false;
        ForceField_Collider.enabled = false;
        Player_Detection_Collider.enabled = false;
        RigBod.linearVelocity = Vector2.zero;
}
    public void FullDead()
    {
        transform.eulerAngles = new Vector3(0.0f, 0.0f, 59.19f);
        TriggEventFin2.enabled = false;
        Enemy_Shoot_Mech.enabled = false;
        Enemy_Player_Detetction.enabled = false;
        ForceField_Collider.enabled = false;
        Player_Detection_Collider.enabled = false;
        Enem_Detection_Light.enabled = false;
        interact_.Enemies.Remove(transform);
        
    }
    public void DeepSleep()
    {
        TriggEventFin2.enabled = false; //custom
        Enemy_Shoot_Mech.enabled = false;
        Enemy_Player_Detetction.enabled = false; //custom
        RigBod.linearVelocity = Vector2.zero;
        interact_.Enemies.Remove(transform);
        Enem_Detection_Light.intensity = 0.0f;
        ForceField_Collider.enabled = false;
        Player_Detection_Collider.enabled = false;

    }



}











