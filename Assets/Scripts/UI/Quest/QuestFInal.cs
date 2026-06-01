using UnityEngine;
using UnityEngine.UIElements;

public class QuestFinal : MonoBehaviour
{
    public UIDocument Questrack;
    public Label Questname_label;
    public Label Objective_label;
    public GameObject Enemynpcs;
    private string[] QuestName;
    private string[] CurrentObjective;
    
    public enum QuestObjective
    {
        O0,
        O1,
        O2,
        O3,
        O4,
        O5,
        O6,
        O16,
        O7,
        O8,
        O9,
        O10,
        O11,
        O12,
        O13,
        O14,
        O15,

    }
    public QuestObjective QuestObjectives_Enum;
    public enum QuestNamesEnum
    {
       Begginings,
      Friend_or_Foe,
        A_Helping_Hand,
        Into_the_Dark,
        Out_of_the_Frying_Pan,
        Into_the_Fire,
    }
    public QuestNamesEnum Quest_names_Enum;


void Awake()
    {
        Questrack = GetComponent<UIDocument>();
        if (Questrack != null)
        {
            var root = Questrack.rootVisualElement;
            Questname_label = root.Q<Label>("QuestName");
            Objective_label = root.Q<Label>("CurrentObjctive");
        }
        Quest_names_Enum = QuestNamesEnum.Begginings;
        QuestObjectives_Enum = QuestObjective.O0;
    }

    void Update()
    {
        switch (Quest_names_Enum)
        {
            case QuestNamesEnum.Begginings: QuestNames(); Questname_label.text = QuestName[0]; break;
            case QuestNamesEnum.Friend_or_Foe: QuestNames(); Questname_label.text = QuestName[1]; break;
            case QuestNamesEnum.A_Helping_Hand: QuestNames(); Questname_label.text = QuestName[2]; break;
            case QuestNamesEnum.Into_the_Dark: QuestNames(); Questname_label.text = QuestName[3]; break;
            case QuestNamesEnum.Out_of_the_Frying_Pan: QuestNames(); Questname_label.text = QuestName[4]; break;
            case QuestNamesEnum.Into_the_Fire: QuestNames(); Questname_label.text = QuestName[5]; break;

        }
        switch (QuestObjectives_Enum)
        {
            case QuestObjective.O0: CurrentObjectives(); Objective_label.text = CurrentObjective[0]; break;
            case QuestObjective.O1: CurrentObjectives(); Objective_label.text = CurrentObjective[1]; break;
            case QuestObjective.O2: CurrentObjectives(); Objective_label.text = CurrentObjective[2]; QuestNames(); Questname_label.text = QuestName[1]; break;
            case QuestObjective.O3: CurrentObjectives(); Objective_label.text = CurrentObjective[3]; break;
            case QuestObjective.O4: CurrentObjectives(); Objective_label.text = CurrentObjective[4]; break;
            case QuestObjective.O5: CurrentObjectives(); Objective_label.text = CurrentObjective[5]; break;
            case QuestObjective.O6: CurrentObjectives(); Objective_label.text = CurrentObjective[6]; break;
            case QuestObjective.O7: CurrentObjectives(); Objective_label.text = CurrentObjective[7]; QuestNames(); Questname_label.text = QuestName[2]; break;
            case QuestObjective.O8: CurrentObjectives(); Objective_label.text = CurrentObjective[8]; break;
            case QuestObjective.O9: CurrentObjectives(); Objective_label.text = CurrentObjective[9]; break;
            case QuestObjective.O10: CurrentObjectives(); Objective_label.text = CurrentObjective[10];  QuestNames(); Questname_label.text = QuestName[3]; ; break;
            case QuestObjective.O11: CurrentObjectives(); Objective_label.text = CurrentObjective[11]; break;
            case QuestObjective.O12: CurrentObjectives(); Objective_label.text = CurrentObjective[12]; break;
            case QuestObjective.O13: CurrentObjectives(); Objective_label.text = CurrentObjective[13]; break;
            case QuestObjective.O14: CurrentObjectives(); Objective_label.text = CurrentObjective[14]; QuestNames(); Questname_label.text = QuestName[1]; break;
            case QuestObjective.O15: CurrentObjectives(); Objective_label.text = CurrentObjective[15]; break;

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
        CurrentObjective = new string[20];
        //Objectives for 'Begginings'
        CurrentObjective[0] = "Explore the area to find help"; //set on awake
        CurrentObjective[1] = "Pickup the light Source"; // set in collision script
        CurrentObjective[2] = "Search for help"; //set in colliion script

        //Objective for 'Friend Or foe'
        CurrentObjective[3] = "Speak to the trapped robot"; //set in collision script
        CurrentObjective[4] = "Defeat the security Bot."; // set in dialogue 1 real
        //
        CurrentObjective[5] = "Shoot the obstacle to free the robot"; //set in dfilaogue 5 real
        CurrentObjective[6] = "Meet Scavenger Bot inside the space shuttle when you are ready"; //set in Dialogue 6 real

        //Objective for 'A Helping Hand'
        CurrentObjective[7] = "Head In the East direction to find the Old WindmIll"; //set in dialogue 9 real
        CurrentObjective[8] = "Find ScavengerBots Arm near the Old Windmill"; //set in collision script
        CurrentObjective[9] = "Return to scavenger Bot"; //set in Inetract script

        //Objective for Into The Dark'
        CurrentObjective[10] = "Enter the CryoCombs"; //set in collision script
        CurrentObjective[11] = "Find the power generator"; // set in collision
        CurrentObjective[12] = "Switch Off the power"; //set in colliison
        CurrentObjective[13] = "Exit the Crycombs"; // set in lock 

        //Out of the frying pan
        CurrentObjective[14] = "Exit the Scrap Yard through the secuirty gate. (located north of the Space Shuttle"; // set in collison


        //Into the fire
        CurrentObjective[15] = "Defeat Demolition Bot!"; // set in lock
        CurrentObjective[16] = "Exit scrapyard"; //set in this script



    }


}
