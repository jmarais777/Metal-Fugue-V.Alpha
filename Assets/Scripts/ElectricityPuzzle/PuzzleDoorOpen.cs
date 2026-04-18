using UnityEngine;

public class PuzzleDoorOpen : MonoBehaviour
{
    public GameObject ElectricityBridge;
    public GameObject ElectricityBridge1;
    public GameObject ElectricityBridge2;
    public GameObject ElectricityPuzzleDoor;

    void Start()
    {
        ElectricityPuzzleDoor.SetActive(true);
    }
    void Update()
    {
        if (ElectricityBridge.activeSelf && ElectricityBridge1.activeSelf && ElectricityBridge2.activeSelf)
        {
            ElectricityPuzzleDoor.SetActive(false);
        }
        else
        { 
            ElectricityPuzzleDoor.SetActive(true);
        }
    }
}
