using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;
using System.Globalization;

public class moodchartDays : UdonSharpBehaviour
{
    public TextMeshPro timeTextTiny;
    public TextMeshPro timeText;
    // int that decides whether information for day month or year is displayed. 1 is days. 2 is months. 3 is years
    private int dmyVariation = 1;
    private DateTime currentTime;
    private string[] theWeek = new string[7];
    private string[] sevenMonths = new string[7];
    private string[] sevenYears = new string[7];
    private DateTime reiwaStart = new DateTime(2019, 1, 1);
    private string era;
    
   
    //Finds and displays the past 6 days of the week on the moodchart.
    void Start()
    {
        currentTime = DateTime.Now;
        FindDays();
        FindMonths();
        FindYears();
        PrintTime();
    }
//Gets the past six days.
    void FindDays()
    {
        for (int i = 0; i < theWeek.Length - 1; i++)
        {
            theWeek[i] = (currentTime.AddDays(i+1).ToString("ddd") + currentTime.AddDays(i+1).ToString("ddd", CultureInfo.GetCultureInfo("ja-JP"))).PadRight(16);
        }
        theWeek[6] = "Today(今日)";
    }
    //gathers the past 7 months.
    void FindMonths()
    {
        for (int i = 0; i < sevenMonths.Length; i++)
        {
            sevenMonths[i] = (currentTime.AddMonths(i-6).ToString("MMM") + " " + (currentTime.AddMonths(i-6).ToString("MM", CultureInfo.GetCultureInfo("ja-JP")) + "月")).PadRight(14);  
        }
    }
    //dynamically gathers past 7 years
    void FindYears()
    {

        for (int i = 0; i < sevenYears.Length; i++)
        {
            if (currentTime.AddYears(i-6) >= reiwaStart)
                {
                    era = currentTime.AddYears(i - 6 - 2018).ToString("yy");
                    sevenYears[i] = ("'" + currentTime.AddYears(i-6).ToString("yy") + "/" + "令和"+ era ).PadRight(10);
                }
            else
                {
                    era = currentTime.AddYears( i -6 - 1988 ).ToString("yy");
                    sevenYears[i] = ("'" + currentTime.AddYears(i-6).ToString("yy") + "/" + "平成" + era).PadRight(10);
                }  
        }
    }
    //Displays the selected time span to the chart
    void PrintTime()
    {
        switch(dmyVariation)
        {
            case 1:
                timeText.text = (String.Join("", theWeek));
                timeTextTiny.text = (String.Join("", theWeek));
                RequestSerialization();
                break; 
            case 2:
                timeText.text = (String.Join("", sevenMonths));
                timeTextTiny.text = (String.Join("", sevenMonths));
                RequestSerialization();
                break;
            case 3:
                timeText.text = (String.Join("", sevenYears));
                timeTextTiny.text = (String.Join("", sevenYears));
                RequestSerialization();
                break;
        } 
    }
    //These next three are attached to Triggers calling this class that change the selected dislpay time span with an int.
    public void DaySetting()
    {
        Debug.Log("Setting to Days");
        dmyVariation = 1;
        PrintTime();
    }
    public void MonthSetting()
    {
        Debug.Log("Setting to Months");
        dmyVariation = 2;
        PrintTime();
    }
    public void YearSetting()
    {
        Debug.Log("Setting to Years");
        dmyVariation = 3;
        PrintTime();
    }
}
