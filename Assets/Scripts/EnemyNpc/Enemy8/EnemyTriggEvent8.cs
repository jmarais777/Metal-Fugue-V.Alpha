using UnityEngine;

public class EnemyTriggEvents8 : MonoBehaviour
{
    public EnemyMovementFinal8 Movefin8; //custom
    public void OnTriggerStay2D(Collider2D collider)
    {
        //custom
        if (collider.gameObject.CompareTag("PlayerRadius"))
        {
            Movefin8.Move_Type8 = EnemyMovementFinal8.EnemyMovementType.Recalling;
            Debug.Log("PlayerRdiusHit");
        }
        //custom
        if (collider.gameObject.CompareTag("Recall"))
        {
            Movefin8.Move_Type8 = EnemyMovementFinal8.EnemyMovementType.Recalling1;
            Debug.Log("RecallHit");
        }
        //custom
        if (collider.gameObject.CompareTag("Recall1"))
        {
            Movefin8.Move_Type8 = EnemyMovementFinal8.EnemyMovementType.Chasing;
            Debug.Log("Recallp1Hit");
        }

    }

}
