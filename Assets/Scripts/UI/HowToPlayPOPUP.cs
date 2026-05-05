using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class HowToPlayPOPUP : MonoBehaviour
{
    public UIDocument popup;
    public Button contin;
    void Awake()
    {
        popup = GetComponent<UIDocument>();
        if (popup != null)
        {
            var root = popup.rootVisualElement;
            contin = root.Q<Button>("ContinueButton");
            contin.RegisterCallback<ClickEvent>(continButtonOnClick);
        }
        
    }
  void continButtonOnClick(ClickEvent clk)
    {
        SceneManager.LoadScene("Proto2ScrapBlocking");
    }
}
