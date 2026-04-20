using UnityEngine;
using UnityEngine.UIElements;

public class GameOverUI : MonoBehaviour
{
    private VisualElement gameOverScreen;

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