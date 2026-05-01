using JetBrains.Annotations;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Dialogue3 : MonoBehaviour
{

    public Label PlayerDialogueContainer;
    public UIDocument PlayDiaUI3;
    public VisualElement root;
    public Button NextButton;
    public GameObject PlayerDialogueMenu3;
    public string[] PlayerDialogueLines;
    public int DialogueIndex = 0;

    
   // public GameObject TransitionCondition5;
    public GameObject TransitionCondition6;
    public GameObject TransitionCondition7;

    private void Update()
    {
        if (PlayerDialogueMenu3.activeSelf == false)
        {
            if (TransitionCondition6.activeInHierarchy == true)
            {

                ShowMenu1();

            }
        }



    }


    void ShowMenu1()
        {
        PlayerDialogueMenu3.SetActive(true);
    
            Time.timeScale = 0.0f;
            var Ui1 = PlayDiaUI3.GetComponent<UIDocument>();
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
        PlayerDialogueMenu3.SetActive(false);
        TransitionCondition6.SetActive(false);
        TransitionCondition7.SetActive(true);
       // TransitionCondition5.SetActive(false);
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
        else if(DialogueIndex >= PlayerDialogueLines.Length)
        {
            HideMenu1();
            return;
        }
    }
}

  