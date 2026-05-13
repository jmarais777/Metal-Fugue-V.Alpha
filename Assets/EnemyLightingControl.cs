using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyLightTypeDefault : EnemyLightingCollisionEffects
{
  public EnemyLightingCollisionEffects Light_Collider_Evt;
    public void EnemyLightingDefualt()
    {
        if (EnemyLighting == Enemy_Lighting_Type.Defualt)
        {
           
        }
       
    }
}
public class EnemyLightTypeDamaged : EnemyLightTypeDefault
{

}

public class EnemyLightTypeDead : EnemyLightTypeDefault
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