using Unity.VisualScripting;
using UnityEngine;

public class Obstacles2 : MonoBehaviour
{
    int HitPoints = 2;
    Rigidbody2D rb;
    SpriteRenderer rs;
    void Start()
    {
       rb =  GetComponent<Rigidbody2D>();
        rs = GetComponent<SpriteRenderer>();

    }

    void Update()
    {


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullets"))
        {
            HitPoints--;
        }
        if (HitPoints == 1)
        {
            rs.color = new Color(0.5357571f, 0.6980392f, 0.1333333f, 1f);

        }
        if (HitPoints == 0)
        {
            Destroy(this.gameObject);
        }
    }
}

