using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyLightTypeDefault : EnemyLightingCollisionEffects
{
    public void ENemyLighting_Defualt()
    {
        Light_Source.intensity = 2;
    }
 
}
public class EnemyLightTypeDamaged : EnemyLightingCollisionEffects
{
    //Timer sytem for damage effect.
    public void EnemyLighting_Damanged()
    {
        float Light_Damage_Timer = 1.0f;
        Light_Damage_Timer -= Time.deltaTime;

        if (Light_Damage_Timer <= 0.0f)
        {
            if (EnemyLighting == Enemy_Lighting_Type.Damged)
            {
                Light_Source.intensity = 1;
            }
        }

        else if (Light_Damage_Timer > 0.0f)
        {
            return;
        }
    }

}

public class EnemyLightTypeDead : EnemyLightingCollisionEffects
{

}

public class EnemyLightingCollisionEffects : MonoBehaviour
{
    public GameObject player_Bullets;


    public Light2D Light_Source;

    
    public enum Enemy_Lighting_Type
    {
        Defualt,
        Damged,
        Dead,
    }
    public Enemy_Lighting_Type EnemyLighting;


    public void Start()
    {
       Light_Source = GetComponent<Light2D>();
    }

    public void OnTrigggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Bullets"))
        {
            EnemyLighting = Enemy_Lighting_Type.Defualt;

        }

    }


}