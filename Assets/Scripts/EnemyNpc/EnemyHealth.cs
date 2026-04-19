using UnityEngine;

public class EnemyHealth : MonoBehaviour

{
   public int HitPoints = 25;
  
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
