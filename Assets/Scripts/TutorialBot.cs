using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UIElements;

public class TutorialBot : MonoBehaviour
{
    public List<GameObject> Tutorial_Popup = new List<GameObject>();
private string[] Tutorial_text;

    public UIDocument Tutorial_Bot_UIDOC;
    public Label Tutorial_Text_Label;
    public Animator Tutorial_Anim;
    public bool isFound = false;
    public bool isScrapbot = false;
    public enum TutorialNumber
    {
     TutorialNull,  Tutorial1, Tutorial2, Tutorial3
    }
    public TutorialNumber Tut_Enum;
    public void Start()
    {
        Tut_Enum = TutorialNumber.TutorialNull;
    }
    public void Update()
    {
        switch (Tut_Enum)
        {
            case TutorialNumber.Tutorial1: StartCoroutine(Tutorial0()); break;
            case TutorialNumber.TutorialNull: Hide_Popup(); break;
        }

        if (isFound == true)
        {
            isScrapbot = false;
            Tutorial_Anim.SetBool("isFound", true);
        }
        else if (isFound == false)
        {
            Tutorial_Anim.SetBool("isFound", false);
        }

        if (isScrapbot == true)
        {
            isFound = false;
            Tutorial_Anim.SetBool("isScrapbot", true);
        }
        else if (isScrapbot == false)
        {
            Tutorial_Anim.SetBool("isScrapbot", false);
        }
    }
    public void Popup()
    {
        Tutorial_Bot_UIDOC = GetComponent<UIDocument>();
        Tutorial_Bot_UIDOC.enabled = true;
        if(Tutorial_Bot_UIDOC == null)
        {
            return;
        }
        if(Tutorial_Bot_UIDOC != null )
        {
            var root = Tutorial_Bot_UIDOC.rootVisualElement;
            Tutorial_Text_Label = root.Q<Label>("Speech_Label");
        }
    }
    public void Hide_Popup()
    {
        Tutorial_Bot_UIDOC.enabled = false;
        isScrapbot = true;
        isFound = false;
    }

    public void TutorialText()
    {
        Tutorial_text = new string[10];
        Tutorial_text[0] = "0";
        Tutorial_text[1] = "1";
        Tutorial_text[2] = "1";
    }
    
    public IEnumerator  Tutorial0()
    {
        isFound = true;
        isScrapbot = false;
        Tutorial_Popup[0].SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Popup();
        TutorialText();
        Tutorial_Text_Label.text = Tutorial_text[0];
        yield return new WaitForSeconds(3);
        Tut_Enum = TutorialNumber.TutorialNull;
        yield return null;
    }
    
}

