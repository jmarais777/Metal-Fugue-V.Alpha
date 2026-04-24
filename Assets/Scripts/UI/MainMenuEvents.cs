using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Composites;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class MainMenuEvents : MonoBehaviour
{
    private UIDocument document;
    private Button button;
   
    private void Awake()
    {
        document = GetComponent<UIDocument>();
        button = document.rootVisualElement.Q("Startgame") as Button;
        button.RegisterCallback<ClickEvent>(OnPlayGameCLick);
    }

    private void OnDisable()
    {
        button.UnregisterCallback<ClickEvent>(OnPlayGameCLick);
    }

    private void OnPlayGameCLick(ClickEvent evt)
    {
        SceneManager.LoadScene("DULTEST");
    

    }
   

}

