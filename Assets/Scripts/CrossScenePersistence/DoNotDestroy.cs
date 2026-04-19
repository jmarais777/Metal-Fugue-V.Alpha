using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    public int ObjectIndex;

    private static GameObject[] persistingObjects = new GameObject[2];

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
        }

    }
}

