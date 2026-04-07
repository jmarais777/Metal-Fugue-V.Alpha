using UnityEngine;

public class EnemyHealth : MonoBehaviour

{
    int HitPoints = 10;
    Rigidbody2D rb;
    SpriteRenderer sr;
    private float Timer = 1.0f;

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
