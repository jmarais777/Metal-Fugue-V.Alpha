using UnityEngine;

public class Enemy_Trigger_EventsFin4 : MonoBehaviour
{
    public EnemyMovemnentFinalFin4 Movefin;
    public void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.name == ("PathPoint6"))
        {
            Movefin.Move_Type = EnemyMovemnentFinalFin4.EnemyMovementType.Pathfinding1;
        
            Debug.Log("Pathp1Hit");
        }

        if (collider.gameObject.name == ("PathPoint7"))
        {
            Movefin.Move_Type = EnemyMovemnentFinalFin4.EnemyMovementType.Pathfinding0;
           
            Debug.Log("Pathp2it");
        }
      

        if (collider.gameObject.CompareTag("PlayerRadius"))
        {
            Movefin.Move_Type = EnemyMovemnentFinalFin4.EnemyMovementType.Recalling;
            Debug.Log("PlayerRdiusHit");
        }

        if (collider.gameObject.CompareTag("Recall"))
        {
            Movefin.Move_Type = EnemyMovemnentFinalFin4.EnemyMovementType.Recalling1;
            Debug.Log("RecallHit");
        }

        if (collider.gameObject.CompareTag("Recall1"))
        {
            Movefin.Move_Type = EnemyMovemnentFinalFin4.EnemyMovementType.Chasing;
            Debug.Log("Recallp1Hit");
        }

    }
   
}
