using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseCondition : MonoBehaviour
{
    public GameObject PauseMenu_UIDOC;
    public UIDocument PauseMenu;
    public Button resume;
    public Button exit;
    public Button howtoplay;
    public bool IsPaused = false;
    public GameObject TransitionCOndition_Pause1;

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused = true;
            if (IsPaused == true)
            {
                ShowPauseMenu();
            }
        }
    }
    public void ShowPauseMenu()
    {
        PauseMenu.enabled = true;
        Time.timeScale = 0.0f;
         PauseMenu = GetComponent<UIDocument>();
        
        if (PauseMenu == null)
        {
            return;
        }

        else if (PauseMenu != null)
        {
            Debug.Log("VisualElement yes");
            var root = PauseMenu.rootVisualElement;
            resume = root.Q<Button>("Resume");
            exit = root.Q<Button>("ExitButton");
            howtoplay = root.Q<Button>("HowToButton");

            resume.RegisterCallback<ClickEvent>(resButtonOnClick);
            exit.RegisterCallback<ClickEvent>(exitButtonOnClick);
            howtoplay.RegisterCallback<ClickEvent>(howButtonOnCLick);

        }
        else
        {
            Debug.Log("VisualElement no");
        }

    
        


        }
    public void resButtonOnClick(ClickEvent clk)
    {

        Time.timeScale = 1.0f;
        PauseMenu.enabled = false;
        Debug.Log("clikyclicky");
    }

    void exitButtonOnClick (ClickEvent clk)
    {
        SceneManager.LoadScene("MainMenu");
        PauseMenu.enabled = false;
        Time.timeScale = 1.0f;
    }

    void howButtonOnCLick(ClickEvent clk)
    {
        TransitionCOndition_Pause1.SetActive(true);
        
    }



    
}
