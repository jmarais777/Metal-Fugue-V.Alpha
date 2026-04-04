using Unity.VisualScripting;
using UnityEngine;

public class Interact : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject Artifact;



    void Start()
    {
       rb = GetComponent<Rigidbody2D>();

        bool isGameObjectInRange = true;
    }


    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            Debug.Log("heheh");
        }


    }
}
