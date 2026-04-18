using UnityEngine;
using System.Collections;

public class ElectricityPuzzle : MonoBehaviour
{
    public Collider2D ElectricityHitbox;
    public GameObject ElectricityBridge;
    public float TimePassing;

    private void Start()
    {
        ElectricityBridge.SetActive(false);
    }

    private void Update()
    {
        TimePassing += Time.deltaTime;
        if (TimePassing > 4)
        {
            ElectricityBridge.SetActive(false);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bullets"))
        {
            Debug.Log("Fuck You Game");
            ElectricityBridge.SetActive(true);
            Destroy(collision.gameObject);
            TimePassing = 0;
        }

       
    }
}
