using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

//Title: How to create a list with flexible entries in your Unity UI
//Author: Christina
//Date: 19 april 2026
//Code Version: 9.0
//Availability: https://youtu.be/pafvGFCwVps
public class ContentManager : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Entry entryPrefab;

    [Serializable]
    public class Entryinfo
    {
        [TextArea(3, 8)] public string Text;
        public Sprite icon;
    }

    [SerializeField] private List<Entryinfo> entries = new List<Entryinfo>();

    
    private void Start()
    {
        CreateEntries();
    }

    [ContextMenu("CreateEntries")]
    private void CreateEntries()
    {
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }
        foreach (var entry in entries)
        {
            var newEntry = Instantiate(entryPrefab, container);
            newEntry.gameObject.SetActive(true);
            newEntry.Setup(entry.Text);
        }
    }
}

            