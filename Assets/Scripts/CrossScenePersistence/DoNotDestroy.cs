using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    public int ObjectIndex;
    public GameObject scrapheap;
    public GameObject ScrapBot;
    public GameObject EnemyNPC;
    public GameObject Obst1;
    public GameObject Obst2;
    public GameObject Obst3;
    public GameObject Obst4;
    public GameObject Obst5;
    public GameObject Obst6;
    public GameObject Obst7;
    public GameObject Obst8;


    private static GameObject[] persistingObjects = new GameObject[3];

    void Awake()
    {
        //Allows for peristence across scenes
        DontDestroyOnLoad(gameObject);

        if (persistingObjects[ObjectIndex] == null)
        {
            persistingObjects[ObjectIndex] = gameObject;
           
            DontDestroyOnLoad(gameObject);
        
        }
        else if (persistingObjects[ObjectIndex] != gameObject)
        {
            Destroy(gameObject);
            Destroy(scrapheap);
            Destroy(ScrapBot);
            Destroy(EnemyNPC);
            Destroy(Obst1);
            Destroy(Obst2);
            Destroy(Obst3);
            Destroy(Obst4);
            Destroy(Obst5);
            Destroy(Obst6);
            Destroy(Obst7);
            Destroy(Obst8);

        }

    }
}

