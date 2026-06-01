using UnityEngine;

public class TutorialCollisions : MonoBehaviour
{
    public TutorialBot2 Tutorial_Bot_Scr;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Tutorial0")
        {
            Tutorial_Bot_Scr.Tut_Enum =TutorialBot2.TutorialNumber.Tutorial0;
        }
    }

}
