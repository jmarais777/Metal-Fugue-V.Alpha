using JetBrains.Annotations;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Dialogue6 : MonoBehaviour
{

    public Label PlayerDialogueContainer;
    public UIDocument PlayDiaUI6;
    public VisualElement root;
    public Button NextButton;
    public GameObject PlayerDialogueMenu6;
    public string[] PlayerDialogueLines;
    public int DialogueIndex = 0;

    
    public GameObject TransitionCondition14;
    public GameObject TransitionCondition15;


    private void Update()
    {
        if (PlayerDialogueMenu6.activeSelf == false)
        {
            if (TransitionCondition14.activeInHierarchy == true)
            {

                ShowMenu1();

            }
        }



    }


    void ShowMenu1()
        {
        PlayerDialogueMenu6.SetActive(true);
    
            Time.timeScale = 0.0f;
            var Ui1 = PlayDiaUI6.GetComponent<UIDocument>();
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
            NextButton.clicked += NextButtonOnClick;
 
        }
        UpdateDialogueLines();

    }

    void HideMenu1()
    {
        NextButton.SetEnabled(false);
        PlayerDialogueMenu6.SetActive(false);
        TransitionCondition15.SetActive(true);
        TransitionCondition14.SetActive(false);
  
        Time.timeScale = 1.0f;
   
       

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
        else if(DialogueIndex >= PlayerDialogueLines.Length)
        {
            HideMenu1();
            return;
        }
    }
}

  