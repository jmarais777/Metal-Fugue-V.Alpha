using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Dialogue3 : MonoBehaviour
{
   
    private Button nextButton;
    public Label DialogueLines;
    public string[] ScavengerLines;
    public int DialogueIndex = 0;
    public GameObject DialogueUi3;
    public ScavengerBotMovement scavmove;
    public UIDocument dialogueui;


    void OnEnable()

    {
        if (dialogueui == null || dialogueui.rootVisualElement == null)
        {
            return;
        }
        scavmove.enabled = false;
        var root = GetComponent<UIDocument>().rootVisualElement;

        nextButton = root.Q<Button>("next");
        DialogueLines = root.Q<Label>("DialogueLines");
        DialogueIndex = 0;


        if (nextButton != null)
        {
            nextButton.clicked += NextButtonOnClick;
            UpdateDialogueLines();
            Debug.Log("Next button found and linked!");

        }
    }

    private void NextButtonOnClick()
    {
        DialogueIndex++;
        UpdateDialogueLines();




    }
    void UpdateDialogueLines()
    {
        if (DialogueIndex >= ScavengerLines.Length)
        {
            Debug.Log("shouldEnd");
            EndDialogue3();
            return;
        
        }

        DialogueLines.text = ScavengerLines[DialogueIndex];
    }
    void EndDialogue3()
    {
        if(scavmove != null)
        {
            scavmove.enabled = true;
        }
        
        nextButton.SetEnabled(false);
        DialogueUi3.SetActive(false);
        GetComponent<UIDocument>().enabled = false;
       
       // ShowGameObject();

    }
    /*void ShowGameObject()
    {
        Enemy.SetActive(true);
    } */
}

