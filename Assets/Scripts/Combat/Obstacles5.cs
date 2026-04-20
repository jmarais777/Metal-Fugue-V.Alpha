
using UnityEngine.Rendering;
#if UNITY_EDITOR
using UnityEditor.ShaderGraph;
#endif
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //stores 5 hitpoints
    public int HitPoints = 5;
    Rigidbody2D rigBod;
    SpriteRenderer SpriteRen;
    
    void Start()
    {
        rigBod = GetComponent<Rigidbody2D>();
        SpriteRen = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullets"))
        {
            //subtracts one hit point on each collision.
            HitPoints --;

        
        }

        if (HitPoints == 4)
        {
            SpriteRen.color = new Color(0.5254902f, 0.3058824f, 0.6509804f, 1f);

        }
        if (HitPoints == 3)
        {
            SpriteRen.color = new Color(0.6431373f, 0.4156863f, 0.7411765f, 1f);

        }
        if (HitPoints == 2)
        {
            SpriteRen.color = new Color(0.7647059f, 0.5215687f, 0.8392157f, 1f);

        }
        if (HitPoints == 1)
        {
            SpriteRen.color = new Color(0.8470588f, 0.6392157f, 0.8901961f, 1f);

        }

        //destroys the obstacle if the hit points reach 0.
        if (HitPoints == 0)
        {
            Destroy(this.gameObject);
           
        }
    }
}

