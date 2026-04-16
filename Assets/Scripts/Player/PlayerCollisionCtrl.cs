using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LightTransport;

public class PlayerCollisionCtrl : MonoBehaviour


{
    public GameObject EnemyNpcSensor;
    public GameObject PlayerSensor;
    public GameObject PlayerController;
    public float Repulsion = 10.0f ;
    public Rigidbody2D Rigbod;
    public EnemyMovement EnemyMove  ;

    void Update()
    {
        GetComponent<PlayerMovement>();
        GetComponent<Rigidbody2D>();
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {

        EnemyMove.IsFollowing = false;
        ProcessCollsion2D(collision.gameObject);
        
    }


    public void ProcessCollsion2D(GameObject world)
        
    {
        Vector3 Direction1 = (EnemyNpcSensor.transform.position - PlayerSensor.transform.position).normalized;
        if (world.gameObject.CompareTag("PlayerDetection"))
        {
            EnemyNpcSensor.transform.position = Direction1 * Repulsion * Time.deltaTime;
            Debug.Log("ItWorked");
        }

    }
}
