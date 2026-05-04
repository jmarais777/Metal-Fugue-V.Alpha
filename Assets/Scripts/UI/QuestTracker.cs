using UnityEngine;
using UnityEngine.UIElements;

public class QuestTracker : MonoBehaviour
{
    public bool IsQuestLine1;
    public bool IsQ1ObjectiveUpdate;

  private string[] QuestName;
  private string[] CurrentObjective;

    public UIDocument Questrack;
    public Label Questname_label;
    public Label Objective_label;

    public float StarterTimer = 0.5f;

    public GameObject Quest_Begginings_Objective1;


   public void Awake()
    {
        Questrack = GetComponent<UIDocument>();
        if (Questrack != null)
        {
            var root = Questrack.rootVisualElement;
            Questname_label = root.Q<Label>("QuestName");
            Objective_label = root.Q<Label>("CurrentObjctive");
        }
        
    }

  
    void Update()
    {
        StarterTimer -= Time.deltaTime;
        if (StarterTimer <= 0)
        {
            IsQuestLine1 = true;
            StarterTimer = 0;
        }
        if (IsQuestLine1 == true)
        {
            QuestNames();
            Questname_label.text = QuestName[0];
            CurrentObjectives();
            Objective_label.text = CurrentObjective[0];
        }

        if (IsQ1ObjectiveUpdate == true)
        {
            CurrentObjectives();
            Objective_label.text = CurrentObjective[1];
           // Quest_Begginings_Objective1.SetActive(false);
        }

       
      
    }
    void QuestNames()
    {
        QuestName = new string[6];
        QuestName[0] = "Begginings";
        QuestName[1] = "Friend or Foe";
        QuestName[2] = "A Helping Hand";
        QuestName[3] = "Into the Dark";
        QuestName[4] = "Out of the Frying Pan";
        QuestName[5] = "Into the Fire";
   
    }
    void CurrentObjectives()
    {
        //Objectives for 'Begginings'
        CurrentObjective = new string[20];
        CurrentObjective[0] = "Find Help";
        CurrentObjective[1] = "pickup";

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Quest_Begginings_Objective1"))
        {
            Debug.Log("Q1Objective1Set");
            IsQ1ObjectiveUpdate = true;
        }
    }

}
