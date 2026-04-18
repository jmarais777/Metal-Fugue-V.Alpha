using UnityEngine;

public class EnemyHealth : MonoBehaviour

{
    int HitPoints = 10;
    Rigidbody2D rb;
    SpriteRenderer sr;
    [SerializeField] private Collider2D EnemyCollider;
    [SerializeField] private Collider2D ProximityCollider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        

            if (collision.gameObject.CompareTag("Bullets"))
            {
                HitPoints--;

            }
        
            
        {

        }
        if (HitPoints < 0)
        {
            Destroy(this.gameObject);
        }
    } 


}
