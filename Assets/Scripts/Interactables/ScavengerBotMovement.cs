using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScavengerBotMovement : MonoBehaviour
{
   // public GameObject ScavengerBot;
    public Transform scavp1;

    public Transform Scavpos2;
    public GameObject scrapHeap;

 

    public GameObject dialogueUI3;
    public GameObject ScavBot;

    
  
    public bool IsHeapActive = true;
    public bool IsDialogueStart = false;
    
    public float MoveSpeed = 5.0f;
    //public ScrapHeapsShuttle heap;


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
                dialogueUI3.SetActive(true);
                IsDialogueStart = false;
            }
            if (this.transform.position == Scavpos2.position)
            {
                Debug.Log("AtP2");
                this.enabled = false;
                dialogueUI3.SetActive(false);
            }

        }
        this.transform.position = Vector3.MoveTowards(this.transform.position, scavp1.position, MoveSpeed * Time.deltaTime);

    
        
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