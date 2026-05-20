using System.Threading;
using UnityEngine;

public class EnemyHealth : MonoBehaviour

{
   public int HitPoints = 10;
    public EnemyMovementFinal Enemy_Move_Fin;
    public EnemyPlayerDetecting Enemy_Player_Detection;
    public float DamageEffectTimer = 0.5f;
    public float DamageEffectDuration = 0.5f;
    public bool IsTakingDamage = false;

    public void Update()
    {
        if (DamageEffectTimer >= 0.0f)
        {
            DamageEffectTimer -= Time.deltaTime;
        }
        if (DamageEffectDuration >= 0.0f)
        {
            Enemy_Player_Detection.Chasing_Light_Effect();
            DamageEffectDuration -= Time.deltaTime;
          
        }

    }
     public void OnCollisionEnter2D(Collision2D collision)
    {            
       if (collision.gameObject.CompareTag("Bullets"))
       {
            if (DamageEffectTimer < 0.0f)
            {
                Enemy_Player_Detection.System_Failure_Effects();
                HitPoints--;
                DamageEffectTimer = 0.5f;
                DamageEffectDuration = 0.5f;

            }

        



         Debug.Log("BulletHit");
       }
      
        if (HitPoints < 0)
        {
            Enemy_Move_Fin.Move_Type = EnemyMovementFinal.EnemyMovementType.SystemFailure;

        }
    } 


}
