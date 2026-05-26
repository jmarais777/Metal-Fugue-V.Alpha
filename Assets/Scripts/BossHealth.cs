using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int HitPoints = 25;
    public QuestTracker quest;

    private void OnCollisionEnter2D(Collision2D collision)
    {



        if (collision.gameObject.CompareTag("Bullets"))
        {
            HitPoints--;

        }


        {

        }
        if (HitPoints < 0)
        {
            Destroy(this.gameObject);
            quest.IsQ2ObjectiveUpdate14 = true;
        }
    }


}
