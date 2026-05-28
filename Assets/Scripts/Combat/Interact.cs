using JetBrains.Annotations;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;



public class Interact : MonoBehaviour
{

    public List<Transform> Enemies = new List<Transform>();
    //public Transform TargetEnemy;
    //recharge stations
    public GameObject RechargeStationCryo;
    public GameObject RechargeStationWind;
    public GameObject RechargeStationShuttle;
    public GameObject Player; 
    
    public GameObject ScavengerArmIngame;
    public GameObject ScavengerArmOnPlayer;
    public GameObject scavengerArmOnScav;
    public GameObject CorticalProcessor;
    public GameObject CorticalProcessorEye;
    public GameObject SecurityGate;

    public Light2D CorticalProcessorLight;
    public EnergyPool ForCurrentEnergy;
    public bool IsPlayerInProximity = true;
    public float InteractProximity = 8.0f; 

    public EnergyPool CurrentEnergyPool;
    public GameObject PowerButton;
    public QuestTracker quest;
    public EnemyMovementFinalFin1 Enemy_Move_fin;



    void Update()
    {
       
        float RechargeStatCryo = Vector2.Distance(RechargeStationCryo.transform.position, Player.transform.position);
        float RechargeStatWind = Vector2.Distance(RechargeStationWind.transform.position, Player.transform.position);
        float RechargeStatShut = Vector2.Distance(RechargeStationShuttle.transform.position, Player.transform.position);
        float Cort = Vector2.Distance(CorticalProcessor.transform.position, Player.transform.position);
        float Sec = Vector2.Distance(SecurityGate.transform.position, Player.transform.position);
        float Scavarm = Vector2.Distance(ScavengerArmIngame.transform.position, Player.transform.position);
        

       if (Input.GetKeyDown(KeyCode.E)) Debug.Log("E pressed. Distance to Arm is: " + Scavarm); //arm is to far away??


        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (Transform CurrentEnemy in Enemies)
            {
                float Enem = Vector2.Distance(CurrentEnemy.position, Player.transform.position);
                if (Enem < InteractProximity && Enemy_Move_fin.Move_Type == EnemyMovementFinalFin1.EnemyMovementType.SystemFailure)
                {
                    Debug.Log("Charginggg gunnnn");
                    CurrentEnergyPool.CurrentAmmo = 10;
                   // Enemy_Move_fin.Move_Type = EnemyMovementFinalFin1.EnemyMovementType.FullDead;
                    break;
                }
            }

            if (RechargeStatCryo < InteractProximity)
            {

                ForRechargeCheck.RechargeCheck = true;
                ForCurrentEnergy.CurrentEnergy += ForCurrentEnergy.MaxEnergy;
                ForCurrentEnergy.CurrentEnergy = Mathf.Clamp(ForCurrentEnergy.CurrentEnergy, 0, 100);
            }
            if (RechargeStatWind < InteractProximity)
            {

                ForRechargeCheck.RechargeCheck = true;
                ForCurrentEnergy.CurrentEnergy += ForCurrentEnergy.MaxEnergy;
                ForCurrentEnergy.CurrentEnergy = Mathf.Clamp(ForCurrentEnergy.CurrentEnergy, 0, 100);
            }
            if (RechargeStatShut < InteractProximity)
            {

                ForRechargeCheck.RechargeCheck = true;
                ForCurrentEnergy.CurrentEnergy += ForCurrentEnergy.MaxEnergy;
                ForCurrentEnergy.CurrentEnergy = Mathf.Clamp(ForCurrentEnergy.CurrentEnergy, 0, 100);
            }


            if (Scavarm < InteractProximity && ScavengerArmIngame.activeInHierarchy == true)
            {
                Debug.Log("Arm");
                ScavengerArmIngame.SetActive(false);
                ScavengerArmOnPlayer.SetActive(true);
            }



            if (Sec < InteractProximity)
            {
                CurrentEnergyPool.CurrentEnergy -= 5;

            }




            if (Cort < InteractProximity)
            {


                CorticalProcessor.SetActive(false);
                CorticalProcessorEye.SetActive(true);

                //these are just lighting controlls.
                CorticalProcessorLight.pointLightInnerRadius = 2.63f;
                CorticalProcessorLight.pointLightOuterRadius = 8.6f;
            }

            if (CorticalProcessor.activeSelf == false)
            {
                quest.IsQ1ObjectiveUpdate2 = true ;
            }

           
        }


            }

        }







//artifacts:
/*
public GameObject Artifact1;
public GameObject Artifact2;
public GameObject Artifact3;
public GameObject Artifact4;
public GameObject Artifact5;
public GameObject Artifact6;
public GameObject Artifact7;
public GameObject Artifact8;
public GameObject Artifact9;
*/

/*
       float Artdistance1 = Vector2.Distance(Artifact1.transform.position, Player.transform.position);
       float Artdistance2 = Vector2.Distance(Artifact2.transform.position, Player.transform.position);
       float Artdistance3 = Vector2.Distance(Artifact3.transform.position, Player.transform.position);
       float Artdistance4 = Vector2.Distance(Artifact4.transform.position, Player.transform.position);
       float Artdistance5 = Vector2.Distance(Artifact5.transform.position, Player.transform.position);
       float Artdistance6 = Vector2.Distance(Artifact6.transform.position, Player.transform.position);
       float Artdistance7 = Vector2.Distance(Artifact7.transform.position, Player.transform.position);
       float Artdistance8 = Vector2.Distance(Artifact8.transform.position, Player.transform.position);
       float Artdistance9 = Vector2.Distance(Artifact9.transform.position, Player.transform.position);
       */