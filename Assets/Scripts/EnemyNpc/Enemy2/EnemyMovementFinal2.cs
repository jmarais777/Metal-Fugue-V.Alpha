using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementFinal2 : MonoBehaviour
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

  
    public Transform PathP2;
    public Transform PathP3;

    public EnemyTriggEvents2 TriggEvent2;
    public EnemyPlayerDetecting2 Enemy_Player_Detetction2;
    public EnemySHootMech Enemy_Shoot_Mech;
    public Interact interact_;

    public Collider2D ForceField_Collider;
    public Collider2D Player_Detection_Collider;
    public enum EnemyMovementType
    {
        Pathfinding0,
        Pathfinding1,
        Pathfinding2,
        Pathfinding3,
        Chasing,
        Recalling,
        Recalling1,
        SystemFailure,
        FullDead,
    }
    public EnemyMovementType Move_Type;

    public void Start()
    {
        RigBod = GetComponent<Rigidbody2D>();
      Move_Type = EnemyMovementType.Pathfinding2;
    
    }


    public void FixedUpdate()
    {
        Debug.Log(Move_Type);
        switch (Move_Type)
        {
            case EnemyMovementType.Chasing: Chasing(); break;
            case EnemyMovementType.Recalling: Recalling(); break;
            case EnemyMovementType.Recalling1: Recall_Parent_One(); break;
            case EnemyMovementType.SystemFailure: System_Failure(); break;
            case EnemyMovementType.FullDead: FullDead(); break;
            case EnemyMovementType.Pathfinding2: Pathfinding2(); break;
            case EnemyMovementType.Pathfinding3: Pathfinding3(); break;
         
        }
    }

    public void Pathfinding2()
    {
        Vector3 Dir_PathP2 = (PathP2.position - transform.position).normalized;
        RigBod.linearVelocity = (Dir_PathP2 * Pathfinding_Speed);
        Debug.Log("Pathfiding1()");
    }
    public void Pathfinding3()
    {
        Vector3 Dir_PathP2 = (PathP3.position - transform.position).normalized;
        RigBod.linearVelocity = (Dir_PathP2 * Pathfinding_Speed);
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
        TriggEvent2.enabled = false;
        Enemy_Shoot_Mech.enabled = false;
        Enemy_Player_Detetction2.enabled = false;
        ForceField_Collider.enabled = false;
        Player_Detection_Collider.enabled = false;
    }
    public void FullDead()
    {
        transform.eulerAngles = new Vector3(0.0f, 0.0f, 59.19f);
        TriggEvent2.enabled = false;
        Enemy_Shoot_Mech.enabled = false;
        Enemy_Player_Detetction2.enabled = false;
        ForceField_Collider.enabled = false;
        Player_Detection_Collider.enabled = false;
        interact_.Enemies.Remove(transform);

    }



}











