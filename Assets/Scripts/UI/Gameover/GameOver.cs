#if UNITY_EDITOR
using Mono.Cecil.Cil;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverUI : MonoBehaviour
{
    private VisualElement gameOverScreen;
    public EnergyPool energyPool;
    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        gameOverScreen = root.Q<VisualElement>("GameOverScreen");
        gameOverScreen.style.display = DisplayStyle.None;
    }

    public void ShowGameOver()
    {
        gameOverScreen.style.display = DisplayStyle.Flex;

    }
}

