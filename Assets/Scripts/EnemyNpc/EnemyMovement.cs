using JetBrains.Annotations;
using Unity.VisualScripting;
#if UNITY_EDITOR
using UnityEditor.Experimental.GraphView;
#endif
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class EnemyMovement : MonoBehaviour
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

    private void Start()
    {
       
        RigBod = GetComponent<Rigidbody2D>();
        
    }
    void FixedUpdate()
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
     
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerRadius"))
        {
           RecallPos = 0;
           IsFollowing = false;
        }

        if (collision.gameObject.CompareTag("Recall") )
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