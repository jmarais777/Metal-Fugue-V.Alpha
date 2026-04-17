using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Dialogue : MonoBehaviour
{
    public GameObject Enemy;
    private Button nextButton;
    public Label DialogueLines;
    public string[] ScavengerLines;
    public int DialogueList = 0;
    public GameObject DialogueUi;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        nextButton = root.Q<Button>("next");
        DialogueLines = root.Q<Label>("DialogueLines");


        if (nextButton != null)
        {
            nextButton.clicked += NextButtonOnClick;
            Debug.Log("Next button found and linked!");

        }
        
    }

    private void NextButtonOnClick()
    {
        DialogueList++;
        UpdateDialogueLines();




    }
    void UpdateDialogueLines()
    {
        if (DialogueList >= ScavengerLines.Length)
        {
            EndDialogue();
            return;
        }
        
        DialogueLines.text = ScavengerLines[DialogueList];
    }
    void EndDialogue()
    {
        nextButton.SetEnabled(false);
        DialogueUi.SetActive(false);
        ShowGameObject();
      
    }
    void ShowGameObject()
    {
        Enemy.SetActive(true);
    }
}

