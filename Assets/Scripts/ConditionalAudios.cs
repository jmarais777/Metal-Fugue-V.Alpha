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
    public AudioSource TurretReload;
    public AudioSource ButtonClick;
    public EnergyPool ForCurrentEnergy;
    private bool _healthCheck;
    private bool HealthPlay;
    public bool RechargeCheck;
    public bool ArtifactCheck;
    public bool PowerDownCheck;
    private bool _notPlayed;
    public bool ShotHappened;
    public bool ReloadCheck;
    public bool ButtonCheck;
    private bool _hasClicked;
    private bool _shooting;
    public bool IsReloading;
    private bool ArtifactPlaying;

    void Start()
    {
        _healthCheck = false;
        RechargeCheck = false;
        _notPlayed = true;
        ButtonCheck = false;
        _hasClicked = false;
        _shooting = false; 
        PowerDownCheck = false;
        ShotHappened = false;
        ReloadCheck = false;
        IsReloading = false;
        // _previousEnergy = ForCurrentEnergy.CurrentEnergy;
    }

    private void Update()
    {
        TriggerHealthCritical();
        TriggerRechargeStation();
        TriggerArtifact();
       // TriggerPowerDown();
        TriggerPowerDown();
        ButtonClicker();
        //TriggerReload();
        TriggerShot();
        //TriggerEnemyShot();

       /* if (_previousEnergy < ForCurrentEnergy.CurrentEnergy)
        {
            _rechargeCheck = true;
            Debug.Log("Meow");
        } */

        // _previousEnergy = ForCurrentEnergy.CurrentEnergy;
    }

    void TriggerHealthCritical()
    {
        if(ForCurrentEnergy.CurrentEnergy <= 30.0f && _healthCheck == false)
        {
            HealthCritical.PlayOneShot(HealthCritical.clip);
            HealthPlay = true;
        }

        if(HealthPlay == true)
        {
            _healthCheck = false;
            HealthPlay = false;
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
            ArtifactSound.PlayOneShot(ArtifactSound.clip);
            ArtifactPlaying = true;
        }
        else if (ArtifactPlaying == true)
        {
            ArtifactCheck = false;
            ArtifactPlaying = false;
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
            _shooting = true;
        }

        if (_shooting == true)
        {
            ShotHappened = false;
            _shooting = false;
        }
    }

    public void TriggerReload()
    {
        if(ReloadCheck == true)
        {
            TurretReload.PlayOneShot(TurretReload.clip);
            IsReloading = true;
        }

        if (IsReloading == true)
        {
            RechargeCheck = false;
            IsReloading = false;
        }
    }

    public void ButtonClicker()
    {
        if( ButtonCheck == true && !_hasClicked )
        {
            ButtonClick.PlayOneShot(ButtonClick.clip);
            _hasClicked = true;
        }

        if (_hasClicked == true)
        {
            ButtonCheck = false;
            _hasClicked = false;
        }
    }
}
