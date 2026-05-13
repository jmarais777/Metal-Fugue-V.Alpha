using UnityEngine;
using UnityEngine.Rendering.Universal;
public class EnemyLightTypeDefault : MonoBehaviour
{
    public GameObject Enemy;
    public enum Enemy_Lighting_Type
    {
        Defualt,
        Damged,
        Dead,
    }

    public void start()
    {
        GetComponent<Light2D>();
    }
    
       
    
}
public class EnemyLightTypeDamaged : EnemyLightTypeDefault
{

}

public class EnemyLightTypeDead : EnemyLightTypeDefault
{

}