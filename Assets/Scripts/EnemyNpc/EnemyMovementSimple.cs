using JetBrains.Annotations;
using UnityEngine;

public class EnemyMovementFinal :  MonoBehaviour
{
    //THE MOVEMNET STUFF
    public Rigidbody2D RigBod;
    public ForceMode2D RecallForce;

    public float Follow_Speed = 5.0f;
    public float Pathfinding_Speed = 5.0f;


    public GameObject Player;

    public Transform RecallStart;
    public Transform RecallP1;

    public Transform PathP1;
    public Transform PathP2;

    private Enemy_Trigger_Events TriggEvent;

 public enum MovementType
    {
        Pathfinding1,
        Pathfinding2,
        Chasing,
        Recalling,
        Recalling1,
    }
    public MovementType Move_Type;

    public void Start()
    {
       RigBod = GetComponent<Rigidbody2D>();
       Move_Type = MovementType.Pathfinding1;
     TriggEvent = GetComponent<Enemy_Trigger_Events>();
       TriggEvent.Movefin = this;
    }
    
    public void FixedUpdate()
    {
        Debug.Log("Current State: " + Move_Type);
        switch (Move_Type)
         {
           case MovementType.Pathfinding1:
           Pathfinding1();
           break;

           case MovementType.Pathfinding2:
            Pathfinding2();
           break;

           case MovementType.Chasing:
            Chasing();
           break;

           case MovementType.Recalling:
            Recalling();
           break;

           case MovementType.Recalling1:
            Recall_Parent_One();
           break;                    
         }
    }

    public void Pathfinding1()
    {
        Vector3 Dir_PathP1 = (PathP1.position - transform.position).normalized;
        RigBod.linearVelocity = (Dir_PathP1 * Pathfinding_Speed);
        Debug.Log("Pathfiding1()");
    }
    public void Pathfinding2()
    {
        Vector3 Dir_PathP2 = (PathP2.position - transform.position).normalized;
        RigBod.linearVelocity = (Dir_PathP2 * Pathfinding_Speed);
        Debug.Log("Pathfinding2()");

    }
    public void Chasing()
    {
        Vector3 Direction_To_Player = (Player.transform.position - transform.position).normalized;
        RigBod.linearVelocity = (Direction_To_Player * Follow_Speed);
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
        Vector3 Direction_To_RecallP1 = (RecallP1.position - transform.position ).normalized;
        RigBod.AddForce(Direction_To_RecallP1, ForceMode2D.Impulse);
        Debug.Log("RecallingP1()");

    }
}











