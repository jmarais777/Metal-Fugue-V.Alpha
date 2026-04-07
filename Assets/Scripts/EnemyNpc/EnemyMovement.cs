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
    public float ReverseSpeed = 10.0f;
    Rigidbody2D rb;
    bool IsEnemyNPCSetActive = true;
    public bool IsRecall = true;
    private float LoopD = 2.0f;
    public float Timer = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Timer = LoopD;
       
       
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
        if (IsRecall == true)
        {
            Vector3 direction = (Player.transform.position - EnemyNPC.transform.position).normalized;
            EnemyNPC.transform.position += direction * MoveSpeed * Time.deltaTime;
        }
        Vector3 recall = (EnemyRecall.position - EnemyNPC.transform.position).normalized;

        if (IsRecall == false)
        {
            EnemyNPC.transform.position += recall * ReverseSpeed * Time.deltaTime;
            Timer -= Time.deltaTime;
            Debug.Log("wow");

            if (Timer <= 0)
            {
                IsRecall = true;
                Timer = LoopD;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player")) 
        {
            IsRecall = false;
        }
    }
}
