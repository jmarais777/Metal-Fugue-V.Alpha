using UnityEngine;

public class PuzzleDoorOpen : MonoBehaviour
{
    public GameObject ElectricityBridge;
    public GameObject ElectricityBridge1;
    public GameObject ElectricityBridge2;
    public GameObject ElectricityPuzzleDoor;
    public AudioSource ElectricityPuzzleDoorOpen;
    public AudioSource ElectricityPuzzleDoorClose;
    bool puzzleSolved;

    void Awake()
    {
        ElectricityPuzzleDoor.SetActive(true);
        puzzleSolved = false;
    }

    void Update()
    {
        bool solved =
            ElectricityBridge.activeSelf && ElectricityBridge1.activeSelf && ElectricityBridge2.activeSelf;

        if (solved && !puzzleSolved)
        {
            puzzleSolved = true;
            ElectricityPuzzleDoorOpen.PlayOneShot(ElectricityPuzzleDoorOpen.clip);
            ElectricityPuzzleDoor.SetActive(false);
        }

        else if (!solved && puzzleSolved)
        {
            puzzleSolved = false;

            ElectricityPuzzleDoor.SetActive(true);
            ElectricityPuzzleDoorClose.PlayOneShot(ElectricityPuzzleDoorClose.clip);
        }
    }
}
