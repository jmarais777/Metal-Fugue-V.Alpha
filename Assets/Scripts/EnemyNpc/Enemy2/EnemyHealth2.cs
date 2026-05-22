using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyHealth2 : MonoBehaviour

{
    public int HitPoints = 10;
    public EnemyMovementFinal2 Enemy_Move_Fin2;
    public EnemyPlayerDetecting2 Enemy_Player_Detection2;
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
            Enemy_Move_Fin2.Move_Type = EnemyMovementFinal2.EnemyMovementType.SystemFailure;
        }
    }

    IEnumerator DamageEffect()
    {
        Enemy_Light.intensity = 100;
        yield return new WaitForSeconds(0.1f);
        Enemy_Player_Detection2.Chasing_Light_Effect();
    }

}
