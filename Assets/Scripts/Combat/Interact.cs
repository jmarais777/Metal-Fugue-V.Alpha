using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;


public class Interact : MonoBehaviour
{
    //each of these are an object that the player can interact with in the game.
    public GameObject Artifact;
    public GameObject Player;
    //public Transform ScavengerBot;
  //  public Transform UiLinker4;
    public GameObject Enemy;
   // public bool IsLinkerActive = true;

  //  public GameObject DialogueUI1;
   // public Transform UiLinker1;
    //public GameObject linkerGhost1;

   // public GameObject DialogueUI2;
   // public GameObject UiLinker2;

   // public GameObject DialogueUI4;

    public GameObject ScavengerArmIngame;
    public GameObject ScavengerArmOnPlayer;
    public GameObject scavengerArmOnScav;

    //

    public Transform RechargeStation;
    public GameObject CorticalProcessor;
    public GameObject CorticalProcessorEye;
    public GameObject SecurityGate;
    public Light2D CorticalProcessorLight;
    public EnergyPool ForCurrentEnergy;
    public bool IsPlayerInProximity = true;
    public float InteractProximity = 20f; //this basically just lets you do some maths later on. Once this entire script is complete, you can change the numebr to get smaller or larger proximities.

    public EnergyPool CurrentEnergyPool;




    void Update()
    {
        float Artdistance = Vector2.Distance(Artifact.transform.position, Player.transform.position); //This line of code, calculates the distance between the 'Artifact' item, and the player. This value is the applie to teh the word, "Artdistance".

        //These lines of code do the the exact same thing as the code above, for each interactable object that was listed earlier.
     
        //float uiLinker1 = Vector2.Distance(UiLinker1.position, Player.transform.position);
        //float uiLinker2 = Vector2.Distance(UiLinker2.transform.position, Player.transform.position);
        float RechargeStat = Vector2.Distance(RechargeStation.position, Player.transform.position);
        float Cort = Vector2.Distance(CorticalProcessor.transform.position, Player.transform.position);
        float Sec = Vector2.Distance(SecurityGate.transform.position, Player.transform.position);
        float Scavarm = Vector2.Distance(ScavengerArmIngame.transform.position, Player.transform.position);
        //  float uilinker4 = Vector2.Distance(UiLinker4.transform.position, Player.transform.position);
        if (Input.GetKeyDown(KeyCode.E)) Debug.Log("E pressed. Distance to Arm is: " + Scavarm); //arm is to far away??


        if (Input.GetKeyDown(KeyCode.E)) //If the E key is pressed 
        {
           //THEN, this bool (declared with the game objects at the top) is set to "True"

            if (Artdistance < InteractProximity) // This cheaks if the "Artdistance" (Which now contains the value mentioned above) is less than the value of the inetract proximity. If the value is less THEN: the DebugLog will be displayed.
            {

                Debug.Log("hoho"); //

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
                    CorticalProcessorLight.pointLightInnerRadius = 10f;
                    CorticalProcessorLight.pointLightOuterRadius = 12f;
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


         /*if (Input.GetKeyDown(KeyCode.E))
         {
             IsPlayerInProximity = true;

             if (RechargeStat < InteractProximity)
             {


                 ForCurrentEnergy.CurrentEnergy += ForCurrentEnergy.MaxEnergy;
                 ForCurrentEnergy.CurrentEnergy = Mathf.Clamp(ForCurrentEnergy.CurrentEnergy, 0, 100);
             }
         }*/



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






