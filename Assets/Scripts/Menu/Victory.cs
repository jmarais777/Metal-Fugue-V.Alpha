using UnityEngine;

public class Victory : MonoBehaviour
{
    public GameObject player;
    public GameObject SecurityGateUnlocked;
    public float Proximity = 4.0f;
    public GameObject VictoryScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float SecGate = Vector2.Distance(player.transform.position, SecurityGateUnlocked.transform.position);
        if (SecurityGateUnlocked != null)
        {

            if (Input.GetKeyDown(KeyCode.E) && SecGate <= Proximity)
            {
                VictoryScreen.SetActive(true);
            }
        }



    }
}
