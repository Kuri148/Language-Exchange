
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using UnityEngine.UI;

public class countDownTimer : UdonSharpBehaviour
{
    public float timeValue = 10;
    public Text timerText;
    public Text deskText;
    [UdonSynced]
    public bool resetBool = false;
    [UdonSynced]
    public bool startPauseBool;
    public Text playerName;
    [UdonSynced]
    public string currentSpeaker;

    public void Start()
    {
        timerText.text = "プレー押して!\nHit play!";
        deskText.text = "プレー押して!\nHit play!";
    }
// PlayButton Interact() calls this function directly.  ResetButton calls it indirectly. Controls whether clock is running r not.
    public void StartPauseSwitch()
    {
        Debug.Log("The bool function is accessed.");
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        currentSpeaker = Networking.LocalPlayer.displayName;
        playerName.text = currentSpeaker;
        if (resetBool)
        {
            timeValue = 20;
            resetBool = false;
            startPauseBool = true;
        }
        else
        {
            startPauseBool = !startPauseBool;
        }

        RequestSerialization();
    }
    public void ResetTime()
    {
        resetBool = true;
        RequestSerialization();
        StartPauseSwitch();
    }
    void Update()
    {
        if (!startPauseBool)
            return;

        if (startPauseBool)
        {
            timeValue = timeValue > 0 ? timeValue -= Time.deltaTime : timeValue = 0;
            if (timeValue == 0)
            {
                timerText.text = "終わり!次の人! \n Time is up! Next person!";
                return;
            }
            DisplayTime(timeValue);
        }
    }
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
        playerName.text = currentSpeaker;
    }
}
