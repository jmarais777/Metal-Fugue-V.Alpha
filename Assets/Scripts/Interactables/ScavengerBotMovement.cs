using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScavengerBotMovement : MonoBehaviour
{
    // public GameObject ScavengerBot;
    public Transform scavp1;

    public Transform Scavpos2;
    public GameObject scrapHeap;



    public GameObject TransitionCondition8;

    public GameObject ScavBot;





    public bool IsHeapActive = true;
    public bool IsDialogueStart = false;

    public float MoveSpeed = 5.0f;
    public Dialogue61Player DialScri61;
    public Dialogue6Real DialScri6;
    //public ScrapHeapsShuttle heap;
    public GameObject ConditionCOndition;
    public GameObject UIlinker7;


    void Start()
    {
        GetComponent<ScrapHeapsShuttle>();
    }
    void Update()
    {


        //Vector3 direction = scavp1.position - ScavengerBot.transform.position;
        if (scrapHeap.gameObject.activeInHierarchy) //forgott to get the bool conidition
        {
            // this.enabled = true;
            return;

            // Debug.Log("HeapActive");
        }


        if (scrapHeap.gameObject.activeInHierarchy == false)
        {

            IsDialogueStart = true;

            if (IsDialogueStart == true)
            {
                this.transform.eulerAngles = new Vector3(0, 0, 140);
                TransitionCondition8.SetActive(true);

            }



            if (this.transform.position == Scavpos2.position)
            {
                Debug.Log("AtP2");

                this.enabled = false;
                UIlinker7.SetActive(true);

            }

            MovemnetLogic();
        }
    }



    void MovemnetLogic()
    {

        if (Time.timeScale == 0.0f)
        {
            return;

        }
        else if (Time.timeScale == 1.0f)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, scavp1.position, MoveSpeed * Time.deltaTime);


        }


    }
}





/* private void OnTriggerEnter2D(Collider2D collision)
 {
     if (collision.gameObject.CompareTag("ToShuttle"))
     {
         this.gameObject.SetActive(false);
         this.enabled = false;
     } 



 } */