using UnityEngine;

public class EnemyTriggEvents3 : MonoBehaviour
{
    public EnemyMovementFinal3 Movefin3;
    public void OnTriggerStay2D(Collider2D collider)
    {

        if (collider.gameObject.name == ("PathPoint4"))
        {
            Movefin3.Move_Type3  = EnemyMovementFinal3.EnemyMovementType.Pathfinding5;

            Debug.Log("Pathp1Hit");
        }

        if (collider.gameObject.name == ("PathPoint5"))
        {
            Movefin3.Move_Type3 = EnemyMovementFinal3.EnemyMovementType.Pathfinding4;

            Debug.Log("Pathp2it");
        }

        if (collider.gameObject.CompareTag("PlayerRadius"))
        {
            Movefin3.Move_Type3 = EnemyMovementFinal3.EnemyMovementType.Recalling;
            Debug.Log("PlayerRdiusHit");
        }

        if (collider.gameObject.CompareTag("Recall"))
        {
            Movefin3.Move_Type3 = EnemyMovementFinal3.EnemyMovementType.Recalling1;
            Debug.Log("RecallHit");
        }

        if (collider.gameObject.CompareTag("Recall1"))
        {
            Movefin3.Move_Type3 = EnemyMovementFinal3.EnemyMovementType.Chasing;
            Debug.Log("Recallp1Hit");
        }

    }

}
