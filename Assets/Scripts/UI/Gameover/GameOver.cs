#if UNITY_EDITOR
using Mono.Cecil.Cil;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverUI : MonoBehaviour
{
    private VisualElement GameOverScreen;
    public EnergyPool energyPool;
    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
       
        GameOverScreen = root.Q<VisualElement>("GameOverScreen");
        if (GameOverScreen != null)
        {
            GameOverScreen.style.display = DisplayStyle.Flex;
        }
       
    }

    public void ShowGameOver()
    {

       
        SceneManager.LoadScene("GameOverREAL");
    }
}

