using UnityEngine;
public class PlayerDetector : MonoBehaviour
{
    public EnemyMovement enemyMovementScript;


    void Start()
    {
         enemyMovementScript = GetComponentInParent<EnemyMovement>();
       

    }

    public void OnTriggerEnter2D(Collider2D PlayerCollider)
    {
        if (PlayerCollider.CompareTag("Player"))
        {
            enemyMovementScript.IsRecall = false;
           
        }
    }

}