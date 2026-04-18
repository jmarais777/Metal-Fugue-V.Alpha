using UnityEngine;

public class EnemyHealth : MonoBehaviour

{
    int HitPoints = 10;
  
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
