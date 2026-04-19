using UnityEngine;

public class ScrapHeapsShuttle : MonoBehaviour
{
    //stores 5 hitpoints
    public int HitPoints = 5;
    public GameObject Thisheap;
    public bool IsActive = true;
    public GameObject enemyNPC;
    public GameObject Ui3;
    

    SpriteRenderer spriteRen;

    void Start()
    {
      
        spriteRen = GetComponent<SpriteRenderer>();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Something hit the heap: " + collision.gameObject.name);
        if (enemyNPC != null && enemyNPC.activeInHierarchy)
        {
            this.enabled = false;
            return;
        }
  

        if (collision.gameObject.CompareTag("Bullets"))
        {
            HitPoints--;
        }

        if (HitPoints == 4)
        {
            spriteRen.color = new Color(0.5254902f, 0.3058824f, 0.6509804f, 1f);

        }
        if (HitPoints == 3)
        {
            spriteRen.color = new Color(0.6431373f, 0.4156863f, 0.7411765f, 1f);

        }
        if (HitPoints == 2)
        {
            spriteRen.color = new Color(0.7647059f, 0.5215687f, 0.8392157f, 1f);

        }
        if (HitPoints == 1)
        {
            spriteRen.color = new Color(0.8470588f, 0.6392157f, 0.8901961f, 1f);

        }

        //destroys the obstacle if the hit points reach 0.
        if (HitPoints == 0)
        {
            //Destroy(Thisheap);
            IsActive = false;
            Thisheap.SetActive(false);

        }

    }

}



