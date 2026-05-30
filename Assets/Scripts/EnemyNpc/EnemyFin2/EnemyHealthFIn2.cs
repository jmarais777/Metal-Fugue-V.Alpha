using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyHealthFin2 : MonoBehaviour

{
   public int HitPoints = 10;
    public EnemyMovementFinalFIn2 Enemy_Move_Fin;
    public EnemyPlayerDetectingFin2 Enemy_Player_Detection;
    public float DamageEffectTimer = 0.5f;
    public float DamageEffectDuration = 0.5f;
    public bool IsTakingDamage = false;
    public Light2D Enemy_Light;
    
   
     public void OnCollisionEnter2D(Collision2D collision)
    {               
       if (collision.gameObject.CompareTag("Bullets"))
       {
            Debug.Log("BulletHit");
            //custom
            Enemy_Move_Fin.Move_Type = EnemyMovementFinalFIn2.EnemyMovementType.Damage;
                  HitPoints--;

        }
      
       if (HitPoints < 1)
       {
           Enemy_Move_Fin.Move_Type = EnemyMovementFinalFIn2.EnemyMovementType.SystemFailure;
       }
    }

}
