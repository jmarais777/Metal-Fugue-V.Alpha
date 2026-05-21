using UnityEngine;

public class EnemyTriggEvents4 : MonoBehaviour
{
    public EnemyMovementFinal4 Movefin4; //custom
    public void OnTriggerStay2D(Collider2D collider)
    {
        //custom
        if (collider.gameObject.name == ("PathPoint6")) 
        {
            Movefin4.Move_Type4 = EnemyMovementFinal4.EnemyMovementType.Pathfinding7; 

            Debug.Log("Pathp1Hit");
        }
        //custom
        if (collider.gameObject.name == ("PathPoint7")) 
        {
            Movefin4.Move_Type4 = EnemyMovementFinal4.EnemyMovementType.Pathfinding6; 

            Debug.Log("Pathp2it");
        }
        //custom
        if (collider.gameObject.CompareTag("PlayerRadius"))
        {
            Movefin4.Move_Type4 = EnemyMovementFinal4.EnemyMovementType.Recalling;
            Debug.Log("PlayerRdiusHit");
        }
        //custom
        if (collider.gameObject.CompareTag("Recall"))
        {
            Movefin4.Move_Type4 = EnemyMovementFinal4.EnemyMovementType.Recalling1;
            Debug.Log("RecallHit");
        }
        //custom
        if (collider.gameObject.CompareTag("Recall1"))
        {
            Movefin4.Move_Type4 = EnemyMovementFinal4.EnemyMovementType.Chasing;
            Debug.Log("Recallp1Hit");
        }

    }

}
