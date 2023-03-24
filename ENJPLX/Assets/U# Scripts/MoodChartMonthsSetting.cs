
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MoodChartMonthsSetting : UdonSharpBehaviour
{
    public moodchartDays moodchartDays;
    public GameObject monthsButt;
    public override void Interact()
    {
        Debug.Log("You clicked it.");
        moodchartDays.MonthSetting();
    }
}
