using JetBrains.Annotations;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Dialogue1 : MonoBehaviour
{

    public Label PlayerDialogueContainer;
    public UIDocument PlayDiaUI1;
    public VisualElement root;
    public Button NextButton;
    public GameObject PlayerDialogueMenu1;
    public string[] PlayerDialogueLines;
    public int DialogueIndex = 0;

    public GameObject TransitionCondition1;
    public GameObject TransitionCondition2;


    private void Update()
    {
        if (PlayerDialogueMenu1.activeSelf == false)
        {
            if (TransitionCondition1.activeInHierarchy == true)
            {

                ShowMenu1();

            }
        }



    }


    void ShowMenu1()
        {
        PlayerDialogueMenu1.SetActive(true);
    
            Time.timeScale = 0.0f;
            var Ui1 = PlayDiaUI1.GetComponent<UIDocument>();
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
        PlayerDialogueMenu1.SetActive(false);
        TransitionCondition2.SetActive(true);
        TransitionCondition1.SetActive(false);
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

  