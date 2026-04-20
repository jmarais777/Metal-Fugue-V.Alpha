using UnityEngine;

public class Lock : MonoBehaviour
{
    public GameObject ToCryo;
    public GameObject ScavenegrHandOnPlayer;
    public GameObject ScavenegrHandInGame;
    public GameObject ToScrapYard;
    public GameObject ToSecurity1;
    public GameObject ToSecurity2;
    public GameObject SecurityGateLocked;
    public GameObject SecurityGateUnlcoked;
    public GameObject bossTrig;

    public GameObject PowerButton;
    public float proximity = 5.0f;
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
            ToSecurity2.SetActive(false);
            SecurityGateLocked.SetActive(true);
            SecurityGateUnlcoked.SetActive(false);
            if(bossTrig != null)
            { bossTrig.SetActive(false); }
         
        }
        else
        {
            ToScrapYard.SetActive(true);
            ToSecurity1.SetActive(true);
            ToSecurity2.SetActive(true);
            SecurityGateLocked.SetActive(false);
            SecurityGateUnlcoked.SetActive(true);
            if (bossTrig != null)
            { bossTrig.SetActive(true); }
        }

        float PowBut = Vector2.Distance(PowerButton.transform.position, this.transform.position);
        if (Input.GetKeyUp(KeyCode.E) && PowBut <= proximity)
        {
            IsPowerOn = false;
        }

        if (SecurityGateUnlcoked.activeInHierarchy)
        {
            Boss.SetActive(true);
            if (Boss.activeInHierarchy && bossTrig != null)
            {
                Bossmove.enabled = false;
                Bossshoot.enabled = false;

            }
        }
        else
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


       
        float secgate = Vector2.Distance(SecurityGateUnlcoked.transform.position, this.transform.position);
        if(Input.GetKeyDown(KeyCode.E) && secgate <= proximity)
            {
            Debug.Log("Yippe you did it!!");

             }
    }
}
