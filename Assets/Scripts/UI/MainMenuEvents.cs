using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Composites;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class MainMenuEvents : MonoBehaviour
{
    private UIDocument document;
    private Button button;
    private Button QuitToD;
  //  public ConditionalAudios ForButtonCheck;
   
    private void Awake()
    {
        document = GetComponent<UIDocument>();
        button = document.rootVisualElement.Q("Startgame") as Button;
        QuitToD = document.rootVisualElement.Q("QuitToDesktop") as Button;
        button.RegisterCallback<ClickEvent>(OnPlayGameCLick);
        QuitToD.RegisterCallback<ClickEvent>(OnExitButtonClick);
    }

    private void OnDisable()
    {
        button.UnregisterCallback<ClickEvent>(OnPlayGameCLick);
    }

    private void OnPlayGameCLick(ClickEvent evt)
    {
        //ForButtonCheck.ButtonCheck = true;
        SceneManager.LoadScene("HowToPlayPOPUP");
    }
    private void OnExitButtonClick(ClickEvent evt)
    {
        //ForButtonCheck.ButtonCheck = true;
        Application.Quit();
    }


}

