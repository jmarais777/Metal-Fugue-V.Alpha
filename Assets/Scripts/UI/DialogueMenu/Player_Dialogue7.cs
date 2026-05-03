using JetBrains.Annotations;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Dialogue7 : MonoBehaviour
{

    public Label PlayerDialogueContainer;
    public UIDocument PlayDiaUI7;
    public VisualElement root;
    public Button NextButton;
    public GameObject PlayerDialogueMenu7;
    public string[] PlayerDialogueLines;
    public int DialogueIndex = 0;

    
    
    public GameObject TransitionCondition16;


    private void Update()
    {
        if (PlayerDialogueMenu7.activeSelf == false)
        {
            if (TransitionCondition16.activeInHierarchy == true)
            {

                ShowMenu1();

            }
        }



    }


    void ShowMenu1()
        {
        PlayerDialogueMenu7.SetActive(true);
    
            Time.timeScale = 0.0f;
            var Ui1 = PlayDiaUI7.GetComponent<UIDocument>();
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
        PlayerDialogueMenu7.SetActive(false);
        
        TransitionCondition16.SetActive(false);
  
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

  