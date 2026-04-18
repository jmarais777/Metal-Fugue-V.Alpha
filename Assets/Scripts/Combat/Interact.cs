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
    public Transform ScavengerBot;
    public GameObject Enemy;
    public bool IsLikerActive = true;

    public GameObject DialogueUI1;
    public GameObject UiLinker1;
    public GameObject linkerGhost1;

    public GameObject DialogueUI2;
    public GameObject UiLinker2;


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
     
        float uiLinker1 = Vector2.Distance(ScavengerBot.position, Player.transform.position);
        float uiLinker2 = Vector2.Distance(ScavengerBot.position, Player.transform.position);
        float RechargeStat = Vector2.Distance(RechargeStation.position, Player.transform.position);
        float Cort = Vector2.Distance(CorticalProcessor.transform.position, Player.transform.position);
        float Sec = Vector2.Distance(SecurityGate.transform.position, Player.transform.position);
        
        if (Input.GetKeyDown(KeyCode.E)) //If the E key is pressed 
        {
            IsPlayerInProximity = true; //THEN, this bool (declared with the game objects at the top) is set to "True"

            if (Artdistance < InteractProximity) // This cheaks if the "Artdistance" (Which now contains the value mentioned above) is less than the value of the inetract proximity. If the value is less THEN: the DebugLog will be displayed.
            {

                Debug.Log("hoho"); //

            }
        }

       //These otehr id statements do the exact same thing, just for diffferent objects. teh big difference is what actually happens when each object is interacted with.

        if (Input.GetKeyDown(KeyCode.E))
        {
            IsPlayerInProximity = true;

            if (uiLinker1 < InteractProximity)
            {
                ShowMenu1();

            }
        }

        if (Enemy.activeInHierarchy)
        {
            IsLikerActive = true;
           
        }
        else
        {
            IsLikerActive = false;
        }
         
        if (Input.GetKeyDown(KeyCode.E)&& IsLikerActive == false)
            {
                IsPlayerInProximity = true;

                if (uiLinker2 < InteractProximity)
                {
                ShowMenu2();

                }
            }



        if (Input.GetKeyDown(KeyCode.E))
        {
            IsPlayerInProximity  = false;
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

            if (Sec < InteractProximity)
            {
                CurrentEnergyPool.CurrentEnergy -= 5;

            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                IsPlayerInProximity = true;

                if (Cort < InteractProximity)
                {
                    //SetActive, basically controls weatehr or not an obect is visbale on screen. (false means invisivle) (true means visble)

                    CorticalProcessor.SetActive(false); //This makes the Cortical procssor object go invisible when interacted with.
                    CorticalProcessorEye.SetActive(true); // At teh same time, the cortical processorEye object is made visible!.

                    //these are just lighting controlls.
                    CorticalProcessorLight.pointLightInnerRadius = 10f;
                    CorticalProcessorLight.pointLightOuterRadius = 12f;
                }
            }


        }
        //this is for our Ui,but its not working properly yet so don't try to learn from it.
        void ShowMenu1()
        {
            DialogueUI1.SetActive(true);
            UnityEngine.Cursor.visible = true;
            UnityEngine.Cursor.lockState = CursorLockMode.None;
        }
        void ShowMenu2()
        {
            DialogueUI2.SetActive(true);
        }
    }
}





