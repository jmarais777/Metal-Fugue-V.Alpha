using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class HowToPlay_pause : MonoBehaviour
{
    public UIDocument HowToPlayPause;
    public Button ReturnToPause;
    public GameObject TransitionCOndition_Pause1;
    public void Update()
    {
        if (TransitionCOndition_Pause1.activeSelf)
        {
            ShowHowToPlay();
        }
       
    }
    void ShowHowToPlay()
    {
        HowToPlayPause.enabled = true;
        HowToPlayPause = GetComponent<UIDocument>();
        if (HowToPlayPause != null)
        {
            var root = HowToPlayPause.rootVisualElement;
            ReturnToPause = root.Q<Button>("ReturnToMenu");
            ReturnToPause.RegisterCallback<ClickEvent>(RetButtonOnClick);
        }

    }
    void RetButtonOnClick(ClickEvent clk)
    {
       HowToPlayPause.enabled = false;
    }
}
