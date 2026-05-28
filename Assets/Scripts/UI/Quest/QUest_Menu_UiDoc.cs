using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class QUest_Menu_UiDoc : MonoBehaviour
    
{
    public UIDocument Quest_Menu_Ui_Doc;
    public List<Button> Completed_Quests_Buttons;
    public List<Label> Completed_Quest_Label;
    public ScrollView scroller;

    public QuestTracker Quest_tracker_Scr;
    public enum AtciveQuest
    {
        Begginings,
        Friend_Or_Foe,
        A_Helping_Hand,
        Into_the_Dark,
        Out_of_the_Frying_Pan,
        Into_The_Fire,
    }
    public AtciveQuest Active_Quest_enum;
    public void Start()
    {
        Quest_Menu_Ui_Doc.enabled = false;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Tab Was Pressed");
            Show_Quest_Menu();
        }
    }
    public void Show_Quest_Menu()
    {
        Quest_Menu_Ui_Doc = GetComponent<UIDocument>();
        Quest_Menu_Ui_Doc.enabled = true;
        if (Quest_Menu_Ui_Doc == null)
        {
            return;
        }
        else if (Quest_Menu_Ui_Doc != null)
        {
            var root = Quest_Menu_Ui_Doc.rootVisualElement;
            Completed_Quests_Buttons = root.Query<Button>().ToList();
            Completed_Quest_Label = root.Query<Label>().ToList();
            scroller = root.Q<ScrollView>();
        }
    }
}

