using Unity.VisualScripting;
using UnityEngine;

public class ScavengerBotMovement : MonoBehaviour
{
   // public GameObject ScavengerBot;
    public Transform scavp1;
    public GameObject scrapHeap;
  
    public bool IsHeapActive = true;
    
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
            IsHeapActive = true;
            Debug.Log("HeapActive");
        }
        if (scrapHeap.gameObject.activeInHierarchy == false)
        {

            Debug.Log("ScrapHeaps destroyed.");
            this.transform.eulerAngles = new Vector3(0, 0, 140);

            if(this.transform.eulerAngles.z == 140)
            {

            }




            this.transform.position = Vector3.MoveTowards(this.transform.position, scavp1.position, MoveSpeed * Time.deltaTime);
        }
        
    }
}
