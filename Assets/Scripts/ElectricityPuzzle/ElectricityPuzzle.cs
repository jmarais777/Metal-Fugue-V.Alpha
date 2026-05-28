using UnityEngine;
using System.Collections;

public class ElectricityPuzzle : MonoBehaviour
{
    public Collider2D ElectricityHitbox;
    public GameObject ElectricityBridge;
    public GameObject ElectricityMeterGreen;
    public GameObject ElectricityMeterRed;
    public float TimePassing;
    public AudioSource Electricity;
    bool _wasActive;

    private void Start()
    {
        //set electric bridge to false, to prime the puzzle
        ElectricityBridge.SetActive(false);
        ElectricityMeterGreen.SetActive(false);
        ElectricityMeterRed.SetActive(true);

        _wasActive = false;
    }

    private void Update()
    {
       
            //set countdown timer for puzzle connections
            TimePassing += Time.deltaTime;

        if (TimePassing > 4)
        {
            ElectricityBridge.SetActive(false);
            TimePassing = 0;
        }

        bool _isActive = ElectricityBridge.activeSelf;

        if (_isActive && !_wasActive)
        {
            Electricity.PlayOneShot(Electricity.clip);
            ElectricityMeterRed.SetActive(false);
            ElectricityMeterGreen.SetActive(true);
        }
       
        else if (!_isActive && _wasActive)
        {
            
                ElectricityMeterGreen.SetActive(false);
            
         
                ElectricityMeterRed.SetActive(true);
            
        }

        _wasActive = _isActive;
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

   /* private void ElectricityPlayer()
    {

    }*/
}
