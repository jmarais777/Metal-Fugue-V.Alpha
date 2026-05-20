using UnityEngine;

public class EnemySearchCollision : MonoBehaviour
{
    public EnemyMovementFinal Enemy_Move_Fin;
public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Enemy_Move_Fin.Move_Type = EnemyMovementFinal.EnemyMovementType.searching;
        }
    }
}
