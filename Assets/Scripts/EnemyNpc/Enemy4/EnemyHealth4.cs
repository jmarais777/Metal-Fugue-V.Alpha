using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyHealth4 : MonoBehaviour

{
    //custom
    public EnemyMovementFinal4 Enemy_Move_Fin4;
    public EnemyPlayerDetecting4 Enemy_Player_Detection4;

    public int HitPoints = 10;
    public float DamageEffectTimer = 0.5f;
    public float DamageEffectDuration = 0.5f;
    public bool IsTakingDamage = false;
    public Light2D Enemy_Light;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullets"))
        {
            StartCoroutine(DamageEffect());
            Debug.Log("BulletHit");
            HitPoints--;
        }

        if (HitPoints < 1)
        {
            Enemy_Move_Fin4.Move_Type4 = EnemyMovementFinal4.EnemyMovementType.SystemFailure; //custom
        }
    }

    IEnumerator DamageEffect()
    {
        Enemy_Light.intensity = 100;
        yield return new WaitForSeconds(0.1f);
        Enemy_Player_Detection4.Chasing_Light_Effect();    //custom
    }

}
