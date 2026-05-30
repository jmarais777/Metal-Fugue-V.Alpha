using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ConditionalAudios : MonoBehaviour
{
    public AudioSource HealthCritical;
    public AudioSource RechargeStations;
    public AudioSource ArtifactSound;
    public AudioSource CryocombsPowerDown;
    public AudioSource EnergyShot;
    public EnergyPool ForCurrentEnergy;
    private bool _healthCheck;
    public bool RechargeCheck;
    public bool ArtifactCheck;
    public bool PowerDownCheck;
    bool _notPlayed;
    public bool ShotHappened;
    
    void Start()
    {
        _healthCheck = false;
        RechargeCheck = false;
        _notPlayed = true;
       // _previousEnergy = ForCurrentEnergy.CurrentEnergy;
    }

    private void Update()
    {
        TriggerHealthCritical();
        TriggerRechargeStation();
        TriggerArtifact();
        TriggerPowerDown();

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

        if (RechargeCheck == true)
        {
            RechargeStations.Play();
            RechargeCheck = false;
        } 
   
    }

    public void TriggerArtifact()
    {
        if (ArtifactCheck == true)
        {
            ArtifactSound.Play();
            ArtifactCheck = false;
        }
    }

    public void TriggerPowerDown()
    {
        if (PowerDownCheck == true && _notPlayed == true)
        {
            CryocombsPowerDown.PlayOneShot(CryocombsPowerDown.clip);
            _notPlayed = false;
        }
    }

    public void TriggerShot()
    {
        if (ShotHappened == true)
        {
            EnergyShot.PlayOneShot(EnergyShot.clip);
        }
    }
}
