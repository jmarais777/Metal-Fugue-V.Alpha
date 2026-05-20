using UnityEngine;

public class Enemy_Trigger_Events : MonoBehaviour
{
    public EnemyMovementFinal Movefin;
    public void OnTriggerStay2D(Collider2D collider)
    {

        if (collider.gameObject.name == ("PathPoint1"))
        {
            Movefin.Move_Type = EnemyMovementFinal.EnemyMovementType.Pathfinding2;
            Debug.Log("Pathp1Hit");
        }

        if (collider.gameObject.name == ("PathPoint2"))
        {
            Movefin.Move_Type = EnemyMovementFinal.EnemyMovementType.Pathfinding1;
            Debug.Log("Pathp2it");
        }

        if (collider.gameObject.CompareTag("PlayerRadius"))
        {
            Movefin.Move_Type = EnemyMovementFinal.EnemyMovementType.Recalling;
            Debug.Log("PlayerRdiusHit");
        }

        if (collider.gameObject.CompareTag("Recall"))
        {
            Movefin.Move_Type = EnemyMovementFinal.EnemyMovementType.Recalling1;
            Debug.Log("RecallHit");
        }

        if (collider.gameObject.CompareTag("Recall1"))
        {
            Movefin.Move_Type = EnemyMovementFinal.EnemyMovementType.Chasing;
            Debug.Log("Recallp1Hit");
        }

    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Movefin.Move_Type = EnemyMovementFinal.EnemyMovementType.searching;
        }
    }
}
