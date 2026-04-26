using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Dialogue2 : MonoBehaviour
{
   
    private Button nextButton;
    public Label DialogueLines;
    public string[] ScavengerLines;
    public int DialogueList = 1;
    public GameObject DialogueUi2;
    public GameObject Enemy;
    public GameObject Player;
    public GameObject UIlinker2;
    public float InteractProximity = 20.0f;
    public UIDocument dialogueui;
    public PlayerMovement PlayerMove;
    public ShootMech PlayerShoot;
    public GameObject scrapHeapGhost;
    private void Update()
    {

        if (DialogueUi2.activeSelf == false)
        {
            float uilinker2 = Vector2.Distance(UIlinker2.transform.position, Player.transform.position);
            if (Enemy == null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                    if (uilinker2 < InteractProximity)
                    {
                        ShowMenu2();

                    }
            }
        }
    }


    /*void OnEnable()
    {
        if (dialogueui == null || dialogueui.rootVisualElement == null)
        {
            return;
        }
        var Uidocu = DialogueUi2.GetComponent<UIDocument>();
        if (Uidocu != null)
        {
            var root = Uidocu.rootVisualElement;
            nextButton = root.Q<Button>("next");
            DialogueLines = root.Q<Label>("DialogueLines");
        }

      

        if (nextButton != null)
        {
            nextButton.clicked += NextButtonOnClick;
            Debug.Log("Next button found and linked!");

        }

    }*/

    private void NextButtonOnClick()
    {
        DialogueList++;
        UpdateDialogueLines();




    }
    void UpdateDialogueLines()
    {
        if (DialogueList >= ScavengerLines.Length)
        {
            EndDialogue();
            return;
        }

        DialogueLines.text = ScavengerLines[DialogueList];
    }
    void EndDialogue()
    {
        nextButton.SetEnabled(false);
        DialogueUi2.SetActive(false);
        UIlinker2.SetActive(false);
        PlayerShoot.enabled = true;
        PlayerMove.enabled = true;
      //  scrapHeapGhost.SetActive(false);
        // ShowGameObject();

    }
    void ShowMenu2()
    {
        DialogueUi2.SetActive(true);
        PlayerShoot.enabled = false;
        PlayerMove.enabled = false;
           var Uidocu = DialogueUi2.GetComponent<UIDocument>();
        if (dialogueui == null || dialogueui.rootVisualElement == null)
        {
            return;
        }
     
        if (Uidocu != null)
        {
            var root = Uidocu.rootVisualElement;
            nextButton = root.Q<Button>("next");
            DialogueLines = root.Q<Label>("DialogueLines");
            DialogueList = 0;
        }



        if (nextButton != null)
        {
            nextButton.clicked += NextButtonOnClick;
            Debug.Log("Next button found and linked!");

        }
        UpdateDialogueLines();
    }
    /*void ShowGameObject()
    {
        Enemy.SetActive(true);
    } */
}

