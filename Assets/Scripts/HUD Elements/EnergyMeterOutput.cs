using UnityEngine;
using UnityEngine.UIElements;

public class EnergyText : MonoBehaviour
{
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