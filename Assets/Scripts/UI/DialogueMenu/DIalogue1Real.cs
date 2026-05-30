using JetBrains.Annotations;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Dialogue1Real : MonoBehaviour
{

    public Label DialogueLinesLabel;
    public UIDocument ScavengerUIDOC;
    public VisualElement root;
    public Button nextButton;
    public GameObject ScavengerDialogueMenu1Object;
    public GameObject UILinker_1_real;
    public GameObject Player;
    public GameObject Enemy;
    public float InteractProximity = 3.0f;
    public string[] DialogueLines;
    public int DialogueIndex = 0;

    public GameObject TransitionCondition1;
    public QuestTracker quest;

    private void Update()
    {
        if (ScavengerDialogueMenu1Object != null && !ScavengerDialogueMenu1Object.activeSelf)
        {
            {
                float uilinker1 = Vector2.Distance(UILinker_1_real.transform.position, Player.transform.position);
                if (Enemy != null && Enemy.activeInHierarchy)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                        if (uilinker1 < InteractProximity)
                        {

                            Debug.Log("linkeronereg");
                            ShowMenu1();

                        }
                }

            }
        }
    }

void ShowMenu1()
    {
        ScavengerDialogueMenu1Object.SetActive(true);

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
        nextButton.SetEnabled(false);
        ScavengerDialogueMenu1Object.SetActive(false);
        TransitionCondition1.SetActive(true);
        Time.timeScale = 1.0f;
        //quest stuff
        quest.IsQ2ObjectiveUpdate2 = true;
     
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