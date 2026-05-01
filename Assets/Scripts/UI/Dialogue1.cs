using JetBrains.Annotations;
using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Dialogue1 : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Player;
    private Button nextButton;
    public Label DialogueLines;
    public string[] ScavengerLines;
    public int DialogueList = 0;
    public GameObject DialogueUi1;
    public GameObject UIlinker1;
    public EnemyMovement enemySriptMove;
    public ShootMech PlayerShoot;
    public EnemySHootMech enemyScriptShoot;
    public PlayerMovement playerMove;
    public float InteractProximity = 3.0f;
    public UIDocument dialogueui;
    public GameObject Weapon;
    public Transform PlayerDialogueP1;
    public enum RigidbodyType2D
    {
        Static
    }


    private void Update()
    {

        if (DialogueUi1 != null && !DialogueUi1.activeSelf)
        {
            {
                float uilinker1 = Vector2.Distance(UIlinker1.transform.position, Player.transform.position);
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




    private void NextButtonOnClick()
    {
        DialogueList++;
        UpdateDialogueLines();
        Debug.Log("The button was physically clicked!");



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
        DialogueUi1.SetActive(false);
        Time.timeScale = 1.0f;

        ShowGameObject();

    }
    void ShowGameObject()
    {
        enemySriptMove.enabled = true;
        enemyScriptShoot.enabled = true;
        playerMove.enabled = true;

        Weapon.SetActive(true);
        PlayerShoot.enabled = true;
       

    }
    void ShowMenu1()
    {
        DialogueUi1.SetActive(true);
        playerMove.enabled = false;
        Time.timeScale = 0;
       // Player.transform.position = PlayerDialogueP1.position




      var uiDocu = DialogueUi1.GetComponent<UIDocument>();
        if (uiDocu == null && uiDocu.rootVisualElement == null)
        {
            return;
        }
     
        if (uiDocu != null)
        {
            var root = uiDocu.rootVisualElement;
            nextButton = root.Q<Button>("next");
            DialogueLines = root.Q<Label>("DialogueLines");
            DialogueList = 0;
        }
        else
        {
            Debug.LogError("FATAL: Could not find a Button named 'next' in the UXML!");
        }

        if (nextButton != null)
        {
            nextButton.clicked += NextButtonOnClick;
            Debug.Log("Next button found and linked!");

        }
        UpdateDialogueLines();

    }
}

