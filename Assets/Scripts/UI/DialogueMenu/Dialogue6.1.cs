using JetBrains.Annotations;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Dialogue61Player: MonoBehaviour
{

    public Label PlayerDialogueContainer;
    public UIDocument PlayDiaUI2;
    public VisualElement root;
    public Button NextButton;
    public GameObject PlayerDialogueMenu2;
    public string[] PlayerDialogueLines;
    public int DialogueIndex = 0;


    public GameObject TransitionCondition81;
    public GameObject TransitionCondition82;


    private void Update()
    {
        if (!PlayerDialogueMenu2.activeSelf && TransitionCondition81.activeInHierarchy)
        {
           

                ShowMenu1();

            
        }



    }


    public void ShowMenu1()
    {
        PlayerDialogueMenu2.SetActive(true);

        Time.timeScale = 0.0f;
        var Ui1 = PlayDiaUI2.GetComponent<UIDocument>();
        if (Ui1 == null || Ui1.rootVisualElement == null)
        {
            return;

        }
        if (Ui1 != null)
        {
            var root = Ui1.rootVisualElement;
            NextButton = root.Q<Button>("NextButton");
            PlayerDialogueContainer = root.Q<Label>("PlayerDialogueContainer");

        }

        if (NextButton != null)
        {
            NextButton.clicked -= NextButtonOnClick;
            NextButton.clicked += NextButtonOnClick;

        }
        UpdateDialogueLines();

    }

    void HideMenu1()
    {
        
        NextButton.SetEnabled(false);
        PlayerDialogueMenu2.SetActive(false);
        TransitionCondition82.SetActive(true);
        TransitionCondition81.SetActive(false);
        // PlayDiaUI1.enabled = false;
        Time.timeScale = 1.0f;
        //PlayDiaUI1.enabled = false;


    }


    void NextButtonOnClick()
    {

        DialogueIndex++;
        UpdateDialogueLines();

        Debug.Log("Clicking");


    }
    void UpdateDialogueLines()
    {

        if (DialogueIndex < PlayerDialogueLines.Length)
        {
            PlayerDialogueContainer.text = PlayerDialogueLines[DialogueIndex];
        }
        else if (DialogueIndex >= PlayerDialogueLines.Length)
        {
            HideMenu1();
            return;
        }
    }
}

