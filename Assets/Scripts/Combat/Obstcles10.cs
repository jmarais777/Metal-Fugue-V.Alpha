using UnityEngine;

public class Obstcles10 : MonoBehaviour
{
    int HitPoints = 10;
  

    
    SpriteRenderer SpriteRen;
    void Start()
    {
       
       SpriteRen = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullets"))
        {
            HitPoints--;
        }
        if (HitPoints > 8)
        {
            SpriteRen.color = new Color(0.4862745f, 0.4588235f, 0.7882353f, 1f);
        }
        if (HitPoints <= 7)
        {
            SpriteRen.color = new Color(0.627451f, 0.5607843f, 0.8588235f, 1f);
         }
        if (HitPoints <= 5)
        {
            SpriteRen.color = new Color(0.7647059f, 0.5215687f, 0.8392157f, 1f);
        }
        if (HitPoints <= 3)
        {
            SpriteRen.color = new Color(0.8470588f, 0.6392157f, 0.8901961f, 1f);
        }
       

        if (HitPoints == 0)
        {
            Destroy(this.gameObject);
            this.gameObject.SetActive(false);

        }



        
    }
   
}