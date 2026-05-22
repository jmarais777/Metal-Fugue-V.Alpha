using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementFinal7 : MonoBehaviour
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
    public Transform PathP16;
    public Transform PathP17;
    //Custom
    public EnemyTriggEvents7 TriggEvent7;
    public EnemyPlayerDetecting7 Enemy_Player_Detetction7;
    public EnemySHootMech Enemy_Shoot_Mech;
    
    public Interact interact_;
    public Collider2D ForceField_Collider;
    public Collider2D Player_Detection_Collider;
    public enum EnemyMovementType
    {

        Pathfinding16, //Custom
        Pathfinding17, //Custom
        Chasing,
        Recalling,
        Recalling1,
        SystemFailure,
        FullDead,
    }
    public EnemyMovementType Move_Type7; //Custom

    public void Start()
    {
        RigBod = GetComponent<Rigidbody2D>();
        Move_Type7 = EnemyMovementType.Pathfinding16; //CUstom
    }


    public void FixedUpdate()
    {
        Debug.Log(Move_Type7); //custom
        switch (Move_Type7) //custom
        {
            case EnemyMovementType.Chasing: Chasing(); break;
            case EnemyMovementType.Recalling: Recalling(); break;
            case EnemyMovementType.Recalling1: Recall_Parent_One(); break;
            case EnemyMovementType.SystemFailure: System_Failure(); break;
            case EnemyMovementType.FullDead: FullDead(); break;
            //custom
            case EnemyMovementType.Pathfinding16: Pathfinding16(); break;
            case EnemyMovementType.Pathfinding17: Pathfinding17(); break;

        }
    }

    public void Pathfinding16() //custom
    {
        Vector3 Dir_PathP16 = (PathP16.position - transform.position).normalized;
        RigBod.linearVelocity = (Dir_PathP16 * Pathfinding_Speed);
        Debug.Log("Pathfiding1()");
    }
    public void Pathfinding17() //custom
    {
        Vector3 Dir_PathP17 = (PathP17.position - transform.position).normalized;
        RigBod.linearVelocity = (Dir_PathP17 * Pathfinding_Speed);
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
        TriggEvent7.enabled = false; //custom
        Enemy_Shoot_Mech.enabled = false;
        Enemy_Player_Detetction7.enabled = false; //custom
        ForceField_Collider.enabled = false;
        Player_Detection_Collider.enabled = false;
    }
    public void FullDead()
    {
        transform.eulerAngles = new Vector3(0.0f, 0.0f, 59.19f);
        TriggEvent7.enabled = false; //custom
        Enemy_Shoot_Mech.enabled = false;
        Enemy_Player_Detetction7.enabled = false; //custom
        ForceField_Collider.enabled = false;
        Player_Detection_Collider.enabled = false;
        interact_.Enemies.Remove(transform);

    }



}











