using JetBrains.Annotations;
using Unity.VisualScripting;
#if UNITY_EDITOR
using UnityEditor.Experimental.GraphView;
#endif
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static EnemyRecallSelectors;


public class EnemyMovementRev : MonoBehaviour
{
    //Main Game Objects
    public GameObject EnemyNPC;
    public GameObject Player;

    //Recall Positions
    public Transform recallStart;
    public Transform recallP1;
    public Transform recallP2;
   

    //Triggers:
    public GameObject PlayerRadius;
    public GameObject EnemySensor;

    //Speed Controls
    public float MoveSpeed = 10.0f;
    public float repulsion = 10.0f;
    public float recallingSpeed = 10.0f;

    //Looping Conditions
    public bool IsFollowing = true;
    public int RecallPos = -1;

    //collisionCTRL
    public GameObject Scrapheap;
    public bool EnemyRepos = true;
    public Rigidbody2D RigBod;

    //pathfinding
    public Transform PathPoint1;
    public Transform PathPoint2;
    public float patrollSpeed = 4.0f;
    public int path = 0;

    public Transform repositioner;
   /*
    public Transform mainHeap1;
    public Transform mainHeap2;
    public Transform MainHeap3;
    public Transform MainHeap4;
    public Transform MainHeap5;
    public Transform MainHeap6;
    public Transform MainHeap7;
    public Transform MainHeap8;
   */
    public GameObject Mainheaps;


    public EnemyRecallSelectors RecallState;

    public enum EnemyMode
    {
        Patrolling,
        Combat,
        Searching,
    }
    public EnemyMode type = EnemyMode.Patrolling;
    //public EnemyMode type2 = EnemyMode.Combat;

    private void Start()
    {
        RigBod = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (type == EnemyMode.Patrolling)
        {
            if (path == 0)
            {              
                Vector3 patroll1 = (PathPoint1.position - this.transform.position).normalized;
                Vector3 MoveForce = patroll1 * patrollSpeed;
                RigBod.AddForce(MoveForce);
            }
            if (path == 1)
            {
                Vector3 patroll2 = (PathPoint2.position - this.transform.position).normalized;
                Vector3 Moveforce2 = patroll2 * patrollSpeed;
                RigBod.AddForce(Moveforce2);
            }
        }

        else if (type == EnemyMode.Combat)
        {
            if (RecallPos == -1 && IsFollowing == true)
            {
                Vector3 chase = (Player.transform.position - EnemyNPC.transform.position).normalized;
                Vector3 MovementForce = chase * MoveSpeed;
                RigBod.AddForce(MovementForce);
                //Debug.Log("IsFollowing");
            }

            if (RecallPos == 0 && IsFollowing == false)
            {
                Vector3 RecallDir0 = (recallStart.position - EnemyNPC.transform.position).normalized;
                Vector3 dir0Force = RecallDir0 * repulsion;
                RigBod.AddForce(dir0Force);
                //Debug.Log("NotFolliiwng");
            }

            if (RecallPos == 1)
            {
                Vector3 Recalldir1 = (recallP1.position - EnemyNPC.transform.position).normalized;
                Vector3 DirForce = Recalldir1 * recallingSpeed;
                RigBod.AddForce(DirForce);
                //Debug.Log("GoingToRecallp1");
            }

            if (RecallPos == 2)
            {
                Vector3 Recalldir2 = (recallP2.position - EnemyNPC.transform.position).normalized;
                Vector3 dir2Force = Recalldir2 * recallingSpeed;
                RigBod.AddForce(dir2Force);
                // Debug.Log("GoingToRecallp2");


            }
        }

    }

    public void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.name == "PathPoint1")
        {
            path = 1;
            Debug.Log("Pathpoint1 Detected");
        }
        if (collision.gameObject.name == "PathPoint2")
        {
            path = 0;
            Debug.Log("Pathpoint2 Detected");
        }
        if (collision.gameObject.CompareTag("PlayerRadius"))
        {
            RecallPos = 0;
            IsFollowing = false;
        }

        if (collision.gameObject.CompareTag("Recall"))
        {
            RecallPos = 1;
        }

        if (collision.gameObject.CompareTag("Recall1"))
        {
            RecallPos = 2;
        }

        if (collision.gameObject.CompareTag("Recall2"))
        {
            IsFollowing = true;
            RecallPos = -1;
        }
        if (collision.gameObject.CompareTag("ToShuttle"))
        {
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            RecallPos = 1;

        }
        
     


    }

 } 
        


    






//Below is how movement used to work, Unfortunately it caused major bugs so i switched to physic based movement.
//EnemyNPC.transform.position = Vector3.MoveTowards(EnemyNPC.transform.position, EnemyRecall.transform.position, ReverseSpeed * Time.deltaTime);

//Movement using rigidbody

/*Vector3 chase = (Player.transform.position - EnemyNPC.transform.position).normalized;
Vector3 MovementForce = chase * MoveSpeed;
RigBod.AddForce(MovementForce);
Debug.Log("IsFollowing");*/