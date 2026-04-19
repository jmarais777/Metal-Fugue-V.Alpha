using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Title: How to create a list with flexible entries in your Unity UI
//Author: Christina
//Date: 19 april 2026
//Code Version: 9.0
//Availability: https://youtu.be/pafvGFCwVps

public class Entry : MonoBehaviour
{
    [SerializeField] private TMP_Text textField;
    [SerializeField] private Image iconImage;

    private void Reset()
    {
        textField = GetComponentInChildren<TMP_Text>();
        iconImage = GetComponentInChildren<Image>();
    }

    public void Setup(string text)
    {
       textField.SetText(text);
       
    }

}


