using Unity.VisualScripting;
using UnityEngine;

public class EnemyRecallSelectors : MonoBehaviour
{
    public enum  RecallLayout
    {
        Defualt = 0,
        Linear = 1,
        Wide = 2,
    }
    public RecallLayout option = RecallLayout.Defualt;
    
    void Start()
    {
        option = RecallLayout.Defualt;

    }

 public void OnTriggerEntter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Recall_Layout_Custom_Diag1"))
        {
            Debug.Log("Recall_Layout_Custom_Diag1 is active");
        }
    
            if (collider.gameObject.CompareTag("RecallLayout_Linear_Horozontal"))
        {
            Debug.Log("RecallLayout_Linear_Horozontal");
        }
    }
}
