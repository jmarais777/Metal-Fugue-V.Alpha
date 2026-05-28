
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Victory_UI : MonoBehaviour
{
    public UIDocument Vic_UI_Doc;
    public Button MainMen_Button;
    public Label Vict_Label;

    void Start()
    {
        Vic_UI_Doc = GetComponent<UIDocument>();
        if (Vic_UI_Doc == null)
        {
            return;
        }
        if (Vic_UI_Doc != null)
        {
            var VicRoot = Vic_UI_Doc.rootVisualElement;
            MainMen_Button = VicRoot.Q<Button>("MianMen_Button");
            Vict_Label = VicRoot.Q<Label>("Victory_Label");
        }
    }
    void Update()
    {
     MainMen_Button.RegisterCallback<ClickEvent>(Vict_Button_Onlick);
    }

    public void Vict_Button_Onlick(ClickEvent clk)
    {
        SceneManager.LoadScene("MainMenu");
    }
}

