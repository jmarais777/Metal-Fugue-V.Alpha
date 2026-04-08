using UnityEngine;
using UnityEngine.UIElements;

public class EnergyText : MonoBehaviour
{
    //Display CurrentPool on EnergyMeter
    //Title: Unity UI Toolkit in 5 Minutes
    //Author: MadCat Tutorials
    //Date: 05/04/2026
    //Availiability: https://www.youtube.com/watch?v=yUXFHAOXhcA

    //calling EnergyPool for Current Energy
    public EnergyPool ForCurrentEnergy;

    private Label CurrentEnergyOutputReading;

    private void OnEnable()
    {
        //Call Label
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        CurrentEnergyOutputReading = root.Q<Label>("CurrentEnergyOutputReading");
    }

    void Update()
    {
        //Define output of label
        CurrentEnergyOutputReading.text = " " + ForCurrentEnergy.CurrentEnergy + "%";
    }
}