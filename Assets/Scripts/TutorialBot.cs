
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
     TutorialNull, Tutorial0, Tutorial1, Tutorial2, Tutorial22, Tutorial2_1, Tutorial2_1_1, Tutorial2_2, Tutorial3,
    }
    public TutorialNumber Tut_Enum;
    public void Start()
    {
        Tut_Enum = TutorialNumber.TutorialNull;
    }
    public void Update()
    {
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
            case TutorialNumber.Tutorial0:StartCoroutine(Tutorial0());break;
            case TutorialNumber.Tutorial1:StartCoroutine(Tutorial1());break;
            case TutorialNumber.Tutorial2: StartCoroutine(Tutorial2()); break;
            case TutorialNumber.Tutorial22: StartCoroutine(Tutorial22()); break;
            case TutorialNumber.Tutorial2_1: StartCoroutine(Tutorial2_1()); break;
            case TutorialNumber.Tutorial2_1_1: StartCoroutine(Tutorial2_1_1()); break;
            case TutorialNumber.Tutorial2_2: StartCoroutine(Tutorial2_2()); break;

            case TutorialNumber.TutorialNull: Hide_Popup(); break;
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
        Tutorial_text[2] = "2";
        Tutorial_text[3] = "22";
        Tutorial_text[4] = "2.1";
        Tutorial_text[5] = "2.1.1";
        Tutorial_text[6] = "2.2";

    }
        //THE INUMERATORS OF DESTRUCTION!!!!!
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
    public IEnumerator Tutorial1()
    {
        transform.position = new Vector3(943.27f, -45.42f, 0);
        Tutorial_Popup[1].SetActive(false);
        yield return new WaitForSeconds(1.0f);
        isFound = true;
        isScrapbot = false;
        yield return new WaitForSeconds(0f);
        Popup();
        TutorialText();
        Tutorial_Text_Label.text = Tutorial_text[1];
        yield return new WaitForSeconds(3);
        Tut_Enum = TutorialNumber.TutorialNull;
        yield return null;
    }
    //THE GANG OF 2!
    public IEnumerator Tutorial2()
    {
        transform.position = new Vector3(984.98f, 8.35f, 0);
        isFound = true;
        isScrapbot = false;
        Tutorial_Popup[2].SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Popup();
        TutorialText();
        Tutorial_Text_Label.text = Tutorial_text[2];
        yield return new WaitForSeconds(3);
        Tut_Enum = TutorialNumber.TutorialNull;
        yield return null;
    }
    public IEnumerator Tutorial22()
    {
        transform.position = new Vector3(984.98f, 8.35f, 0);
        isFound = true;
        isScrapbot = false;
        Tutorial_Popup[3].SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Popup();
        TutorialText();
        Tutorial_Text_Label.text = Tutorial_text[3];
        yield return new WaitForSeconds(3);
        Tut_Enum = TutorialNumber.TutorialNull;
        yield return null;
    }
    public IEnumerator Tutorial2_1()
    {
        transform.position = new Vector3(998.48f, -7.17f, 0);
        isFound = true;
        isScrapbot = false;
        Tutorial_Popup[4].SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Popup();
        TutorialText();
        Tutorial_Text_Label.text = Tutorial_text[4];
        yield return new WaitForSeconds(3);
        Tut_Enum = TutorialNumber.TutorialNull;
        yield return null;
    }
    public IEnumerator Tutorial2_1_1()
    {
        transform.position = new Vector3(943.27f, -45.42f, 0);
        isFound = true;
        isScrapbot = false;
        Tutorial_Popup[5].SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Popup();
        TutorialText();
        Tutorial_Text_Label.text = Tutorial_text[5];
        yield return new WaitForSeconds(3);
        Tut_Enum = TutorialNumber.TutorialNull;
        yield return null;
    }

    public IEnumerator Tutorial2_2()
    {
        transform.position = new Vector3(1033.83f, -2.48f, 0);
        isFound = true;
        isScrapbot = false;
        Tutorial_Popup[6].SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Popup();
        TutorialText();
        Tutorial_Text_Label.text = Tutorial_text[6];
        yield return new WaitForSeconds(3);
        Tut_Enum = TutorialNumber.TutorialNull;
        yield return null;
    }
    //The gang is dead;

}

