using JetBrains.Annotations;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Dialogue11Real : MonoBehaviour
{

    public Label DialogueLinesLabel;
    public UIDocument ScavengerUIDOC;
    public VisualElement root;
    public Button nextButton;
    public GameObject ScavengerDialogueMenu11Object;
    public GameObject UILinker_11_real;
    public float InteractProximity = 3.0f;
    public string[] DialogueLines;
    public int DialogueIndex = 0;

    public QuestFinal quest;
    public GameObject TransitionCondition15;

    public Dialogue10Real Dia10;
    public EnergyPool EnergyPool_Scr;


    private void Update()
    {
        if (ScavengerDialogueMenu11Object != null && !ScavengerDialogueMenu11Object.activeSelf)
        {
            {
                if (TransitionCondition15.activeSelf == true)
                {
                    ShowMenu1();
                
                }


            }
        }

        void ShowMenu1()
        {
            ScavengerDialogueMenu11Object.SetActive(true);

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
          
            TransitionCondition15.SetActive(false);
            EnergyPool_Scr.CurrentAmmo = Dia10.AmmoSave;
            nextButton.SetEnabled(false);
            ScavengerDialogueMenu11Object.SetActive(false);
            Time.timeScale = 1.0f;
            quest.QuestObjectives_Enum = QuestFinal.QuestObjective.O10;
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