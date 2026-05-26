using UnityEngine;

public class Enemy_Trigger_EventsFin6 : MonoBehaviour
{
    public EnemyMovementFinalFin6 MovefinFin5;
    public void OnTriggerStay2D(Collider2D collider)
    {
        //custom
        if (collider.gameObject.name == ("PathPoint12"))
        {
            MovefinFin5.Move_TypeFin5 = EnemyMovementFinalFin6.EnemyMovementType.Pathfinding9;

            Debug.Log("Pathp1Hit");
        }
        //custom
        if (collider.gameObject.name == ("PathPoint13"))
        {
            MovefinFin5.Move_TypeFin5 = EnemyMovementFinalFin6.EnemyMovementType.Pathfinding10;

            Debug.Log("Pathp2it");
        }
        //custom
        if (collider.gameObject.name == ("PathPoint14"))
        {
            MovefinFin5.Move_TypeFin5 = EnemyMovementFinalFin6.EnemyMovementType.Pathfinding11;

            Debug.Log("Pathp2it");
        }
        if (collider.gameObject.name == ("PathPoint15"))
        {
            MovefinFin5.Move_TypeFin5 = EnemyMovementFinalFin6.EnemyMovementType.Pathfinding8;

            Debug.Log("Pathp2it");
        }
        if (collider.gameObject.CompareTag("PlayerRadius"))
        {
            MovefinFin5.Move_TypeFin5 = EnemyMovementFinalFin6.EnemyMovementType.Recalling;
            Debug.Log("PlayerRdiusHit");
        }
        //custom
        if (collider.gameObject.CompareTag("Recall"))
        {
            MovefinFin5.Move_TypeFin5 = EnemyMovementFinalFin6.EnemyMovementType.Recalling1;
            Debug.Log("RecallHit");
        }
        //custom
        if (collider.gameObject.CompareTag("Recall1"))
        {
            MovefinFin5.Move_TypeFin5 = EnemyMovementFinalFin6.EnemyMovementType.Chasing;
            Debug.Log("Recallp1Hit");
        }

    }

}

