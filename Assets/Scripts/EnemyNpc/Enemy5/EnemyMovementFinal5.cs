using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementFinal5 : MonoBehaviour
{
    //THE MOVEMNET STUFF
    public Rigidbody2D RigBod;
    public ForceMode2D RecallForce;

    public float Follow_Speed = 5.0f;
    public float Pathfinding_Speed = 5.0f;


    public GameObject Player;
    public GameObject PlayerDetector;

    public Transform RecallStart;
    public Transform RecallP1;

    //Custom
    public Transform PathP8;
    public Transform PathP9;
    public Transform PathP10;
    public Transform PathP11;
    //Custom
    public EnemyTriggEvents5 TriggEvent5;
    public EnemyPlayerDetecting5 Enemy_Player_Detetction5;
    public EnemySHootMech Enemy_Shoot_Mech;

    public Interact interact_;
    public Collider2D ForceField_Collider;
    public Collider2D Player_Detection_Collider;
    public enum EnemyMovementType
    {

        Pathfinding8, //Custom
        Pathfinding9, //Custom
        Pathfinding10, //Custom
        Pathfinding11, // Custom
        Chasing,
        Recalling,
        Recalling1,
        SystemFailure,
        FullDead,
    }
    public EnemyMovementType Move_Type5; //Custom

    public void Start()
    {
        RigBod = GetComponent<Rigidbody2D>();
        Move_Type5 = EnemyMovementType.Pathfinding8; //CUstom
    }


    public void FixedUpdate()
    {
        Debug.Log(Move_Type5); //custom
        switch (Move_Type5) //custom
        {
            case EnemyMovementType.Chasing: Chasing(); break;
            case EnemyMovementType.Recalling: Recalling(); break;
            case EnemyMovementType.Recalling1: Recall_Parent_One(); break;
            case EnemyMovementType.SystemFailure: System_Failure(); break;
            case EnemyMovementType.FullDead: FullDead(); break;
            //custom
            case EnemyMovementType.Pathfinding8: Pathfinding8(); break;
            case EnemyMovementType.Pathfinding9: Pathfinding9(); break;
            case EnemyMovementType.Pathfinding10: Pathfinding10(); break;
            case EnemyMovementType.Pathfinding11: Pathfinding11(); break;

        }
    }

    public void Pathfinding8() //custom
    {
        Vector3 Dir_PathP8 = (PathP8.position - transform.position).normalized;
        RigBod.linearVelocity = (Dir_PathP8 * Pathfinding_Speed);
        Debug.Log("Pathfiding1()");
    }
    public void Pathfinding9() //custom
    {
        Vector3 Dir_PathP9 = (PathP9.position - transform.position).normalized;
        RigBod.linearVelocity = (Dir_PathP9 * Pathfinding_Speed);
        Debug.Log("Pathfinding2()");
    }
    public void Pathfinding10() //custom
    {
        Vector3 Dir_PathP10 = (PathP10.position - transform.position).normalized;
        RigBod.linearVelocity = (Dir_PathP10 * Pathfinding_Speed);
        Debug.Log("Pathfinding2()");
    }
    public void Pathfinding11() //custom
    {
        Vector3 Dir_PathP11 = (PathP11.position - transform.position).normalized;
        RigBod.linearVelocity = (Dir_PathP11 * Pathfinding_Speed);
        Debug.Log("Pathfinding2()");
    }
    public void Chasing()
    {
        Vector3 Direction_To_Player = (Player.transform.position - transform.position).normalized;
        RigBod.linearVelocity = (Direction_To_Player * Follow_Speed);
        Enemy_Shoot_Mech.enabled = true;
        Debug.Log("Chasing()");
    }
    public void Recalling()
    {
        RecallForce = ForceMode2D.Impulse;
        Vector3 Direction_To_RecallStart = (RecallStart.position - transform.position).normalized;
        RigBod.AddForce(Direction_To_RecallStart, ForceMode2D.Impulse);
        Debug.Log("Recalling()");
    }
    public void Recall_Parent_One()
    {
        RecallForce = ForceMode2D.Impulse;
        Vector3 Direction_To_RecallP1 = (RecallP1.position - transform.position).normalized;
        RigBod.AddForce(Direction_To_RecallP1, ForceMode2D.Impulse);
        Debug.Log("RecallingP1()");
    }
    public void System_Failure() //set in EnemyHealth Script
    {
        transform.eulerAngles = new Vector3(0.0f, 0.0f, 59.19f);
        TriggEvent5.enabled = false; //custom
        Enemy_Shoot_Mech.enabled = false;
        Enemy_Player_Detetction5.enabled = false; //custom
        ForceField_Collider.enabled = false;
        Player_Detection_Collider.enabled = false;
    }
    public void FullDead()
    {
        transform.eulerAngles = new Vector3(0.0f, 0.0f, 59.19f);
        TriggEvent5.enabled = false; //custom
        Enemy_Shoot_Mech.enabled = false;
        Enemy_Player_Detetction5.enabled = false; //custom
        ForceField_Collider.enabled = false;
        Player_Detection_Collider.enabled = false;
        interact_.Enemies.Remove(transform);

    }



}











