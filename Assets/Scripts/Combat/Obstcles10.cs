using UnityEngine;

public class Obstcles10 : MonoBehaviour
{
    int HitPoints = 10;
    
    SpriteRenderer sr;
    void Start()
    {
       
       sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullets"))
        {
            HitPoints--;
        }
        if (HitPoints > 8)
        {
           sr.color = new Color(0.007843141f, 0.08277238f, 0.6745098f, 1f);
        }
        if (HitPoints <= 7)
        {
            sr.color = new Color(0.007843141f, 0.3634399f, 0.6745098f, 1f);
         }
        if (HitPoints <= 5)
        {
            sr.color = new Color(0.007843141f, 0.5744813f, 0.6745098f, 1f);
        }
        if (HitPoints <= 3)
        {
           sr.color = new Color(0.007843141f, 0.6745098f, 0.459742f, 1f);
        }
       

        if (HitPoints == 0)
        {
            Destroy(this.gameObject);
        }


        
    }
}