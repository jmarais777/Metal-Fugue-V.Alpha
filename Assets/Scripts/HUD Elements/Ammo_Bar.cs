using UnityEngine;
using UnityEngine.UIElements;

public class Ammo_Bar : MonoBehaviour
{
    public UIDocument Ammo_Hud_DOC;
    public ProgressBar ammo_bar;
    public EnergyPool energy_pool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        Ammo_Hud_DOC = GetComponent<UIDocument>();  
        if (Ammo_Hud_DOC != null )
        {
            var root = Ammo_Hud_DOC.rootVisualElement;
             ammo_bar = root.Q<ProgressBar>("AmmoBar");
        }
        ammo_bar.highValue = 10;
        ammo_bar.lowValue = 1;                
    }
    void Update()
    {
        if (energy_pool.IsDraining == true)
        {
            ammo_bar.value -= 1;
        }
        else if (energy_pool.IsDraining == false)
        {
            ammo_bar.value = energy_pool.CurrentAmmo;
        }
      
    }
}
