
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;
using System;

public class StringTutorial : UdonSharpBehaviour
{
    public int percent = 1;
    public int increase = 1;
    public TextMeshPro stringTutorialDisplay;
    void Start()
    {
        stringTutorialDisplay.text = String.Format("Loading: {0:p", percent);
    }
    void Update()
    {
        percent += increase;
        stringTutorialDisplay.text = String.Format("Loading: {0:p", percent);
    }
}
