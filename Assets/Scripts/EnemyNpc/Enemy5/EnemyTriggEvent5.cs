using UnityEngine;

public class EnemyTriggEvents5 : MonoBehaviour
{
    public EnemyMovementFinal5 Movefin5; //custom
    public void OnTriggerStay2D(Collider2D collider)
    {
        //custom
        if (collider.gameObject.name == ("PathPoint8"))
        {
            Movefin5.Move_Type5 = EnemyMovementFinal5.EnemyMovementType.Pathfinding9;

            Debug.Log("Pathp1Hit");
        }
        //custom
        if (collider.gameObject.name == ("PathPoint9"))
        {
            Movefin5.Move_Type5 = EnemyMovementFinal5.EnemyMovementType.Pathfinding10;

            Debug.Log("Pathp2it");
        }
        //custom
        if (collider.gameObject.name == ("PathPoint10"))
        {
            Movefin5.Move_Type5 = EnemyMovementFinal5.EnemyMovementType.Pathfinding11;

            Debug.Log("Pathp2it");
        }
        if (collider.gameObject.name == ("PathPoint11"))
        {
            Movefin5.Move_Type5 = EnemyMovementFinal5.EnemyMovementType.Pathfinding8;

            Debug.Log("Pathp2it");
        }
        if (collider.gameObject.CompareTag("PlayerRadius"))
        {
            Movefin5.Move_Type5 = EnemyMovementFinal5.EnemyMovementType.Recalling;
            Debug.Log("PlayerRdiusHit");
        }
        //custom
        if (collider.gameObject.CompareTag("Recall"))
        {
            Movefin5.Move_Type5 = EnemyMovementFinal5.EnemyMovementType.Recalling1;
            Debug.Log("RecallHit");
        }
        //custom
        if (collider.gameObject.CompareTag("Recall1"))
        {
            Movefin5.Move_Type5 = EnemyMovementFinal5.EnemyMovementType.Chasing;
            Debug.Log("Recallp1Hit");
        }

    }

}
