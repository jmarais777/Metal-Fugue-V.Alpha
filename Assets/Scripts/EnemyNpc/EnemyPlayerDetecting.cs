using UnityEngine;
using static EnemyMovementRev;

public class EnemyPlayerDetecting : MonoBehaviour
{
    public EnemyMovementRev EnemyMove;

    public void OnTriggerEnter2D(Collider2D collider)
    {
       if(collider.gameObject.CompareTag("Player"))
        {
            EnemyMove.type = EnemyMode.Combat;
        }
    }
}
