using UnityEngine;

public class TutorialCollisions : MonoBehaviour
{
    public TutorialBot Tutorial_Bot_Scr;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Tutorial0")
        {
            Tutorial_Bot_Scr.Tut_Enum = TutorialBot.TutorialNumber.Tutorial0;
        }
        if (collider.gameObject.name == "Tutorial1")
        {
            Tutorial_Bot_Scr.Tut_Enum = TutorialBot.TutorialNumber.Tutorial1;
        }
        if (collider.gameObject.name == "Tutorial2")
        {
            Tutorial_Bot_Scr.Tut_Enum = TutorialBot.TutorialNumber.Tutorial2;
        }
        if (collider.gameObject.name == "Tutorial22")
        {
            Tutorial_Bot_Scr.Tut_Enum = TutorialBot.TutorialNumber.Tutorial22;
        }
        if (collider.gameObject.name == "Tutorial2_1")
        {
            Tutorial_Bot_Scr.Tut_Enum = TutorialBot.TutorialNumber.Tutorial2_1;
        }
        if (collider.gameObject.name == "Tutorial2_1_1")
        {
            Tutorial_Bot_Scr.Tut_Enum = TutorialBot.TutorialNumber.Tutorial2_1_1;
        }
        if (collider.gameObject.name == "Tutorial2_2")
        {
            Tutorial_Bot_Scr.Tut_Enum = TutorialBot.TutorialNumber.Tutorial2_2;
        }
    }

}
