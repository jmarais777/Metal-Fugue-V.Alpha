using System.Collections.Generic;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Barks : MonoBehaviour
{
   public string[] Barks_Str;
    public UIDocument Barks_UiDoc;
    public Label Barks_Label;
    public List<GameObject> Bark_Objects = new List<GameObject>();

    void Start()
    {
        Barks_UiDoc = GetComponent<UIDocument>();
        if (Barks_UiDoc == null )
        {
            return;
        }
        else if (Barks_UiDoc != null)
        {
            var BarkRoot = Barks_UiDoc.rootVisualElement;
            Barks_Label = BarkRoot.Q<Label>("Bark_text");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Bark_0")
        {
            Bark_Text();
            StartCoroutine(Bark_Popup0());
        }
        if(collision.gameObject.name == "Bark_1")
        {
            Bark_Text();
          
        }
        if (collision.gameObject.name == "Bark_2")
        {
            Bark_Text();
            Barks_Label.text = Barks_Str[2];
        }
        if (collision.gameObject.name == "Barks_3")
        {
            Bark_Text();
            Barks_Label.text = Barks_Str[3];
        }
    }
    public void Bark_Text()
    {
        Barks_Str = new string[4];
            {
            Barks_Str[0] = " 00 Wow this place sure is dark teehhee";
            Barks_Str[1] = " 11 ohoooooo";
            Barks_Str[2] = "22 JeeeHeee";
            Barks_Str[3] = "3333";

            }
    }
    public IEnumerator Bark_Popup0()
    {
        Bark_Objects[0].SetActive(false);
        Barks_Label.text = Barks_Str[0];
        yield return new WaitForSeconds(3);
        Barks_Label.text = null;
        yield return null;
    }
    public IEnumerator Bark_Popup1()
    {
        Bark_Objects[1].SetActive(false);
        Barks_Label.text = Barks_Str[1];
        yield return new WaitForSeconds(3);
        Barks_Label.text = null;
        yield return null;
    }
    public IEnumerator Bark_Popup2()
    {
        Bark_Objects[2].SetActive(false);
        Barks_Label.text = Barks_Str[2];
        yield return new WaitForSeconds(3);
        Barks_Label.text = null;
        yield return null;
    }
    public IEnumerator Bark_Popup3()
    {
        Bark_Objects[3].SetActive(false);
        Barks_Label.text = Barks_Str[3];
        yield return new WaitForSeconds(3);
        Barks_Label.text = null;
        yield return null;
    }
    public IEnumerator Bark_Popup4()
    {
        Bark_Objects[4].SetActive(false);
        Barks_Label.text = Barks_Str[4];
        yield return new WaitForSeconds(3);
        Barks_Label.text = null;
        yield return null;
    }
}
