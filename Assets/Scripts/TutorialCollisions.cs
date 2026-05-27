using UnityEngine;

public class TutorialCollisions : MonoBehaviour
{
    public TutorialBot Tutorial_Bot_Scr;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Tutorial1")
        {
            Tutorial_Bot_Scr.Tut_Enum = TutorialBot.TutorialNumber.Tutorial1;
        }
    }

}
