using UnityEngine;

public class Enemy_Trigger_EventsFin7 : MonoBehaviour
{
    public EnemyMovementFinalFin7 MovefinFin2;
    public void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.name == ("PathPoint16"))
            {
                MovefinFin2.Move_Type = EnemyMovementFinalFin7.EnemyMovementType.Pathfinding3;
        
            Debug.Log("ReaperP2Hit");
        }

        if (collider.gameObject.name == ("PathPoint17"))
        {

            MovefinFin2.Move_Type = EnemyMovementFinalFin7.EnemyMovementType.Pathfinding2;
           
            Debug.Log("ReaperP3hit");
        }
      

        if (collider.gameObject.CompareTag("PlayerRadius"))
        {
            MovefinFin2.Move_Type = EnemyMovementFinalFin7.EnemyMovementType.Recalling;
            Debug.Log("PlayerRdiusHit");
        }

        if (collider.gameObject.CompareTag("Recall"))
        {
            MovefinFin2.Move_Type = EnemyMovementFinalFin7.EnemyMovementType.Recalling1;
            Debug.Log("RecallHit");
        }

        if (collider.gameObject.CompareTag("Recall1"))
        {
            MovefinFin2.Move_Type = EnemyMovementFinalFin7.EnemyMovementType.Chasing;
            Debug.Log("Recallp1Hit");
        }

    }
   
}
