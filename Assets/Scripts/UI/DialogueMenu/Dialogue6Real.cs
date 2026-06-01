using JetBrains.Annotations;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Dialogue6Real : MonoBehaviour
{

    public Label DialogueLinesLabel;
    public UIDocument ScavengerUIDOC;
    public VisualElement root;
    public Button nextButton;
    public GameObject ScavengerDialogueMenu6Object;
    public GameObject UILinker_6_real;
    public float InteractProximity = 3.0f;
    public string[] DialogueLines;
    public int DialogueIndex = 0;
    public QuestFinal quest;


   // public GameObject ScavenegrHeapGhostCondition;
    public GameObject TransitionCondition8;

    public Scav_Move_Final ScavMove;



    private void Update()
    {
        if (ScavengerDialogueMenu6Object != null && !ScavengerDialogueMenu6Object.activeSelf)
        {
            {
                if (TransitionCondition8.activeSelf == true)
                {
                    ShowMenu1();
                 
                }


            }
        }
    }

        void ShowMenu1()
        {
            ScavengerDialogueMenu6Object.SetActive(true);
        


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
           
            TransitionCondition8.SetActive(false);
            ScavMove.IsDialogueFinished = true;


            nextButton.SetEnabled(false);
            ScavengerDialogueMenu6Object.SetActive(false);
            //ScavenegrHeapGhostCondition.SetActive(false);
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
//Old dialogue update system
/* if (DialogueIndex >= DialogueLines.Length)
        {
            HideMenu1();
            return;
        }

        DialogueLinesLabel.text = DialogueLines[DialogueIndex];
*/