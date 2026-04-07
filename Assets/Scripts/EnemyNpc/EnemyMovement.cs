using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    public GameObject EnemyNPC;
    public GameObject Player;
    public Transform EnemyRecall;
    public float MoveSpeed = 10.0f;
    Rigidbody2D rb;
    bool IsEnemyNPCSetActive = true;
    bool IsRecall = true;
    public float Timer = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
       
    }

    void OnEnable()
    {
        if (IsEnemyNPCSetActive == true)
        {
            Update();
        }

    }
    void Update()
    {
        Vector3 direction = (Player.transform.position - EnemyNPC.transform.position).normalized;
        EnemyNPC.transform.position += direction * MoveSpeed * Time.deltaTime ;

        Vector3 recall = (EnemyRecall.position - EnemyNPC.transform.position).normalized;

        if (IsRecall == true)
        {
            EnemyNPC.transform.position += recall * MoveSpeed * Time.deltaTime;
            Timer -= Time.deltaTime;
            Debug.Log("wow");
        }
        if (Timer <= 0)
        {
            IsRecall = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player")) 
        {
            IsRecall = true;
        }
    }
}
