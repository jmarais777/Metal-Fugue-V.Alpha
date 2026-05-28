using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyHealthFin1 : MonoBehaviour

{
   public int HitPoints = 10;
    public EnemyMovementFinalFin1 Enemy_Move_Fin;
    public EnemyPlayerDetectingFin1 Enemy_Player_Detection;
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
            Enemy_Move_Fin.Move_Type = EnemyMovementFinalFin1.EnemyMovementType.Damage;
            HitPoints--;

        }
        if (HitPoints < 1)
        {
            Enemy_Move_Fin.Move_Type = EnemyMovementFinalFin1.EnemyMovementType.SystemFailure;
        }

    }
    //STOP
}
