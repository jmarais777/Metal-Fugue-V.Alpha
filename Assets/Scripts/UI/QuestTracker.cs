using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UIElements;

public class QuestTracker : MonoBehaviour
{
    public bool IsQuestLine1;
    public bool IsQ1ObjectiveUpdate1;
    public bool IsQ1ObjectiveUpdate2;

    public bool IsQ2ObjectiveUpdate1;
    public bool IsQ2ObjectiveUpdate2;
    public bool IsQ2ObjectiveUpdate3;
    public bool IsQ2ObjectiveUpdate4;
    public bool IsQ2ObjectiveUpdate5;
    public bool IsQ2ObjectiveUpdate6;
    public bool IsQ2ObjectiveUpdate7;
    public bool IsQ2ObjectiveUpdate8;
    public bool IsQ2ObjectiveUpdate9;
    public bool IsQ2ObjectiveUpdate10;
    public bool IsQ2ObjectiveUpdate11;
    public bool IsQ2ObjectiveUpdate12;
    public bool IsQ2ObjectiveUpdate13;
    public bool IsQ2ObjectiveUpdate14;
    
  private string[] QuestName;
  private string[] CurrentObjective;

    public UIDocument Questrack;
    public Label Questname_label;
    public Label Objective_label;

    public float StarterTimer = 0.5f;

    public GameObject Quest_Begginings_Objective1;
    public GameObject TransitionCondition1;
    public GameObject Enemy;
    public GameObject ScavArmOnPlayer;
    public GameObject ScavengerArmOnScav;
    


    void Update()
    {
        //Begginings
    
        if (IsQuestLine1 == true)
        {
            QuestNames();
            Questname_label.text = QuestName[0];
            CurrentObjectives();
            Objective_label.text = CurrentObjective[0];
        }

        if (IsQ1ObjectiveUpdate1 == true)
        {
            CurrentObjectives();
            Objective_label.text = CurrentObjective[1];
            IsQuestLine1 = false;
            
        }
        if (IsQ1ObjectiveUpdate2 == true)
        {
            CurrentObjectives();
            Objective_label.text = CurrentObjective[2];
            IsQ1ObjectiveUpdate1 = false;
        }

        //Friend or foe
        if (IsQ2ObjectiveUpdate1 == true)
        {
            QuestNames();
            Questname_label.text = QuestName[2];
            

            CurrentObjectives();
            Objective_label.text = CurrentObjective[3];
            IsQ1ObjectiveUpdate2 = false;
        }
       
           
            if (IsQ2ObjectiveUpdate2 == true) //set in Dialogue1Real
            {
                CurrentObjectives();
                Objective_label.text = CurrentObjective[4];
                IsQ2ObjectiveUpdate1 = false;   
            }
        
        if (Enemy == null)
        {
            Questrack = GetComponent<UIDocument>();
            if (Questrack != null)
            {
                var root = Questrack.rootVisualElement;
                Questname_label = root.Q<Label>("QuestName");
                Objective_label = root.Q<Label>("CurrentObjctive");

            }
            CurrentObjectives();
            Objective_label.text = CurrentObjective[3];
            IsQ2ObjectiveUpdate2 = false;
        }
        if (IsQ2ObjectiveUpdate3 == true) //set in Dialogue5Real
        {
            CurrentObjectives();
            Objective_label.text = CurrentObjective[5];
           
        }
        if (IsQ2ObjectiveUpdate4  == true) //Set in Dialogue6Real
        {
            CurrentObjectives();
            Objective_label.text = CurrentObjective[6];
            IsQ2ObjectiveUpdate3 = false;
        }
        //A Helping Hand//
        if (IsQ2ObjectiveUpdate5 == true) //Set in Dialogue9Real
        {
            CurrentObjectives();
            Objective_label.text = CurrentObjective[7];
            IsQ2ObjectiveUpdate4 = false;
        }
        if (IsQ2ObjectiveUpdate6 == true)
        {
            CurrentObjectives();
            Objective_label.text = CurrentObjective[8];
            IsQ2ObjectiveUpdate5 = false;
        }
        if (ScavArmOnPlayer.activeSelf == true)
        {
            IsQ2ObjectiveUpdate7 = true;
          if (IsQ2ObjectiveUpdate7 == true)
            {
                CurrentObjectives();
                Objective_label.text = CurrentObjective[9];
                IsQ2ObjectiveUpdate6 = false;
            }

        }
        //Objective for Into The Dark'
        if (IsQ2ObjectiveUpdate8 == true) //Set in Dialogue11Real
        {
            CurrentObjectives();
            Objective_label.text = CurrentObjective[10];
            IsQ2ObjectiveUpdate7 = false;
        }
         if (IsQ2ObjectiveUpdate9 == true)
          {
             CurrentObjectives();
              Objective_label.text = CurrentObjective[11];
              IsQ2ObjectiveUpdate8 = false;
         }
        if (IsQ2ObjectiveUpdate10 == true)
        {
            CurrentObjectives();
            Objective_label.text = CurrentObjective[12];
            IsQ2ObjectiveUpdate9 = false;
        }
        if (IsQ2ObjectiveUpdate11 == true) //set in Lock
        {
            CurrentObjectives();
            Objective_label.text = CurrentObjective[13];
            IsQ2ObjectiveUpdate10 = false;
        }
        //Out of the frying pan
        if (IsQ2ObjectiveUpdate12 == true) //set in lock
        {
            CurrentObjectives();
            Objective_label.text = CurrentObjective[14];
            IsQ2ObjectiveUpdate11 = false;
        }
        //Into The Fire
        if (IsQ2ObjectiveUpdate13 == true) //set in lock
        {
            CurrentObjectives();
            Objective_label.text = CurrentObjective[15];
            IsQ2ObjectiveUpdate12 = false;
        }
        if (IsQ2ObjectiveUpdate14 == true) //set in bossHealth
        {
            CurrentObjectives();
            Objective_label.text = CurrentObjective[16];
            IsQ2ObjectiveUpdate13 = false;
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
        CurrentObjective[0] = "Explore the area to find help";
        CurrentObjective[1] = "Pickup the light Source";
        CurrentObjective[2] = "Search for help";

        //Objective for 'Friend Or foe'
        CurrentObjective[3] = "Speak to the trapped robot";
        CurrentObjective[4] = "Defeat the security Bot.";
        //
        CurrentObjective[5] = "Shoot the obstacle to free the robot";
        CurrentObjective[6] = "Meet Scavenger Bot inside the space shuttle when you are ready";

        //Objective for 'A Helping Hand'
        CurrentObjective[7] = "Head In the East direction to find the Old WindmIll";
        CurrentObjective[8] = "Find ScavengerBots Arm near teh Old Windmill";
        CurrentObjective[9] = "Return to scavenger Bot";

        //Objective for Into The Dark'
        CurrentObjective[10] = "Enter the CryoCombs";
        CurrentObjective[11] = "Find the power generator";
        CurrentObjective[12] = "Switch Off the power";
        CurrentObjective[13] = "Exit the Crycombs";

        //Out of the frying pan
        CurrentObjective[14] = "Exit the Scrap Yard through the secuirty gate. (located north of the Space Shuttle";
 

        //Into the fire
        CurrentObjective[15] = "Defeat Demolition Bot!";
        CurrentObjective[16] = "Exit scrapyard";



    }



}
/*Where are teh conditions:
  public bool IsQ1ObjectiveUpdate2 = true. if Cortical.activeself
        CurrentObjective[4] = "Defeat the security Bot."; (
*/
/* 
 * 
 * public enum QuestNumber
    {
        Q1,
        Q2,
        Q3,
        Q4,
        Q5,
        Q6,
    }
    public QuestNumber Quest_Number;
    public enum QuestObjectiveUpdate
    {
        //Beggings
        Update0,
        Update1,
        Update2,
        //Friend or foe
        Update3,
        Update4,
        Update5, 
        Update6,
        //Objective for 'A Helping Hand'
        Update7,
        Update8,
        Update9,
        //Objective for Into The Dark'
        Update10,
        Update11,
        Update12,
        Update13,
        //Out of the frying pan
        Update14,
        //Into the fire
        Update15,
        Update16,
    }
    public QuestObjectiveUpdate Quest_Update;

 * 
 * 
 * 
 * 
 * switch (Quest_Number)
        {
            case QuestNumber.Q1: QuestNames(); Questname_label.text = QuestName[0]; break;
            case QuestNumber.Q2: QuestNames(); Questname_label.text = QuestName[1]; break;
            case QuestNumber.Q3: QuestNames(); Questname_label.text = QuestName[2]; break;
            case QuestNumber.Q4: QuestNames(); Questname_label.text = QuestName[3]; break;
            case QuestNumber.Q5: QuestNames(); Questname_label.text = QuestName[4]; break;
            case QuestNumber.Q6: QuestNames(); Questname_label.text = QuestName[5]; break;
        }
        switch (Quest_Update)
        {
            case QuestObjectiveUpdate.Update0: CurrentObjectives(); Objective_label.text = CurrentObjective[0]; break;
            case QuestObjectiveUpdate.Update1: CurrentObjectives(); Objective_label.text = CurrentObjective[1]; break;
            case QuestObjectiveUpdate.Update2: CurrentObjectives(); Objective_label.text = CurrentObjective[2]; break;
            case QuestObjectiveUpdate.Update3: CurrentObjectives(); Objective_label.text = CurrentObjective[3]; break;
            case QuestObjectiveUpdate.Update4: CurrentObjectives(); Objective_label.text = CurrentObjective[4]; break; //set in Dialogue1Real
            case QuestObjectiveUpdate.Update5: CurrentObjectives(); Objective_label.text = CurrentObjective[5]; break;
            case QuestObjectiveUpdate.Update6: CurrentObjectives(); Objective_label.text = CurrentObjective[6]; break;
            case QuestObjectiveUpdate.Update7: CurrentObjectives(); Objective_label.text = CurrentObjective[7]; break;
            case QuestObjectiveUpdate.Update8: CurrentObjectives(); Objective_label.text = CurrentObjective[8]; break;
            case QuestObjectiveUpdate.Update9: CurrentObjectives(); Objective_label.text = CurrentObjective[9]; break;
            case QuestObjectiveUpdate.Update10: CurrentObjectives(); Objective_label.text = CurrentObjective[10]; break;
            case QuestObjectiveUpdate.Update11: CurrentObjectives(); Objective_label.text = CurrentObjective[11]; break;
            case QuestObjectiveUpdate.Update12: CurrentObjectives(); Objective_label.text = CurrentObjective[12]; break;
            case QuestObjectiveUpdate.Update13: CurrentObjectives(); Objective_label.text = CurrentObjective[13]; break;
            case QuestObjectiveUpdate.Update14: CurrentObjectives(); Objective_label.text = CurrentObjective[14]; break;
            case QuestObjectiveUpdate.Update15: CurrentObjectives(); Objective_label.text = CurrentObjective[15]; break;
            case QuestObjectiveUpdate.Update16: CurrentObjectives(); Objective_label.text = CurrentObjective[16]; break;
        }
*/