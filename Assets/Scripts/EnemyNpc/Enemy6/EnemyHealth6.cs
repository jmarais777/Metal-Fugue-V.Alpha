using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyHealth6 : MonoBehaviour

{
    //custom
    public EnemyMovementFinal6 Enemy_Move_Fin6;
    public EnemyPlayerDetecting6 Enemy_Player_Detection6;

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
            Enemy_Move_Fin6.Move_Type6 = EnemyMovementFinal6.EnemyMovementType.SystemFailure; //custom
        }
    }

    IEnumerator DamageEffect()
    {
        Enemy_Light.intensity = 100;
        yield return new WaitForSeconds(0.1f);
        Enemy_Player_Detection6.Chasing_Light_Effect();    //custom
    }

}
