using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;
    public GameObject enemy7;
    public GameObject enemy8;
    public GameObject enemy9;

    public GameObject Boss1;
    public GameObject Boss2;

    public Interact interact;
    public int ArtifactTracker = 0;
    public GameObject Player;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.activeInHierarchy == true)
        {
            enemy3.SetActive(true);
            enemy4.SetActive(true);
            enemy5.SetActive(true);
            enemy6.SetActive(true);
            enemy7.SetActive(true);
            enemy8.SetActive(true);
            enemy9.SetActive(true);
            if (enemy1 == null && enemy2 == null && enemy3 == null && enemy3 == null && enemy5 == null && enemy6 == null && enemy7 == null && enemy8 == null && enemy9 == null)
            {
                Boss1.SetActive(true);
                Boss2.SetActive(true);
            }
        }
        if (interact.Artifact1.activeInHierarchy == false)
        {
            ArtifactTracker ++;
        }
        if (interact.Artifact2.activeInHierarchy == false)
        {
            ArtifactTracker++;
       }
        if (interact.Artifact3.activeInHierarchy == false)
             {ArtifactTracker++;}

        if (interact.Artifact4.activeInHierarchy == false)
                { ArtifactTracker++;}

        if (interact.Artifact5.activeInHierarchy == false)
             { ArtifactTracker++; }

        if (interact.Artifact6.activeInHierarchy == false)
        { ArtifactTracker++; }

        if (interact.Artifact7.activeInHierarchy == false)
        { ArtifactTracker++; }

        if (interact.Artifact8.activeInHierarchy == false)
        { ArtifactTracker++; }

 

        if(ArtifactTracker == 8)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
