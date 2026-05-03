using JetBrains.Annotations;
using System.Linq;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Dialogue12Real : MonoBehaviour
{

    public Label DialogueLinesLabel;
    public UIDocument ScavengerUIDOC;
    public VisualElement root;
    public Button nextButton;
    public GameObject ScavengerDialogueMenu12Object;
    public GameObject UILinker_12_real;
    public float InteractProximity = 3.0f;
    public string[] DialogueLines;
    public int DialogueIndex = 0;
    public GameObject Player;

    public bool isUiDisplaying3;
    public GameObject TransitionCondition16;
    public Lock locky;
   
   

    private void Update()
    {
        if (isUiDisplaying3 == true)
        {
            Time.timeScale = 0.0f;
        }
        if (UILinker_12_real != null && !ScavengerDialogueMenu12Object.activeSelf)
        {
            {
                float uilinker12 = Vector2.Distance(UILinker_12_real.transform.position, Player.transform.position);

                if (Input.GetKeyDown(KeyCode.E))

                    if (uilinker12 < InteractProximity)
                    {
                        if (locky.IsPowerOn == false)
                        {


                            ShowMenu1();

                        }
                    }
                

            }
        }

        void ShowMenu1()
        {
            ScavengerDialogueMenu12Object.SetActive(true);
            isUiDisplaying3 = true;
            Time.timeScale = 0.0f;
            var Ui1 = ScavengerUIDOC.GetComponent<UIDocument>();
            if (Ui1 == null || Ui1.rootVisualElement == null)
            {
                return;

            }
            if (Ui1 != null)
            {
                var root = Ui1.rootVisualElement;
                nextButton = root.Q<Button>("next");
                DialogueLinesLabel = root.Q<Label>("DialogueLinesLabel");

            }
            if (nextButton != null)
            {
                nextButton.clicked += NextButtonOnClick;

            }
            UpdateDialogueLines();

        }

        void HideMenu1()
        {
           
           
            TransitionCondition16.SetActive(true);
            nextButton.SetEnabled(false);
            ScavengerDialogueMenu12Object.SetActive(false);
            isUiDisplaying3 = false;
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
            if (DialogueIndex < DialogueLines.Length)
            {
                DialogueLinesLabel.text = DialogueLines[DialogueIndex];
            }
            else if (DialogueIndex >= DialogueLines.Length)
            {
                HideMenu1();
                return;
            }


        }
    }
}
//Old dialogue update system
/* if (DialogueIndex >= DialogueLines.Length)
        {
            HideMenu1();
            return;
        }

        DialogueLinesLabel.text = DialogueLines[DialogueIndex];
*/