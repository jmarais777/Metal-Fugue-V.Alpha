using UnityEngine;
using System.Collections.Generic;

public class ConditionalAudios : MonoBehaviour
{
    public AudioSource HealthCritical;
    public AudioSource RechargeStations;
    public EnergyPool ForCurrentEnergy;
    private bool _healthCheck;
    public bool _rechargeCheck;
    private float _previousEnergy;
    
    void Start()
    {
        _healthCheck = false;
        _rechargeCheck = false;
       // _previousEnergy = ForCurrentEnergy.CurrentEnergy;
    }

    private void Update()
    {
        TriggerHealthCritical();
        TriggerRechargeStation();

       /* if (_previousEnergy < ForCurrentEnergy.CurrentEnergy)
        {
            _rechargeCheck = true;
            Debug.Log("Meow");
        } */

       // _previousEnergy = ForCurrentEnergy.CurrentEnergy;
    }

    void TriggerHealthCritical()
    {
        if(ForCurrentEnergy.CurrentEnergy <= 30 && _healthCheck == false)
        {
            HealthCritical.Play();
            _healthCheck = true;
        }

        if(ForCurrentEnergy.CurrentEnergy >= 31)
        {
            _healthCheck = false;
        }
    }

    
  public void TriggerRechargeStation()
    {

        if (_rechargeCheck == true)
        {
            RechargeStations.Play();
            _rechargeCheck = false;
        } 
   
    }
}
