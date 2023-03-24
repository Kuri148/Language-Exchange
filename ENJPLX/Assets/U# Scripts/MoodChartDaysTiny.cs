
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using System;
using UnityEngine.UI;

public class MoodChartDaysTiny : UdonSharpBehaviour
{
    private Text dayText;
    void Start()
    {
        dayText = GetComponent<Text>();
        string dayZero = DateTime.Now.ToString("ddd");
        string dayOne = DateTime.Now.AddDays(-1).ToString("ddd");
        string dayTwo = DateTime.Now.AddDays(-2).ToString("ddd");
        string dayThree = DateTime.Now.AddDays(-3).ToString("ddd");
        string dayFour = DateTime.Now.AddDays(-4).ToString("ddd");
        string dayFive = DateTime.Now.AddDays(-5).ToString("ddd");
        string daySix = DateTime.Now.AddDays(-6).ToString("ddd");
        dayText.text = "    " + daySix + "    " + dayFive + "    " + dayFour + "   " + dayThree + "    " + dayTwo + "    " + dayOne + " " + "Today";
    }
}
