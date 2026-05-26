using UnityEngine;

public class Enemy_Trigger_EventsFin5 : MonoBehaviour
{
    public EnemyMovementFinalFin5 MovefinFin5;
    public void OnTriggerStay2D(Collider2D collider)
    {
        //custom
        if (collider.gameObject.name == ("PathPoint8"))
        {
            MovefinFin5.Move_TypeFin5 = EnemyMovementFinalFin5.EnemyMovementType.Pathfinding9;

            Debug.Log("Pathp1Hit");
        }
        //custom
        if (collider.gameObject.name == ("PathPoint9"))
        {
            MovefinFin5.Move_TypeFin5 = EnemyMovementFinalFin5.EnemyMovementType.Pathfinding10;

            Debug.Log("Pathp2it");
        }
        //custom
        if (collider.gameObject.name == ("PathPoint10"))
        {
            MovefinFin5.Move_TypeFin5 = EnemyMovementFinalFin5.EnemyMovementType.Pathfinding11;

            Debug.Log("Pathp2it");
        }
        if (collider.gameObject.name == ("PathPoint11"))
        {
            MovefinFin5.Move_TypeFin5 = EnemyMovementFinalFin5.EnemyMovementType.Pathfinding8;

            Debug.Log("Pathp2it");
        }
        if (collider.gameObject.CompareTag("PlayerRadius"))
        {
            MovefinFin5.Move_TypeFin5 = EnemyMovementFinalFin5.EnemyMovementType.Recalling;
            Debug.Log("PlayerRdiusHit");
        }
        //custom
        if (collider.gameObject.CompareTag("Recall"))
        {
            MovefinFin5.Move_TypeFin5 = EnemyMovementFinalFin5.EnemyMovementType.Recalling1;
            Debug.Log("RecallHit");
        }
        //custom
        if (collider.gameObject.CompareTag("Recall1"))
        {
            MovefinFin5.Move_TypeFin5 = EnemyMovementFinalFin5.EnemyMovementType.Chasing;
            Debug.Log("Recallp1Hit");
        }

    }

}

