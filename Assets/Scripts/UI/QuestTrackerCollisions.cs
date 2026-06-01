using UnityEngine;

public class QuestTrackerCollisions : MonoBehaviour
{
    public GameObject Objective1;
    public GameObject Objective8;
    public GameObject Objective11;
    public GameObject Objective12;
    public GameObject Objective14;
    public QuestFinal quest;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Objective1")
        {
            Debug.Log("Q1Objective1Set");
            quest.QuestObjectives_Enum = QuestFinal.QuestObjective.O1;
            Objective1.SetActive(false);
        }
        if (collider.gameObject.name == "Objective8")
        {
            Debug.Log("Q1Objective1Set");
            quest.QuestObjectives_Enum = QuestFinal.QuestObjective.O8;
            Objective8.SetActive(false);
        }
        if (collider.gameObject.name == "Objective11")
        {
            Debug.Log("Q1Objective1Set");
            quest.QuestObjectives_Enum = QuestFinal.QuestObjective.O11;
           Debug.Log(" Collision_Objective11");
            Objective11.SetActive(false);
        }
        if (collider.gameObject.name == "Objective12")
        {
            quest.QuestObjectives_Enum = QuestFinal.QuestObjective.O12;
            Debug.Log(" Collision_Objective12");
            Objective11.SetActive(false);
            Objective14.SetActive(true);
        }
      
        if (collider.gameObject.name == "Objective14")
        {
            quest.QuestObjectives_Enum = QuestFinal.QuestObjective.O14;
            Debug.Log(" Collision_Objective12");
            Objective14.SetActive(false);
        }
    }
}
