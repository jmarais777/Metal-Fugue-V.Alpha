using JetBrains.Annotations;
using System.Linq;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Dialogue7Real : MonoBehaviour
{

    public Label DialogueLinesLabel;
    public UIDocument ScavengerUIDOC;
    public VisualElement root;
    public Button nextButton;
    public GameObject ScavengerDialogueMenu7Object;
    public GameObject UILinker_7_real;
    public float InteractProximity = 3.0f;
    public string[] DialogueLines;
    public int DialogueIndex = 0;
    public GameObject Player;


    public GameObject TransitionCondition9;
   
   

    private void Update()
    {
        if (UILinker_7_real != null && !ScavengerDialogueMenu7Object.activeSelf)
        {
            {
                float uilinker1 = Vector2.Distance(UILinker_7_real.transform.position, Player.transform.position);
                    if (TransitionCondition9.activeSelf == true)
                    if (Input.GetKeyDown(KeyCode.E))
                        if (uilinker1 < InteractProximity)
                        {

                            Debug.Log("linkeronereg");
                            ShowMenu1();

                        }
                

            }
        }

        void ShowMenu1()
        {
            ScavengerDialogueMenu7Object.SetActive(true);

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
           
            TransitionCondition9.SetActive(false);
            nextButton.SetEnabled(false);
            ScavengerDialogueMenu7Object.SetActive(false);
          
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