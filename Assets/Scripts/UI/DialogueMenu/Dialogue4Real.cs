using JetBrains.Annotations;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Dialogue4Real : MonoBehaviour
{

    public Label DialogueLinesLabel;
    public UIDocument ScavengerUIDOC;
    public VisualElement root;
    public Button nextButton;
    public GameObject ScavengerDialogueMenu4Object;
    public GameObject UILinker_4_real;
    public float InteractProximity = 3.0f;
    public string[] DialogueLines;
    public int DialogueIndex = 0;
    public GameObject EnemyNPC;
    public GameObject Player;


    public GameObject TransitionCondition5;
    public GameObject TransitionCondition6;

    private void Update()
    {
        if (ScavengerDialogueMenu4Object != null && !ScavengerDialogueMenu4Object.activeSelf)
        {
            
                if (EnemyNPC.activeSelf == false)
                {
                    var dir = Vector2.Distance(UILinker_4_real.transform.position, Player.transform.position);
                    if (dir < InteractProximity)
                    {
                        if(Input.GetKeyDown(KeyCode.E))
                        ShowMenu1();
                    }
                }
        }

        void ShowMenu1()
        {
            ScavengerDialogueMenu4Object.SetActive(true);
            TransitionCondition5.SetActive(true);
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
            TransitionCondition5.SetActive(false);
            TransitionCondition6.SetActive(true);
            nextButton.SetEnabled(false);
            ScavengerDialogueMenu4Object.SetActive(false);
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