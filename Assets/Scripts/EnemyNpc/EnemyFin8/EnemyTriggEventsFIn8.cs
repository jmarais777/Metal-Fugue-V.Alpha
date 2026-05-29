using UnityEngine;

public class Enemy_Trigger_EventsFin8 : MonoBehaviour
{
    public EnemyMovementFinalFin8 MovefinFin2;
    public void OnTriggerStay2D(Collider2D collider)
    {

        if (collider.gameObject.CompareTag("PlayerRadius"))
        {
            MovefinFin2.Move_Type = EnemyMovementFinalFin8.EnemyMovementType.Recalling;
            Debug.Log("PlayerRdiusHit");
        }

        if (collider.gameObject.CompareTag("Recall"))
        {
            MovefinFin2.Move_Type = EnemyMovementFinalFin8.EnemyMovementType.Recalling1;
            Debug.Log("RecallHit");
        }

        if (collider.gameObject.CompareTag("Recall1"))
        {
            MovefinFin2.Move_Type = EnemyMovementFinalFin8.EnemyMovementType.Chasing;
            Debug.Log("Recallp1Hit");
        }

    }
   
}
