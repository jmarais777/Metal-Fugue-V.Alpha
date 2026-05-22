using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyHealth5 : MonoBehaviour

{
    //custom
    public EnemyMovementFinal5 Enemy_Move_Fin5;
    public EnemyPlayerDetecting5 Enemy_Player_Detection5;

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
            Enemy_Move_Fin5.Move_Type5 = EnemyMovementFinal5.EnemyMovementType.SystemFailure; //custom
        }
    }

    IEnumerator DamageEffect()
    {
        Enemy_Light.intensity = 100;
        yield return new WaitForSeconds(0.1f);
        Enemy_Player_Detection5.Chasing_Light_Effect();    //custom
    }

}
