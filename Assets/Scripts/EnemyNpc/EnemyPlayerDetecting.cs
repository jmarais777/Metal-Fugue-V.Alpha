using Unity.VisualScripting;
using UnityEngine;
using static EnemyMovementRev;

public class EnemyPlayerDetecting : MonoBehaviour
{
   public EnemyMovementFinal EnemyFin;
    public void OnTriggerEnter2D(Collider2D collider)
    {
       if(collider.gameObject.CompareTag("Player"))
        {
            EnemyFin.Move_Type = EnemyMovementFinal.MovementType.Chasing;


        }
    }
}
