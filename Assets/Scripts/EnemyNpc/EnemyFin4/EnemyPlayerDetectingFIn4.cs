using JetBrains.Annotations;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering.Universal;

public class EnemyPlayerDetectingFin4 : MonoBehaviour
{
    public float Detection_Light_timer = 10.0f;
    public float Damage_Effect_Timer = 2.0f;
    public float lightSpeed = 2.0f;
    public bool IsSystemFail = false;
    public bool Is_Detection_Light_timer_Done;
    public EnemyMovemnentFinalFin4 EnemyFin;
    public EnemySHootMech Enemeyshoot;
    public Light2D PlayerDetection_Light;
    public GameObject PlayerDetectObj;
    public SpriteRenderer Spr_Ren;
  
    //public Light2D Enemy_Eye_Light;
    public void Start()
    {
        PlayerDetection_Light = GetComponent<Light2D>();
       PlayerDetection_Light.AddTargetSortingLayer("Enemy");
    }
    public void Update()
    {
        if (EnemyFin.Move_Type == EnemyMovemnentFinalFin4.EnemyMovementType.Pathfinding0 ||
            EnemyFin.Move_Type == EnemyMovemnentFinalFin4.EnemyMovementType.Pathfinding1 )   
        {
            StartCoroutine(Enemy_Patroll_Sfx());
        }

        if (EnemyFin.Move_Type == EnemyMovemnentFinalFin4.EnemyMovementType.Chasing)
        {
            Chasing_Light_Effect();
        }

        if (EnemyFin.Move_Type == EnemyMovemnentFinalFin4.EnemyMovementType.FullDead)
        {
            DeadEffect();
        }
        //REMOVE SYSTEM FAILURE

        //REMOVE SYSTEM FAILURE

        if (EnemyFin.isWalkingL == true)
        {
            transform.localPosition = new Vector3(-0.586f, 1.083f, 0.0f);
        }

        if (EnemyFin.isWalkingR == true )
        {
            transform.localPosition = new Vector3(0.416f, 1.078f, 0.0f);
        }

        if (EnemyFin.isWalkingB == true)
        {
            transform.localPosition = new Vector3(0.288f, 1.054f, 0.0f);
            
            if (EnemyFin.Move_Type == EnemyMovemnentFinalFin4.EnemyMovementType.Pathfinding0 && EnemyFin.Move_Type == EnemyMovemnentFinalFin4.EnemyMovementType.Pathfinding1)
            {
                PlayerDetection_Light.enabled = false;
            }
            // PlayerDetection_Light.RemoveTargetSortingLayer("Defualt");
              
        }
       
        else if (EnemyFin.isWalkingB == false)
        {
            PlayerDetection_Light.enabled = true;
           // transform.localPosition = new Vector3(-300.35f, 18.51f, 0.0f);
        }
        if (EnemyFin.isWalkingF == true)
        {
            transform.localPosition = new Vector3(0.288f, 1.054f, 0.0f);

        }
        
        
    }
  

    public void Chasing_Light_Effect()
    {
        
        PlayerDetection_Light.pointLightOuterRadius = 0.11f;
        PlayerDetection_Light.pointLightInnerRadius = 0.0f;
        PlayerDetection_Light.falloffIntensity = 0f;
    }
 
    public void DeadEffect()
    {
        PlayerDetection_Light.enabled = false;
    }
    public IEnumerator Enemy_System_Failure()
    {
        IsSystemFail = true;
        yield return null;
        while (IsSystemFail == true)
        {
            PlayerDetection_Light.falloffIntensity = 1.0f;
            PlayerDetection_Light.intensity = 0.87f;
            PlayerDetection_Light.pointLightInnerRadius = 0.07f;
            PlayerDetection_Light.pointLightOuterRadius = 0.2f;
            Debug.Log("System_FailureEffect");
          
            yield return null;
        }
          IsSystemFail = false;
         yield return new WaitForSeconds(0.5f);
        while (IsSystemFail == false)
        {
          PlayerDetection_Light.falloffIntensity = 0.349f;
          PlayerDetection_Light.pointLightInnerRadius = 0.29f;
          PlayerDetection_Light.pointLightOuterRadius = 0.48f;
          PlayerDetection_Light.intensity = 1.5f;
            yield return null; 
        }
    }
    public IEnumerator Enemy_Patroll_Sfx()
    {
        while (Is_Detection_Light_timer_Done == false)
        {
            PlayerDetection_Light.intensity = 0.0f;
            PlayerDetection_Light.falloffIntensity = 0;
            PlayerDetection_Light.pointLightOuterRadius = 19.9f;
            Is_Detection_Light_timer_Done = true;
        }
        while (Is_Detection_Light_timer_Done == true)
        {
            yield return new WaitForSeconds(0.3f);
            PlayerDetection_Light.intensity = 3.0f;
            PlayerDetection_Light.falloffIntensity = 0.557f;
            PlayerDetection_Light.pointLightInnerRadius = 12.43f;
            PlayerDetection_Light.pointLightOuterRadius = 19.9f;
            yield return new WaitForSeconds(0.3f);
            PlayerDetection_Light.intensity = 1.0f;
            PlayerDetection_Light.falloffIntensity = 0.557f;
            PlayerDetection_Light.pointLightInnerRadius = 5.0f;
            PlayerDetection_Light.pointLightOuterRadius = 19.9f;
            yield return new WaitForSeconds(0.1f);
            PlayerDetection_Light.intensity = 2.0f;
            PlayerDetection_Light.falloffIntensity = 0.557f;
            PlayerDetection_Light.pointLightInnerRadius = 12.43f;
            PlayerDetection_Light.pointLightOuterRadius = 19.9f;
            yield return new WaitForSeconds(0.3f);
            Is_Detection_Light_timer_Done = false;
        }
        yield return null;
        
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
     
       if(collider.gameObject.CompareTag("Player"))
        {
            EnemyFin.Move_Type = EnemyMovemnentFinalFin4.EnemyMovementType.Chasing;

        }
    }

}

//old code
/*
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
*/
