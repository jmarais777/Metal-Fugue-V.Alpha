using UnityEngine;

public class Enemy_Trigger_EventsFinBoss : MonoBehaviour
{
    public EnemyMovementFinalFinBoss MovefinFin2;
    public void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.CompareTag("PlayerRadius"))
        {
            MovefinFin2.Move_Type = EnemyMovementFinalFinBoss.EnemyMovementType.Recalling;
            Debug.Log("PlayerRdiusHit");
        }

        if (collider.gameObject.CompareTag("Recall"))
        {
            MovefinFin2.Move_Type = EnemyMovementFinalFinBoss.EnemyMovementType.Recalling1;
            Debug.Log("RecallHit");
        }

        if (collider.gameObject.CompareTag("Recall1"))
        {
            MovefinFin2.Move_Type = EnemyMovementFinalFinBoss.EnemyMovementType.Chasing;
            Debug.Log("Recallp1Hit");
        }

    }
   
}
