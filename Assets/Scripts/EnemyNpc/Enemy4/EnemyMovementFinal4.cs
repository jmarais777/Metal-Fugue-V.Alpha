using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementFinal4 : MonoBehaviour
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
    public Transform PathP6;
    public Transform PathP7;
    //Custom
    public EnemyTriggEvents4 TriggEvent4;
    public EnemyPlayerDetecting4 Enemy_Player_Detetction4;
    public EnemySHootMech Enemy_Shoot_Mech;
    
    public Interact interact_;
    public Collider2D ForceField_Collider;
    public Collider2D Player_Detection_Collider;
    public enum EnemyMovementType
    {

        Pathfinding6, //Custom
        Pathfinding7, //Custom
        Chasing,
        Recalling,
        Recalling1,
        SystemFailure,
        FullDead,
    }
    public EnemyMovementType Move_Type4; //Custom

    public void Start()
    {
        RigBod = GetComponent<Rigidbody2D>();
        Move_Type4 = EnemyMovementType.Pathfinding6; //CUstom
    }


    public void FixedUpdate()
    {
        Debug.Log(Move_Type4); //custom
        switch (Move_Type4) //custom
        {
            case EnemyMovementType.Chasing: Chasing(); break;
            case EnemyMovementType.Recalling: Recalling(); break;
            case EnemyMovementType.Recalling1: Recall_Parent_One(); break;
            case EnemyMovementType.SystemFailure: System_Failure(); break;
            case EnemyMovementType.FullDead: FullDead(); break;
            //custom
            case EnemyMovementType.Pathfinding6: Pathfinding6(); break;
            case EnemyMovementType.Pathfinding7: Pathfinding7(); break;

        }
    }

    public void Pathfinding6() //custom
    {
        Vector3 Dir_PathP6 = (PathP6.position - transform.position).normalized;
        RigBod.linearVelocity = (Dir_PathP6 * Pathfinding_Speed);
        Debug.Log("Pathfiding1()");
    }
    public void Pathfinding7() //custom
    {
        Vector3 Dir_PathP7 = (PathP7.position - transform.position).normalized;
        RigBod.linearVelocity = (Dir_PathP7 * Pathfinding_Speed);
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
        TriggEvent4.enabled = false; //custom
        Enemy_Shoot_Mech.enabled = false;
        Enemy_Player_Detetction4.enabled = false; //custom
        ForceField_Collider.enabled = false;
        Player_Detection_Collider.enabled = false;
    }
    public void FullDead()
    {
        transform.eulerAngles = new Vector3(0.0f, 0.0f, 59.19f);
        TriggEvent4.enabled = false; //custom
        Enemy_Shoot_Mech.enabled = false;
        Enemy_Player_Detetction4.enabled = false; //custom
        ForceField_Collider.enabled = false;
        Player_Detection_Collider.enabled = false;
        interact_.Enemies.Remove(transform);

    }



}











