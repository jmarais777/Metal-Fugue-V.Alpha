
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UIElements;

public class TutorialBot3 : MonoBehaviour
{
    //public GameObject TutorialPoPupCondition1;
    public Transform Player;
    private string[] Tutorial_text;

    public UIDocument Tutorial_Bot_UIDOC;
    public Label Tutorial_Text_Label;
    public Animator Tutorial_Anim;
    public bool isFound = false;
    public bool isScrapbot = false;

    public bool HasApeared = false;
    public enum TutorialNumber
    {
        TutorialNull, Tutorial0, TutorialEnd,
    }
    public TutorialNumber Tut_Enum;
    public void Start()
    {
        Tut_Enum = TutorialNumber.TutorialNull;
        HasApeared = false;
    }
    public void Update()
    {
        float DistToPlayer = Vector3.Distance(transform.position, Player.transform.position);
        if (DistToPlayer <= 10.0f && HasApeared == false)
        { 
            Tut_Enum = TutorialNumber.Tutorial0; 
        }
        else if (DistToPlayer > 10.0f || HasApeared == true)
        {
            Tut_Enum = TutorialNumber.TutorialNull;
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

        switch (Tut_Enum)
        {
            case TutorialNumber.Tutorial0: StartCoroutine(Tutorial0()); break;
            case TutorialNumber.TutorialNull: Hide_Popup(); break;
        }
    }
    public void Popup()
    {
        Tutorial_Bot_UIDOC = GetComponent<UIDocument>();
        Tutorial_Bot_UIDOC.enabled = true;
        if (Tutorial_Bot_UIDOC == null)
        {
            return;
        }
        if (Tutorial_Bot_UIDOC != null)
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

    //THE INUMERATORS OF DESTRUCTION!!!!!
    public IEnumerator Tutorial0()
    {
        isFound = true;
        isScrapbot = false;
        //TutorialPoPupCondition1.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Popup();
        Tutorial_Text_Label.text = "You need light more than her... Press E to interact..";
        yield return new WaitForSeconds(3);
        HasApeared = true;
        yield return null;
    }
    

}

