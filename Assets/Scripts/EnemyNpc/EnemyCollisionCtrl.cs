
using UnityEngine;
public class EnemyCollisionCtrl : MonoBehaviour
{
    public EnemyMovement enemyMovementScript;
    public GameObject PlayerRadius;
    public GameObject EnemySensor;
    public float repulsion = 10.0f;
    public GameObject Scrapheap;


    
    public void OnTriggerStay2D(Collider2D collision)
    {
   
        if (collision.gameObject.CompareTag("PlayerRadius"))
        {
           // EnemySensor.transform.localPosition = Vector3.MoveTowards(EnemySensor.transform.localPosition, PlayerRadius.transform.localPosition, repulsion * Time.deltaTime);
            enemyMovementScript.IsFollowing = false;

        }
        

    }
}
    











