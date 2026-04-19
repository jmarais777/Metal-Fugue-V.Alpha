using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Dialogue1 : MonoBehaviour
{
    public GameObject Enemy;
    private Button nextButton;
    public Label DialogueLines;
    public string[] ScavengerLines;
    public int DialogueList = 0;
    public GameObject DialogueUi1;
    public GameObject linkerGhost1;
    public EnemyMovement enemySriptMove;
    public EnemySHootMech enemyScriptShoot;

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
        DialogueUi1.SetActive(false);
        ShowGameObject();
      
    }
    void ShowGameObject()
    {
        enemySriptMove.enabled = true;
        enemyScriptShoot.enabled = true;

        linkerGhost1.SetActive(false);
    }
}

