using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Interact : MonoBehaviour
{
    public Transform Artifact;
    public Transform Player;
    bool IsPlayerInProximity = true;
    public float InteracatProximity = 2f;
    void Update()
    {
        float distance = Vector3.Distance(Artifact.position, Player.position);

        if (Input.GetKeyDown(KeyCode.E))
        {
            IsPlayerInProximity = true;
            if (distance < InteracatProximity)
            {

                Debug.Log("rheheeh");

            }


        }
    }
}