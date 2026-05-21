using UnityEngine;

public class EnemyTriggEvents6 : MonoBehaviour
{
    public EnemyMovementFinal6 Movefin6; //custom
    public void OnTriggerStay2D(Collider2D collider)
    {
        //custom
        if (collider.gameObject.name == ("PathPoint12"))
        {
            Movefin6.Move_Type6 = EnemyMovementFinal6.EnemyMovementType.Pathfinding13;

            Debug.Log("Pathp1Hit");
        }
        //custom
        if (collider.gameObject.name == ("PathPoint13"))
        {
            Movefin6.Move_Type6 = EnemyMovementFinal6.EnemyMovementType.Pathfinding14;

            Debug.Log("Pathp2it");
        }
        //custom
        if (collider.gameObject.name == ("PathPoint14"))
        {
            Movefin6.Move_Type6 = EnemyMovementFinal6.EnemyMovementType.Pathfinding15;

            Debug.Log("Pathp2it");
        }
        if (collider.gameObject.name == ("PathPoint15"))
        {
            Movefin6.Move_Type6 = EnemyMovementFinal6.EnemyMovementType.Pathfinding12;

            Debug.Log("Pathp2it");
        }
        if (collider.gameObject.CompareTag("PlayerRadius"))
        {
            Movefin6.Move_Type6 = EnemyMovementFinal6.EnemyMovementType.Recalling;
            Debug.Log("PlayerRdiusHit");
        }
        //custom
        if (collider.gameObject.CompareTag("Recall"))
        {
            Movefin6.Move_Type6 = EnemyMovementFinal6.EnemyMovementType.Recalling1;
            Debug.Log("RecallHit");
        }
        //custom
        if (collider.gameObject.CompareTag("Recall1"))
        {
            Movefin6.Move_Type6 = EnemyMovementFinal6.EnemyMovementType.Chasing;
            Debug.Log("Recallp1Hit");
        }

    }

}
