using UnityEngine;

public class EnemyTriggEvents7 : MonoBehaviour
{
    public EnemyMovementFinal7 Movefin7; //custom
    public void OnTriggerStay2D(Collider2D collider)
    {
        //custom
        if (collider.gameObject.name == ("PathPoint16")) 
        {
            Movefin7.Move_Type7 = EnemyMovementFinal7.EnemyMovementType.Pathfinding17; 

            Debug.Log("Pathp1Hit");
        }
        //custom
        if (collider.gameObject.name == ("PathPoint17")) 
        {
            Movefin7.Move_Type7 = EnemyMovementFinal7.EnemyMovementType.Pathfinding16; 

            Debug.Log("Pathp2it");
        }
        //custom
        if (collider.gameObject.CompareTag("PlayerRadius"))
        {
            Movefin7.Move_Type7 = EnemyMovementFinal7.EnemyMovementType.Recalling;
            Debug.Log("PlayerRdiusHit");
        }
        //custom
        if (collider.gameObject.CompareTag("Recall"))
        {
            Movefin7.Move_Type7 = EnemyMovementFinal7.EnemyMovementType.Recalling1;
            Debug.Log("RecallHit");
        }
        //custom
        if (collider.gameObject.CompareTag("Recall1"))
        {
            Movefin7.Move_Type7 = EnemyMovementFinal7.EnemyMovementType.Chasing;
            Debug.Log("Recallp1Hit");
        }

    }

}
