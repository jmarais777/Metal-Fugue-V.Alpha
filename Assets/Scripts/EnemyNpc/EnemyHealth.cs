using UnityEngine;

public class EnemyHealth : MonoBehaviour

{
   public int HitPoints = 10;
    public EnemyMovementFinal Enemy_Move_Fin;
    public EnemyPlayerDetecting Enemy_Player_Detection;
    public float DamageEffectTimer = 0.1f;

    public void Update()
    {
        DamageEffectTimer -= Time.deltaTime;
    }
     public void OnCollisionEnter2D(Collision2D collision)
    {            
       if (collision.gameObject.CompareTag("Bullets"))
       {
            if (DamageEffectTimer <= 0.0f)
            {
                HitPoints--;
                Enemy_Player_Detection.System_Failure_Effects();
                DamageEffectTimer = 0.1f;
            }
              
            
         Debug.Log("BulletHit");
       }
      
        if (HitPoints < 0)
        {
            Enemy_Move_Fin.Move_Type = EnemyMovementFinal.EnemyMovementType.SystemFailure;

        }
    } 


}
