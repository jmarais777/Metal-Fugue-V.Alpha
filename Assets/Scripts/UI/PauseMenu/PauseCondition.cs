using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseCondition : MonoBehaviour
{
    public GameObject PauseMenu_UIDOC;
    public UIDocument PauseMenu;
    public Button resume;
    public bool IsPaused = false;
 
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
            resume.RegisterCallback<ClickEvent>(ButtonOnClick);

        }
        else
        {
            Debug.Log("VisualElement no");
        }





    }
    public void ButtonOnClick(ClickEvent clk)
    {
   Time.timeScale = 1.0f;
  PauseMenu.enabled = false;
        Debug.Log("clikyclicky");
    }





    
}
