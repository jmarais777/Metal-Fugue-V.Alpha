using Unity.VisualScripting;
using UnityEngine;

public class Obstacles2 : MonoBehaviour
{
    int HitPoints = 2;
    SpriteRenderer sprRen;
    void Start()
    {
      
        sprRen = GetComponent<SpriteRenderer>();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullets"))
        {
            HitPoints--;
        }
        if (HitPoints == 1)
        {
            sprRen.color = new Color(0.7647059f , 0.5215687f, 0.8392157f, 1f);

        }
        if (HitPoints == 0)
        {
            Destroy(this.gameObject);
        }
    }
}

