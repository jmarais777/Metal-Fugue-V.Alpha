using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Dialogue4 : MonoBehaviour
{
   
    private Button nextButton;
    public Label DialogueLines;
    public string[] ScavengerLines;
    public int DialogueIndex = 1;
    public GameObject DialogueUi4;
    public GameObject UIlinker4;
    public GameObject Player;
 
    public float InteractProximity = 20.0f;
    public UIDocument dialogueui;

    public GameObject ScavengerArmOnPlayer;
    public GameObject scavengerArmOnScav;
    public PlayerMovement PlayerMove;
    public ShootMech PlayerShoot;

    private void Update()
    {
        if (DialogueUi4.activeSelf == false)
        {
            float uilinker4 = Vector2.Distance(UIlinker4.transform.position, Player.transform.position);
            
                if (Input.GetKeyDown(KeyCode.E))
                    if (uilinker4 < InteractProximity)
                    {
                        if (ScavengerArmOnPlayer.activeSelf == true)
                        {

                            scavengerArmOnScav.SetActive(true);
                        ScavengerArmOnPlayer.SetActive(false);
                            ShowMenu4();
                        }

                    }
            
        }
    }
    

    private void NextButtonOnClick()
    {
        DialogueIndex++;
        UpdateDialogueLines();




    }
    void UpdateDialogueLines()
    {
        if (DialogueIndex >= ScavengerLines.Length)
        {
            Debug.Log("shouldEnd");
            EndDialogue4();
            return;
        
        }

        DialogueLines.text = ScavengerLines[DialogueIndex];
    }
    void EndDialogue4()
    {
        
        nextButton.SetEnabled(false);
        DialogueUi4.SetActive(false);
        UIlinker4.SetActive(false);
        PlayerShoot.enabled = true;
        PlayerMove.enabled = true;
        //  GetComponent<UIDocument>().enabled = false;

        // ShowGameObject();

    }
    void ShowMenu4()
    {
        DialogueUi4.SetActive(true);
        PlayerShoot.enabled = false;
        PlayerMove.enabled = false;
        var dialogueui = DialogueUi4.GetComponent<UIDocument>();
        if (dialogueui == null || dialogueui.rootVisualElement == null)
        {
            return;
        }


        if (dialogueui != null)
        {
            var root = dialogueui.rootVisualElement;
            nextButton = root.Q<Button>("next");
            DialogueLines = root.Q<Label>("DialogueLines");
            DialogueIndex = 1;
        }

        if (nextButton != null)
        {
            nextButton.clicked += NextButtonOnClick;
            UpdateDialogueLines();
            Debug.Log("Next button found and linked!");

        }
    }
    /*void ShowGameObject()
    {
        Enemy.SetActive(true);
    } */
}

