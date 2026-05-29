using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyHealthFinBoss : MonoBehaviour

{
   public int HitPoints = 10;
    public EnemyMovementFinalFinBoss Enemy_Move_Fin;
    public EnemyPlayerDetectingFinBoss Enemy_Player_Detection;
    public float DamageEffectTimer = 0.5f;
    public float DamageEffectDuration = 0.5f;
    public bool IsTakingDamage = false;
    public Light2D Enemy_Light;
    public SpriteRenderer Enemy_SpriteRenderer;

    //ADD NEW
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Bullets"))
        {
            Enemy_Move_Fin.Move_Type = EnemyMovementFinalFinBoss.EnemyMovementType.Damage;
            HitPoints--;

        }
        if (HitPoints < 1)
        {
            Enemy_Move_Fin.Move_Type = EnemyMovementFinalFinBoss.EnemyMovementType.SystemFailure;
        }

    }
    //STOP

}
