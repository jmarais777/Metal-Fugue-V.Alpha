using UnityEngine;
using System.Collections;

public class ElectricityPuzzle : MonoBehaviour
{
    public Collider2D ElectricityHitbox;
    public GameObject ElectricityBridge;
    public GameObject ElectricityMeterGreen;
    public GameObject ElectricityMeterRed;
    public float TimePassing;
    

    private void Start()
    {
        //set electric bridge to false, to prime the puzzle
        ElectricityBridge.SetActive(false);
        ElectricityMeterGreen.SetActive(false);
        ElectricityMeterRed.SetActive(true);
    }

    private void Update()
    {
       
            //set countdown timer for puzzle connections
            TimePassing += Time.deltaTime;
        if (TimePassing > 4)
        {
            ElectricityBridge.SetActive(false);
        }

        if (ElectricityBridge.activeSelf)
        {
            ElectricityMeterRed.SetActive(false);
            ElectricityMeterGreen.SetActive(true);
        }
       
        else
        {
            
                ElectricityMeterGreen.SetActive(false);
            
         
                ElectricityMeterRed.SetActive(true);
            
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when bullets hit, activate the electricity bridge
        if (collision.gameObject.CompareTag("Bullets"))
        {
            ElectricityBridge.SetActive(true);
            Destroy(collision.gameObject);
            
            //reset timer per each collision with the puzzle collider so that it lasts the full 4 seconds
            TimePassing = 0;
        }

       
    }
}
