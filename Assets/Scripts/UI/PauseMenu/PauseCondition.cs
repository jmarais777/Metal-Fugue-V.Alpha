using System.Reflection.Emit;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Label = UnityEngine.UIElements.Label;

public class PauseCondition : MonoBehaviour
{
    
    public GameObject PauseMenu_UIDOC;
    public UIDocument PauseMenu;
   
    public Button resume;
    public Button exit;
    public Button howtoplay;
    public UnityEngine.UIElements.Label pauselab;
    public bool IsPaused = false;
    public GameObject TransitionCOndition_Pause1;
    public GameObject TransitionCOndition_Pause2;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || TransitionCOndition_Pause2.activeSelf)
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
            pauselab = root.Q<Label>("PauseLabel");


            pauselab.schedule.Execute(() => { pauselab.ToggleInClassList("label--pulse"); }).Every(1000);
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
        TransitionCOndition_Pause2.SetActive(false);
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
        PauseMenu.enabled = false;
        
    }



    
}
