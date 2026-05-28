using UnityEngine;

public class QuestTrackerCollisions : MonoBehaviour
{
    public QuestTracker quest;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Quest_Begginings_Objective1"))
        {
            Debug.Log("Q1Objective1Set");
            quest.IsQ1ObjectiveUpdate1 = true;

        }
        if (collider.gameObject.CompareTag("Quest_FriendOrFoe_Objective1"))
        {
            Debug.Log("Q1Objective1Set");
            quest.IsQ2ObjectiveUpdate1 = true;
        }
        if (collider.gameObject.CompareTag("Quest_AhelpingHand_Objective1"))
        {
            Debug.Log("Q1Objective1Set");
            quest.IsQ2ObjectiveUpdate6 = true;
        }
        if (collider.gameObject.CompareTag("Quest_IntoTheDark_Objective1"))
        {
            Debug.Log("Q1Objective1Set");
            quest.IsQ2ObjectiveUpdate9 = true;
        }
        if (collider.gameObject.CompareTag("Quest_IntoTheDark_Objective2"))
        {
            Debug.Log("Q1Objective1Set");
            quest.IsQ2ObjectiveUpdate10 = true;
        }
        if (collider.gameObject.CompareTag("Quest_OutOfTheFryingPan_Objective1"))
        {
            Debug.Log("Q1Objective1Set");
            quest.IsQ2ObjectiveUpdate12 = true;
        }
    }
}
