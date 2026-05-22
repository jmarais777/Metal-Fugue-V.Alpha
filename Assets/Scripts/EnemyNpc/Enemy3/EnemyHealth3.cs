using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyHealth3 : MonoBehaviour

{
    public int HitPoints = 10;
    public EnemyMovementFinal3 Enemy_Move_Fin3;
    public EnemyPlayerDetecting3 Enemy_Player_Detection3;
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
            Enemy_Move_Fin3.Move_Type3 = EnemyMovementFinal3.EnemyMovementType.SystemFailure;
        }
    }

    IEnumerator DamageEffect()
    {
        Enemy_Light.intensity = 100;
        yield return new WaitForSeconds(0.1f);
        Enemy_Player_Detection3.Chasing_Light_Effect();
    }

}
