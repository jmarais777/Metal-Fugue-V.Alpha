using JetBrains.Annotations;
using System.Linq;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Dialogue10Real : MonoBehaviour
{

    public Label DialogueLinesLabel;
    public UIDocument ScavengerUIDOC;
    public VisualElement root;
    public Button nextButton;
    public GameObject ScavengerDialogueMenu10Object;
    public GameObject UILinker_10_real;
    public float InteractProximity = 3.0f;
    public string[] DialogueLines;
    public int DialogueIndex = 0;
    public GameObject Player;
    public GameObject ScavengerArmOnPlayer;
    public GameObject ScavengerArmOnScavP;

    public GameObject TransitionCondition14;
    public bool isUiDisplaying2;



    private void Update()
    {
        if (isUiDisplaying2 == true)
        {
            Time.timeScale = 0.0f;
        }
        if (UILinker_10_real != null && !ScavengerDialogueMenu10Object.activeSelf)
        {
            {
                float uilinker10 = Vector2.Distance(UILinker_10_real.transform.position, Player.transform.position);

                if (Input.GetKeyDown(KeyCode.E))

                    if (uilinker10 < InteractProximity)
                    {
                        if (ScavengerArmOnPlayer.activeSelf == true)
                        {

                            ScavengerArmOnScavP.SetActive(true);
                            ScavengerArmOnPlayer.SetActive(false);
                            ShowMenu1();

                        }
                    }
                

            }
        }

        void ShowMenu1()
        {
            ScavengerDialogueMenu10Object.SetActive(true);
            isUiDisplaying2 = true;
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
           
           
            TransitionCondition14.SetActive(true);
            nextButton.SetEnabled(false);
            ScavengerDialogueMenu10Object.SetActive(false);
            isUiDisplaying2 = false;
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