using JetBrains.Annotations;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Dialogue4 : MonoBehaviour
{

    public Label PlayerDialogueContainer;
    public UIDocument PlayDiaUI4;
    public VisualElement root;
    public Button NextButton;
    public GameObject PlayerDialogueMenu4;
    public string[] PlayerDialogueLines;
    public int DialogueIndex = 0;

    
   // public GameObject TransitionCondition5;
    public GameObject TransitionCondition10;
    public GameObject TransitionCondition11;

    private void Update()
    {
        if (PlayerDialogueMenu4.activeSelf == false)
        {
            if (TransitionCondition10.activeInHierarchy == true)
            {

                ShowMenu1();

            }
        }



    }


    void ShowMenu1()
        {
        PlayerDialogueMenu4.SetActive(true);
    
            Time.timeScale = 0.0f;
            var Ui1 = PlayDiaUI4.GetComponent<UIDocument>();
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
        PlayerDialogueMenu4.SetActive(false);
        TransitionCondition10.SetActive(false);
        TransitionCondition11.SetActive(true);
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

  