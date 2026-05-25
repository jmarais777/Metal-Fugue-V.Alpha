using UnityEngine;

public class Enemy_Trigger_EventsFin3 : MonoBehaviour
{
    public EnemyMovementFinalFin3 Movefin;
    public void OnTriggerStay2D(Collider2D collider)
    {

        if (collider.gameObject.name == ("PathPoint0"))
        {
            Movefin.Move_Type = EnemyMovementFinalFin3  .EnemyMovementType.Pathfinding1;
        
            Debug.Log("Pathp1Hit");
        }

        if (collider.gameObject.name == ("PathPoint1"))
        {
            Movefin.Move_Type = EnemyMovementFinalFin3.EnemyMovementType.Pathfinding0;
           
            Debug.Log("Pathp2it");
        }
      

        if (collider.gameObject.CompareTag("PlayerRadius"))
        {
            Movefin.Move_Type = EnemyMovementFinalFin3.EnemyMovementType.Recalling;
            Debug.Log("PlayerRdiusHit");
        }

        if (collider.gameObject.CompareTag("Recall"))
        {
            Movefin.Move_Type = EnemyMovementFinalFin3.EnemyMovementType.Recalling1;
            Debug.Log("RecallHit");
        }

        if (collider.gameObject.CompareTag("Recall1"))
        {
            Movefin.Move_Type = EnemyMovementFinalFin3.EnemyMovementType.Chasing;
            Debug.Log("Recallp1Hit");
        }

    }
   
}
