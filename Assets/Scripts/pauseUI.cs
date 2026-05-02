using UnityEngine;
using UnityEngine.UIElements;

// Title:  MENU in Unity
// Author: Brackeys
// Date: 17 april 2026
// Code Version: 8.0
// Availability: https://www.youtube.com/watch?v=JivuXdrIHK0&t=1sPAUSE

public class pauseUI : MonoBehaviour
{
    public Button ResumeButton;
    public Button QuitButton;
   public GameObject pauseMenu;
    public bool IsPaused = true;
     VisualElement root;
    public UIDocument Pausedoc;


    public void Start()
    {
        Pausedoc = GetComponent<UIDocument>();
        root = Pausedoc.rootVisualElement;
        ResumeButton = root.Q<Button>("Resume");
        QuitButton = root.Q<Button>("Quit");
    }
    public void OnEnable()
    {
        
        
        
    
    
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
            
        }
       
        if (ResumeButton != null)
        {
            ResumeGame();
        }




    }


  
    void PauseGame()
    {
      
      
        pauseMenu.SetActive(true);
        root.style.display = DisplayStyle.Flex;
        IsPaused = true;
        Time.timeScale = 0;
        
       
        }

    void ResumeGame()
    {

        pauseMenu.SetActive(false);
        root.style.display = DisplayStyle.None;
        IsPaused = false;
        Time.timeScale = 1;
      



    }
}

    
   