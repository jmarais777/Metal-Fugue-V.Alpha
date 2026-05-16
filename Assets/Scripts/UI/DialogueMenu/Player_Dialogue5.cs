using JetBrains.Annotations;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Dialogue5 : MonoBehaviour
{

    public Label PlayerDialogueContainer;
    public UIDocument PlayDiaUI5;
    public VisualElement root;
    public Button NextButton;
    public GameObject PlayerDialogueMenu5;
    public string[] PlayerDialogueLines;
    public int DialogueIndex = 0;

    
   // public GameObject TransitionCondition5;
    public GameObject TransitionCondition12;
    public GameObject TransitionCondition13;

    private void Update()
    {
        if (PlayerDialogueMenu5.activeSelf == false)
        {
            if (TransitionCondition12.activeInHierarchy == true)
            {

                ShowMenu1();

            }
            else if (TransitionCondition13.activeInHierarchy == true)
            {
                HideMenu1();
            }
        }



    }


    void ShowMenu1()
        {
        PlayerDialogueMenu5.SetActive(true);
    
            Time.timeScale = 0.0f;
            var Ui1 = PlayDiaUI5.GetComponent<UIDocument>();
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
        PlayerDialogueMenu5.SetActive(false);
        TransitionCondition12.SetActive(false);
        TransitionCondition13.SetActive(true);
      //  Time.timeScale = 1.0f;
        Debug.Log("Hidden");
     
       

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

  