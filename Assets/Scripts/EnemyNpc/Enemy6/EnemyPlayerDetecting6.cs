using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering.Universal;

public class EnemyPlayerDetecting6 : MonoBehaviour
{
    public EnemyMovementFinal6 EnemyFin6; //Custom

    public float Detection_Light_timer = 10.0f;
    public float Damage_Effect_Timer = 2.0f;
    public bool Is_Detection_Light_timer_Done;
    public EnemySHootMech Enemeyshoot;
    public Light2D PlayerDetection_Light;
    //public Light2D Enemy_Eye_Light;
    public void Start()
    {
        PlayerDetection_Light = GetComponent<Light2D>();
    }
    public void Update()
    {
        //Custom
        if (EnemyFin6.Move_Type6 == EnemyMovementFinal6.EnemyMovementType.Pathfinding12 ||
            EnemyFin6.Move_Type6 == EnemyMovementFinal6.EnemyMovementType.Pathfinding13)
        {
            Patrolling_Light_Effect();
        }
        //Custom
        if (EnemyFin6.Move_Type6 == EnemyMovementFinal6.EnemyMovementType.Chasing)
        {
            Chasing_Light_Effect();
        }
        if (EnemyFin6.Move_Type6 == EnemyMovementFinal6.EnemyMovementType.FullDead)
        {
            DeadEffect();
        }
    }
    public void Patrolling_Light_Effect()
    {
        if (Is_Detection_Light_timer_Done == false)
        {
            Detection_Light_timer -= Time.deltaTime;

            if (Detection_Light_timer <= 0.0f)
            {
                PlayerDetection_Light.intensity = 2.0f;
                PlayerDetection_Light.falloffIntensity = 0.557f;

                // Enemy_Eye_Light.intensity = 2.0f;
                Is_Detection_Light_timer_Done = true;
            }
        }
        else if (Is_Detection_Light_timer_Done == true)
        {
            Detection_Light_timer += Time.deltaTime;

            if (Detection_Light_timer >= 0.5f)
            {
                Is_Detection_Light_timer_Done = false;
                PlayerDetection_Light.intensity = 3.0f;
                PlayerDetection_Light.falloffIntensity = 0.366f;
                Debug.Log("Patrolling_Light_Effects_rheheheh");
            }
        }
    }

    public void Chasing_Light_Effect()
    {
        PlayerDetection_Light.falloffIntensity = 1.0f;
        PlayerDetection_Light.intensity = 1.0f;

    }
    public void System_Failure_Effects() //set in EnemyHealth
    {
        PlayerDetection_Light.falloffIntensity = 0.5f;
        PlayerDetection_Light.intensity = 7.0f;
        Debug.Log("System_FailureEffect");
    }
    public void DeadEffect()
    {
        PlayerDetection_Light.intensity = 0.0f;
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.CompareTag("Player"))
        {
            EnemyFin6.Move_Type6 = EnemyMovementFinal6  .EnemyMovementType.Chasing; //Custom

        }
    }

}
