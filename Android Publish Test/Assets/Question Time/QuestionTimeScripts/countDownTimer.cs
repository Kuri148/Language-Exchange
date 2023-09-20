
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using UnityEngine.UI;

public class countDownTimer : UdonSharpBehaviour
{
    [UdonSynced] public float timeValue;
    public Text timerText;
    public Text deskText;
    [UdonSynced] public bool resetPressed;
    [UdonSynced] public bool clockIsRunning;
    public Text playerName;
    [UdonSynced] public string currentSpeaker;

    public void Start()
    {
        timeValue = 180;
        resetPressed = false;
        timerText.text = "プレー押して!\nHit play!";
        deskText.text = "プレー押して!\nHit play!";
        clockIsRunning = false;
    }
// PlayButton Interact() calls this function directly.  ResetButton calls it indirectly. Controls whether clock is running r not.
    public void ClockSwitch()
    {
        Debug.Log("The bool function is accessed.");
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        currentSpeaker = Networking.LocalPlayer.displayName;
        playerName.text = currentSpeaker;
        if (timeValue == 0)
        {
            timeValue += 180;
        }
        clockIsRunning = !clockIsRunning;
        if (resetPressed)
        {
            timeValue = 180;
            resetPressed = false;
            clockIsRunning = true;
        }
        RequestSerialization();
    }
    public void ResetTime()
    {
        resetPressed = true;
        RequestSerialization();
        ClockSwitch();
    }
    void Update()
    {
        if (!clockIsRunning)
            return;

        if (clockIsRunning)
        {
            timeValue = timeValue > 0 ? timeValue -= Time.deltaTime : timeValue = 0;
            if (timeValue == 0)
            {
                timerText.text = "終わり!次の人! \n Time is up! Next person!";
                deskText.text = "終わり! \n Finish!";
                clockIsRunning = false; 
                return;
            }
            DisplayTime(timeValue);
        }
    }
    /*Newcomers will not see the correct time when they first arrive, 
    because time is not Udon Synced. Only whether clock is running or not is synced.
    However, when the Pause/Play or reset button is pressed. Players should see
    the same time. */
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay = timeToDisplay <= 0 ? timeToDisplay = 0 : timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("Ask questions to " + currentSpeaker + "!\n" + currentSpeaker +
                                           "に質問を聞いて!" + "!\n" + "{0:00}:{1:00}",
                                       minutes, seconds + " left/残り!");
        deskText.text = string.Format("{0:00}:{1:00}", minutes, seconds + "left/残り!");
    }
    public override void OnDeserialization()
    {

    }
}
