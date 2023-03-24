
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MoodChartDaySetting : UdonSharpBehaviour
{
    public moodchartDays moodchartDays;
    public GameObject dayButt;
    public override void Interact()
    {
        Debug.Log("You clicked it.");
        moodchartDays.DaySetting();
    }
}
