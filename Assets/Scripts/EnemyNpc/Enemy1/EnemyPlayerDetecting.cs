using JetBrains.Annotations;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering.Universal;

public class EnemyPlayerDetecting : MonoBehaviour
{
    public float Detection_Light_timer = 10.0f;
    public float Damage_Effect_Timer = 2.0f;
    public bool Is_Detection_Light_timer_Done;
    public EnemyMovementFinal EnemyFin;
    public EnemySHootMech Enemeyshoot;
    public Light2D PlayerDetection_Light;
    //public Light2D Enemy_Eye_Light;
    public void Start()
    {
        PlayerDetection_Light = GetComponent<Light2D>();


    }
    public void Update()
    {

        if (EnemyFin.Move_Type == EnemyMovementFinal.EnemyMovementType.Pathfinding0 ||
            EnemyFin.Move_Type == EnemyMovementFinal.EnemyMovementType.Pathfinding1 )   
        {
            StartCoroutine(Enemy_Patroll_Sfx());
        }
 
        if (EnemyFin.Move_Type == EnemyMovementFinal.EnemyMovementType.Chasing)
        {
            Chasing_Light_Effect();
        }
        if (EnemyFin.Move_Type == EnemyMovementFinal.EnemyMovementType.FullDead)
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
                PlayerDetection_Light.pointLightInnerRadius = 0.0f;
                PlayerDetection_Light.pointLightOuterRadius = 12.42f;
                PlayerDetection_Light.intensity = 0.88f;
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
        PlayerDetection_Light.pointLightOuterRadius = 0.11f;
        PlayerDetection_Light.pointLightInnerRadius = 0.0f;
        PlayerDetection_Light.falloffIntensity = 0f;
        PlayerDetection_Light.intensity = 23.0f;
 

    }
    public void System_Failure_Effects() //set in EnemyHealth
    {             
        PlayerDetection_Light.falloffIntensity = 0.5f;
        PlayerDetection_Light.intensity = 0.5f;
        Debug.Log("System_FailureEffect");                     
    }


    public void DeadEffect()
    {
        PlayerDetection_Light.enabled = false;
    }
    public IEnumerator Enemy_Patroll_Sfx()
    {
        PlayerDetection_Light.pointLightInnerRadius = 0.0f;
        PlayerDetection_Light.pointLightOuterRadius = 12.42f;
        PlayerDetection_Light.intensity = 0.88f;
        PlayerDetection_Light.falloffIntensity = 0.557f;
        // Enemy_Eye_Light.intensity = 2.0f;
        Is_Detection_Light_timer_Done = true;
        yield return new WaitForSeconds(1f);
        while(Is_Detection_Light_timer_Done == true)
        {
            float PtSetter = 0.0f;
            
            PtSetter += Time.deltaTime;
            PlayerDetection_Light.pointLightInnerRadius += PtSetter;
            if (PlayerDetection_Light.pointLightInnerRadius >= 12.42f)
            {
                Is_Detection_Light_timer_Done = false;
            }
            yield return null;
        }
        while (Is_Detection_Light_timer_Done == false)
        {
            PlayerDetection_Light.pointLightInnerRadius -= Time.deltaTime;
            if (PlayerDetection_Light.pointLightInnerRadius <= 0.0f)
            {
                Is_Detection_Light_timer_Done = true;
            }
            yield return null;
        }
        yield return null;
    }


    public void OnTriggerEnter2D(Collider2D collider)
    {
     
       if(collider.gameObject.CompareTag("Player"))
        {
            EnemyFin.Move_Type = EnemyMovementFinal.EnemyMovementType.Chasing;

        }
    }

}
