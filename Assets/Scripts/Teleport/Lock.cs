using UnityEngine;
using UnityEngine.SceneManagement;

public class Lock : MonoBehaviour
{
    public GameObject ToCryo;
    public GameObject ScavenegrHandOnPlayer;
    public GameObject ScavenegrHandInGame;
    public GameObject ToScrapYard;
    public GameObject ToSecurity1;
    public GameObject FromSecurity;
    public GameObject SecurityGatePowerIndicator;
    public ConditionalAudios ForPowerDownCheck;

   // public GameObject SecurityGateUnlcoked;
    public GameObject bossTrig;

    public GameObject PowerButton;
    public float proximity = 10.0f;
    public GameObject Boss;
    //public EnemyMovement Bossmove;
   // public EnemySHootMech Bossshoot;
    public GameObject CryCombsAudioCondition;
    public QuestTracker quest;
    public GameObject Quest_OutOfTheFryingPan_Objective1;

    public EnemyMovementFinalFin8 Enemy_Move_Fin8;
    public EnemyMovementFinalFinBoss BossScr;
    public Enemy_Trigger_EventsFin8 Enemy_Trigger_Events8;
    //public EnemyPlayerDetectingFin8 Enemy_Detect_8;

    public bool IsPowerOn = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
    // Bossmove = Boss.GetComponent<EnemyMovement>();
    // Bossshoot = Boss.GetComponent<EnemySHootMech>();

    // }
    private void Start()
    {
        IsPowerOn = true;
    }
    // Update is called once per frame
    void Update()
    {
      
        if (ScavenegrHandInGame.activeInHierarchy || ScavenegrHandOnPlayer.activeInHierarchy)
        {
            ToCryo.SetActive(false);
        }
        else
        {
            ToCryo.SetActive(true);
        }
        if (IsPowerOn == true)
        {
            Enemy_Move_Fin8.enabled = false;
            Enemy_Move_Fin8.ForceField_Collider.enabled = false;
            Enemy_Move_Fin8.Player_Detection_Collider.enabled = false;

            

            ToScrapYard.SetActive(false);
            ToSecurity1.SetActive(false);
            FromSecurity.SetActive(false);
            SecurityGatePowerIndicator.SetActive(true);
            // SecurityGateUnlcoked.SetActive(false);
            if (bossTrig != null)
            { bossTrig.SetActive(false); }
         
        }
        else
        {
            Debug.Log("power disabled");
            Enemy_Move_Fin8.enabled = true;
            Enemy_Move_Fin8.ForceField_Collider.enabled = true;
            Enemy_Move_Fin8.Player_Detection_Collider.enabled = true;
            ToScrapYard.SetActive(true);
            ToSecurity1.SetActive(true);
            FromSecurity.SetActive(true);
            Quest_OutOfTheFryingPan_Objective1.SetActive(true);
            quest.IsQ2ObjectiveUpdate11 = true;
            //  SecurityGateUnlcoked.SetActive(true);
            if (bossTrig != null)
            { bossTrig.SetActive(true); }
           // ForPowerDownCheck.PowerDownCheck = true;

        }
        float secgate = Vector2.Distance(SecurityGatePowerIndicator.transform.position, this.transform.position);
        float PowBut = Vector2.Distance(PowerButton.transform.position, this.transform.position);
        Debug.Log( PowBut);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PowBut <= proximity)
            { 
                   IsPowerOn = false;
                ForPowerDownCheck.TriggerPowerDown();
                    Debug.Log("PowerOff");

            }
            if (!IsPowerOn && secgate<= proximity)
            {
                Debug.Log("Yippe you did it!!");
                SceneManager.LoadScene("VictoryScreen");
            }
           
        }
       


        if (!IsPowerOn && Boss != null)
        {
        
          
            //  Enemy_Move_Fin8.IsUnlocked = true;
            Boss.SetActive(true);
            BossScr.enabled = false;
            BossScr.Enemy_Shoot_Mech.enabled = false;
            //Enemy_Move_Fin8.Move_Type = EnemyMovementFinalFin8.EnemyMovementType.Chasing;
   
            
        }
        else if (Boss != null) 
        {
            Boss.SetActive(false);
        }

        if (bossTrig == null)
        {

            BossScr.enabled = true;
            //BossScr.ForceField_Collider.enabled = true;
            //BossScr.Player_Detection_Collider.enabled = true;
            //    BossScr.Move_Type = EnemyMovementFinalFinBoss.EnemyMovementType.Chasing;
            /* if (Bossmove != null && Bossshoot != null)
             {
                 Bossmove.enabled = true;
                 Bossshoot.enabled = true;
                 quest.IsQ2ObjectiveUpdate13 = true;
             } */


        }


    
    }
}
