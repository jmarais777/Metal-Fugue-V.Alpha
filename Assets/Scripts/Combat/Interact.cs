using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;


public class Interact : MonoBehaviour
{

    public Transform Artifact;
    public Transform Player;
    public Transform ScavengerBot;
    public GameObject DialogueUI;
    public Transform RechargeStation;
    public GameObject CorticalProcessor;
    public GameObject CorticalProcessorEye;
    public Light2D CorticalProcessorLight;
    public EnergyPool ForCurrentEnergy;
    bool IsPlayerInProximity = true;
    public float InteractProximity = 20f;




    void Update()
    {
        float Artdistance = Vector2.Distance(Artifact.position, Player.position);
        float Scavengerdistance = Vector2.Distance(ScavengerBot.position, Player.position);
        float RechargeStat = Vector2.Distance(RechargeStation.position, Player.position);
        float Cort = Vector2.Distance(CorticalProcessor.transform.position, Player.position);

        if (Input.GetKeyDown(KeyCode.E))
        {
            IsPlayerInProximity = true;

            if (Artdistance < InteractProximity)
            {

                Debug.Log("hoho");

            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            IsPlayerInProximity = true;

            if (Scavengerdistance < InteractProximity)
            {
                ShowMenu();
                Debug.Log("yayyy");

            }
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            IsPlayerInProximity = true;

            if (RechargeStat < InteractProximity)
            {
                
                
                ForCurrentEnergy.CurrentEnergy += ForCurrentEnergy.MaxEnergy;
                ForCurrentEnergy.CurrentEnergy = Mathf.Clamp(ForCurrentEnergy.CurrentEnergy, 0, 100);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            IsPlayerInProximity = true;

            if (Cort < InteractProximity)
            {
                CorticalProcessor.SetActive(false);
                CorticalProcessorEye.SetActive(true);
                CorticalProcessorLight.pointLightInnerRadius = 10f;
                CorticalProcessorLight.pointLightOuterRadius = 12f;
            }
        }


    }
    void ShowMenu()
    {
        DialogueUI.SetActive(true);
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
    }
}





