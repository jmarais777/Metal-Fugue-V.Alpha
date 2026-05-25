using UnityEngine;

public class Enemy_Trigger_EventsFin2 : MonoBehaviour
{
    public EnemyMovementFinalFIn2 MovefinFin2;
    public void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.name == ("PathPoint2"))
        {
            MovefinFin2.Move_Type = EnemyMovementFinalFIn2.EnemyMovementType.Pathfinding3;
        
            Debug.Log("ReaperP2Hit");
        }

        if (collider.gameObject.name == ("PathPoint3"))
        {

            MovefinFin2.Move_Type = EnemyMovementFinalFIn2.EnemyMovementType.Pathfinding2;
           
            Debug.Log("ReaperP3hit");
        }
      

        if (collider.gameObject.CompareTag("PlayerRadius"))
        {
            MovefinFin2.Move_Type = EnemyMovementFinalFIn2.EnemyMovementType.Recalling;
            Debug.Log("PlayerRdiusHit");
        }

        if (collider.gameObject.CompareTag("Recall"))
        {
            MovefinFin2.Move_Type = EnemyMovementFinalFIn2.EnemyMovementType.Recalling1;
            Debug.Log("RecallHit");
        }

        if (collider.gameObject.CompareTag("Recall1"))
        {
            MovefinFin2.Move_Type = EnemyMovementFinalFIn2.EnemyMovementType.Chasing;
            Debug.Log("Recallp1Hit");
        }

    }
   
}
