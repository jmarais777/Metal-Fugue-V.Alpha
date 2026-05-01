#if UNITY_EDITOR
using UnityEditor.Rendering;
using UnityEditor.ShaderGraph;
#endif
using UnityEngine;

public class ScrapHeaps : MonoBehaviour
{
    //stores 5 hitpoints
    int HitPoints = 4;
    Rigidbody2D rb;
    SpriteRenderer rs;
    void Start()
    {
        rs = GetComponent<SpriteRenderer>();
    }


    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullets") && CompareTag("EnemyBullets"))
        {
            //subtracts one hit point on each collision.
            HitPoints--;


        }
        if (collision.gameObject.CompareTag("EnemyBullets"))
        {
            //subtracts one hit point on each collision.
            HitPoints--;


        }


        if (HitPoints <= 3)
        {
            rs.color = new Color(0.7686275f, 0.222598f, 0.1490196f, 1f);

        }
        if (HitPoints <= 2)
        {
            rs.color = new Color(0.7686275f, 0.333261f, 0.1490196f, 1f);

        }
        if (HitPoints <= 1)
        {
            rs.color = new Color(0.6980392f, 0.4548363f, 0.1333333f, 1f);

        }

        //destroys the obstacle if the hit points reach 0.
        if (HitPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}