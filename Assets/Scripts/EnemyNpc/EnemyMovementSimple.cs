using UnityEngine;

public class ENemyMovementFinal :  MonoBehaviour
{
    //THE MOVEMNET STUFF
    public Rigidbody2D RigBod;
    public ForceMode2D RecallForce;
    public float Follow_Speed = 4.0f;

    public GameObject Enemy;
    public GameObject Player;

    public Transform RecallStart;
    public Transform RecallP1;

    private Enemy_Trigger_Events TriggEvent;


    public void Start()
    {
       RigBod = GetComponent<Rigidbody2D>();
 
    }

    public void Update()
    {
        switch (TriggEvent.MovingTowards)
        {
            case 0:
                Follow();
             break;

            case 1:
                Recall_start();
             break;
            case 2:
                Recall_Parent_One();
            break;
        }
        


    }

    public void Follow()
    {
        Vector3 Direction_To_Player = (Player.transform.position - Enemy.transform.position).normalized;
        RigBod.linearVelocity = (Direction_To_Player * Follow_Speed);
    }
    public void Recall_start()
    {    
        RecallForce = ForceMode2D.Impulse;
        Vector3 Direction_To_RecallStart = (Enemy.transform.position - RecallStart.position).normalized;
        RigBod.AddForce(Direction_To_RecallStart, ForceMode2D.Impulse);
    }
    public void Recall_Parent_One()
    {
        RecallForce = ForceMode2D.Impulse;
        Vector3 Direction_To_RecallP1 = (Enemy.transform.position - RecallP1.position).normalized;
        RigBod.AddForce(Direction_To_RecallP1, ForceMode2D.Impulse);

    }
 

}

public class Enemy_Trigger_Events : MonoBehaviour
{
    public int MovingTowards;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("PlayerRadius"))
        {
            MovingTowards = 0;
        }
        if (collider.gameObject.CompareTag("Recallstart"))
        {
            MovingTowards = 1;
        }
        if (collider.gameObject.CompareTag("recallp1"))
        {
            MovingTowards = 2;
        }
       
    }









}
