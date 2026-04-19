using UnityEngine;

public class PuzzleDoorOpen : MonoBehaviour
{
    public GameObject ElectricityBridge;
    public GameObject ElectricityBridge1;
    public GameObject ElectricityBridge2;
    public GameObject ElectricityPuzzleDoor;

    void Start()
    {
        //primes door for puzzle, prevents players from progressing
        ElectricityPuzzleDoor.SetActive(true);
    }
    void Update()
    {
        // requries all ElectricityBridges to be active for the door to open
        if (ElectricityBridge.activeSelf && ElectricityBridge1.activeSelf && ElectricityBridge2.activeSelf)
        {
            ElectricityPuzzleDoor.SetActive(false);
        }
        else
        { 
            //ensures the door closes after timer elapses
            ElectricityPuzzleDoor.SetActive(true);
        }
    }
}
