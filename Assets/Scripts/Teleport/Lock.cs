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
   // public GameObject SecurityGateUnlcoked;
    public GameObject bossTrig;

    public GameObject PowerButton;
    public float proximity = 10.0f;
    public GameObject Boss;
    public EnemyMovement Bossmove;
    public EnemySHootMech Bossshoot;
    
    public bool IsPowerOn = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Bossmove = Boss.GetComponent<EnemyMovement>();
        Bossshoot = Boss.GetComponent<EnemySHootMech>();

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
            ToScrapYard.SetActive(false);
            ToSecurity1.SetActive(false);
            FromSecurity.SetActive(false);
            SecurityGatePowerIndicator.SetActive(true);
           // SecurityGateUnlcoked.SetActive(false);
            if(bossTrig != null)
            { bossTrig.SetActive(false); }
         
        }
        else
        {
            ToScrapYard.SetActive(true);
            ToSecurity1.SetActive(true);
            FromSecurity.SetActive(true);
        
          //  SecurityGateUnlcoked.SetActive(true);
            if (bossTrig != null)
            { bossTrig.SetActive(true); }
            
        }
        float secgate = Vector2.Distance(SecurityGatePowerIndicator.transform.position, this.transform.position);
        float PowBut = Vector2.Distance(PowerButton.transform.position, this.transform.position);
        //Debug.Log("Dist to Gate: " + secgate + " | Dist to Power: " + PowBut);
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (PowBut <= proximity)
            { 
                   IsPowerOn = false;
                Debug.Log("PowerOff");

            }
            if (!IsPowerOn && secgate<= proximity)
            {
                Debug.Log("Yippe you did it!!");
                SceneManager.LoadScene("MainMenu");
            }
           
        }
       


        if (!IsPowerOn && Boss != null)
        {
            Boss.SetActive(true);
            if (Boss.activeInHierarchy && bossTrig != null)
            {
                Bossmove.enabled = false;
                Bossshoot.enabled = false;

            }
        }
        else if (Boss != null) 
        {
            Boss.SetActive(false);
        }

        if (bossTrig == null)
        {
            if (Bossmove != null && Bossshoot != null)
            {
                Bossmove.enabled = true;
                Bossshoot.enabled = true;
            }

           
        }


    
    }
}
