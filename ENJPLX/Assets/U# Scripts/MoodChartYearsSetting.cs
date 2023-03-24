using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MoodChartYearsSetting : UdonSharpBehaviour
{
    public moodchartDays moodchartDays;
    public GameObject yearButt;
    public override void Interact()
    {
        Debug.Log("You clicked it.");
        moodchartDays.YearSetting();
    } 
}
