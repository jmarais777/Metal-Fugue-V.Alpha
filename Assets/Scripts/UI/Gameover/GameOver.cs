#if UNITY_EDITOR
using Mono.Cecil.Cil;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverUI : MonoBehaviour
{
    public UIDocument GameOverScreen;
    public VisualElement root;
    public EnergyPool energyPool;

    void OnEnable()
    {
        var Uidoc = GetComponent<UIDocument>();
        if (Uidoc == null || Uidoc.rootVisualElement == null)
        {
            return;
        }

        if (Uidoc != null)
        {
            root = Uidoc.GetComponent<VisualElement>();
        }
        if (root != null)
        {
            root.Q<Label>("LabelOver1");
            root.Q<Label>("LabelOver2");
        }
            if (GameOverScreen != null) 
                
        {
            
            root.style.display = DisplayStyle.Flex;
        }
       
    }

    public void ShowGameOver()
    {

       
        SceneManager.LoadScene("GameOverREAL");
    }
}

