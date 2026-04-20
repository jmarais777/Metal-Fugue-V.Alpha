using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;


public class Interact : MonoBehaviour
{
   //artifacts:
    public GameObject Artifact1;
    public GameObject Artifact2;
    public GameObject Artifact3;
    public GameObject Artifact4;
    public GameObject Artifact5;
    public GameObject Artifact6;
    public GameObject Artifact7;
    public GameObject Artifact8;
    public GameObject Artifact9;

    //recharge stations
    public GameObject RechargeStationCryo;
    public GameObject RechargeStationWind;
    public GameObject RechargeStationShuttle;



    public GameObject Player;
  
    public GameObject Enemy;
 

    public GameObject ScavengerArmIngame;
    public GameObject ScavengerArmOnPlayer;
    public GameObject scavengerArmOnScav;

    


    public GameObject CorticalProcessor;
    public GameObject CorticalProcessorEye;
    public GameObject SecurityGate;
    public Light2D CorticalProcessorLight;
    public EnergyPool ForCurrentEnergy;
    public bool IsPlayerInProximity = true;
    public float InteractProximity = 20f; 

    public EnergyPool CurrentEnergyPool;
    public GameObject PowerButton;




    void Update()
    {
        float Artdistance1 = Vector2.Distance(Artifact1.transform.position, Player.transform.position);
        float Artdistance2 = Vector2.Distance(Artifact2.transform.position, Player.transform.position);
        float Artdistance3 = Vector2.Distance(Artifact3.transform.position, Player.transform.position);
        float Artdistance4 = Vector2.Distance(Artifact4.transform.position, Player.transform.position);
        float Artdistance5 = Vector2.Distance(Artifact5.transform.position, Player.transform.position);
        float Artdistance6 = Vector2.Distance(Artifact6.transform.position, Player.transform.position);
        float Artdistance7 = Vector2.Distance(Artifact7.transform.position, Player.transform.position);
        float Artdistance8 = Vector2.Distance(Artifact8.transform.position, Player.transform.position);
        float Artdistance9 = Vector2.Distance(Artifact9.transform.position, Player.transform.position);



        float RechargeStatCryo = Vector2.Distance(RechargeStationCryo.transform.position, Player.transform.position);
        float RechargeStatWind = Vector2.Distance(RechargeStationWind.transform.position, Player.transform.position);
        float RechargeStatShut = Vector2.Distance(RechargeStationShuttle.transform.position, Player.transform.position);


        float Cort = Vector2.Distance(CorticalProcessor.transform.position, Player.transform.position);
        float Sec = Vector2.Distance(SecurityGate.transform.position, Player.transform.position);
        float Scavarm = Vector2.Distance(ScavengerArmIngame.transform.position, Player.transform.position);
     
        if (Input.GetKeyDown(KeyCode.E)) Debug.Log("E pressed. Distance to Arm is: " + Scavarm); //arm is to far away??


        if (Input.GetKeyDown(KeyCode.E)) 
        {
          

            if (Artdistance1 < InteractProximity) 
            {

               Artifact1.SetActive(false);

            }

            if (Artdistance2 < InteractProximity)
            {

                Artifact2.SetActive(false);

            }

            if (Artdistance3 < InteractProximity)
            {

                Artifact3.SetActive(false);

            }

            if (Artdistance3 < InteractProximity)
            {

                Artifact3.SetActive(false);

            }

            if (Artdistance4 < InteractProximity)
            {

                Artifact4.SetActive(false);

            }
            if (Artdistance5 < InteractProximity)
            {

                Artifact5.SetActive(false);

            }
            if (Artdistance6 < InteractProximity)
            {

                Artifact6.SetActive(false);

            }
            if (Artdistance7 < InteractProximity)
            {

                Artifact7.SetActive(false);

            }
            if (Artdistance8 < InteractProximity)
            {

                Artifact8.SetActive(false);

            }
            if (Artdistance9 < InteractProximity)
            {

                Artifact9.SetActive(false);

            }

            if (Input.GetKeyDown(KeyCode.E))
                {
            

                if (RechargeStatCryo < InteractProximity)
                     {
    
                ForCurrentEnergy.CurrentEnergy += ForCurrentEnergy.MaxEnergy;
                ForCurrentEnergy.CurrentEnergy = Mathf.Clamp(ForCurrentEnergy.CurrentEnergy, 0, 100);
                    }
                if (RechargeStatWind < InteractProximity)
                {

                    ForCurrentEnergy.CurrentEnergy += ForCurrentEnergy.MaxEnergy;
                    ForCurrentEnergy.CurrentEnergy = Mathf.Clamp(ForCurrentEnergy.CurrentEnergy, 0, 100);
                }
                if (RechargeStatShut < InteractProximity)
                {

                    ForCurrentEnergy.CurrentEnergy += ForCurrentEnergy.MaxEnergy;
                    ForCurrentEnergy.CurrentEnergy = Mathf.Clamp(ForCurrentEnergy.CurrentEnergy, 0, 100);
                }
            }





            if (Scavarm < InteractProximity && ScavengerArmIngame.activeSelf == true)
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
            


            }

        }

        //These otehr id statements do the exact same thing, just for diffferent objects. teh big difference is what actually happens when each object is interacted with.

        /* if (Input.GetKeyDown(KeyCode.E))
         {

             if (Enemy != null && Enemy.activeInHierarchy)
             {
                 if (uiLinker1 < InteractProximity)
                 {
                     ShowMenu1();

                 }
             }

             else if (uiLinker2 < InteractProximity)
             {                            
                     ShowMenu2();
                 Debug.Log("He dead");


             }
             else if (uilinker4 < InteractProximity && UiLinker2 == null)
             {
                 if (ScavengerArmOnPlayer != null)
                 {


                     scavengerArmOnScav.SetActive(true);
                     ShowMenu4();
                 }

             }

         }*/


        /* if (Input.GetKeyDown(KeyCode.E))
         {
             IsPlayerInProximity  = false;
         /*}


        



        //this is for our Ui,but its not working properly yet so don't try to learn from it.
        /*void ShowMenu1()
        {
            DialogueUI1.SetActive(true);
            UnityEngine.Cursor.visible = true;
            UnityEngine.Cursor.lockState = CursorLockMode.None;
        }
        void ShowMenu2()
        {
            DialogueUI2.SetActive(true);
        }
        void ShowMenu4()
        {
           DialogueUI4.SetActive(true);
        }*/
    }






