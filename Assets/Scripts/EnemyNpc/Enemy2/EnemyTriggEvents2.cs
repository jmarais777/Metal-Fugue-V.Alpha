using UnityEngine;

public class EnemyTriggEvents2 : MonoBehaviour
{
    public EnemyMovementFinal2 Movefin2;
    public void OnTriggerStay2D(Collider2D collider)
    {

        if (collider.gameObject.name == ("PathPoint2"))
        {
            Movefin2.Move_Type = EnemyMovementFinal2.EnemyMovementType.Pathfinding3;

            Debug.Log("Pathp1Hit");
        }

        if (collider.gameObject.name == ("PathPoint3"))
        {
            Movefin2.Move_Type = EnemyMovementFinal2.EnemyMovementType.Pathfinding2;

            Debug.Log("Pathp2it");
        }


        if (collider.gameObject.CompareTag("PlayerRadius"))
        {
            Movefin2.Move_Type = EnemyMovementFinal2.EnemyMovementType.Recalling;
            Debug.Log("PlayerRdiusHit");
        }

        if (collider.gameObject.CompareTag("Recall"))
        {
            Movefin2.Move_Type = EnemyMovementFinal2.EnemyMovementType.Recalling1;
            Debug.Log("RecallHit");
        }

        if (collider.gameObject.CompareTag("Recall1"))
        {
            Movefin2.Move_Type = EnemyMovementFinal2.EnemyMovementType.Chasing;
            Debug.Log("Recallp1Hit");
        }

    }

}
