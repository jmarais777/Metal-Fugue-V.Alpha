using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class HeadPhonesExperience_Ui : MonoBehaviour
{
    public UIDocument HeadPhones_UIDOC;
    public float Timer = 5.0f;
    public bool IsTimeUp;

    public void Start()
    {
        HeadPhones_UIDOC = GetComponent<UIDocument>();
    }
    public void Update()
    {
        if (HeadPhones_UIDOC != null)
        {
            Timer -= Time.deltaTime;
        }

        if (Timer <= 0)
        {
            IsTimeUp = true;
        }
        if (IsTimeUp == true)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
    

