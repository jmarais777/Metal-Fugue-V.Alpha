using JetBrains.Annotations;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static EnemyMovementRev;

public class Dialogue3Real : MonoBehaviour
{

    public Label DialogueLinesLabel;
    public UIDocument ScavengerUIDOC;
    public VisualElement root;
    public Button nextButton;
    public GameObject ScavengerDialogueMenu3Object;
    public GameObject UILinker_3_real;

    public string[] DialogueLines;
    public int DialogueIndex = 0;

    public EnemyMovementFinalFin10 Enemy_Move;
    public GameObject PlayerWeapon;

    public GameObject TransitionCondition4;


    private void Update()
    {
        if (ScavengerDialogueMenu3Object != null && !ScavengerDialogueMenu3Object.activeSelf)
        {
            {
                if (TransitionCondition4.activeSelf == true)
                {
                    ShowMenu1();
                }


            }
        }

        void ShowMenu1()
        {
            ScavengerDialogueMenu3Object.SetActive(true);

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
         
            TransitionCondition4.SetActive(false);
            nextButton.SetEnabled(false);
            ScavengerDialogueMenu3Object.SetActive(false);
            Time.timeScale = 1.0f;
            ShowGameObject();
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
        void ShowGameObject()
        {
            Enemy_Move.Move_Type = EnemyMovementFinalFin10.EnemyMovementType.Chasing;



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