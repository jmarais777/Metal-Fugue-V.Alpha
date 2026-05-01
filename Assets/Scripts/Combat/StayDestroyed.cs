using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class StayDestroyed : MonoBehaviour

{
    public GameObject ScavengerHeap;
    public string objID = "Scavengerheap";
    public static List<string> isDestroyed = new List<string>();

    void Start()
    {

        if (isDestroyed.Contains(objID))
        {
            Destroy(ScavengerHeap);
            Debug.Log("DOubleded");
        }

    }


    public void DestructionReg()
    {
        if (!isDestroyed.Contains(objID))
        {
           isDestroyed.Add(objID);
        }
        Destroy(ScavengerHeap);
    }
}

    
   

