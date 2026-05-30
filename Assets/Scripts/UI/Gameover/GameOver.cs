#if UNITY_EDITOR
using Mono.Cecil.Cil;
using Unity.VisualScripting;

#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverUI : MonoBehaviour
{
    public UIDocument GameOver;
    public EnergyPool energyPool;
    public Button RetryButton;
    public ConditionalAudios ForButtonCheck;


    private void OnEnable()
    {
        GameOver = GetComponent<UIDocument>();
        var root = GameOver.rootVisualElement;

        RetryButton = root.Q<Button>("RetryButton");
        
        
            RetryButton.RegisterCallback<ClickEvent>(ButtOnClick);
            
           
            Debug.Log("I'm ALivee");
        
 


    }

    public void ShowGameOver()
    {

        SceneManager.LoadScene("GameOverREAL");
    }
    public void ButtOnClick(ClickEvent clk)
    {
        ForButtonCheck.ButtonCheck = true;
        SceneManager.LoadScene("Proto2ScrapBlocking");
    }
}

//before I simplified
/*if (GameOverScreen != null)

{

    root.style.display = DisplayStyle.Flex;
} */

/*var Uidoc = GetComponent<UIDocument>();
if (Uidoc == null || Uidoc.rootVisualElement == null)
{
    return;
}

if (Uidoc != null)
{
    var root = Uidoc.rootVisualElement;
    Debug.Log("UI doc active");
}
if (root != null)
{
    root.Q<Label>("LabelOver1");
    root.Q<Label>("LabelOver2");
    RetryButton = root.Q<Button>("RetryButton");
    Debug.Log("Visual eleemt active");
}
if (RetryButton != null)
{
    Debug.Log("I'm ALivee");
    RetryButton.clicked += ButtOnClick;
    RetryButton.clicked -= ButtOnClick;
} */