
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;
using System;

public class SameOrDifferentBoardControls : UdonSharpBehaviour
{
    //reference scripts
    public levelSelector levelSelector;
    public SameOrDifferentControls SameOrDifferentControls;
    //information display
    public Text debugLog;
    public TextMeshProUGUI levelResults;
    public TextMeshProUGUI numberOfPlayersDisplay;
    public TextMeshProUGUI voteSameCounterText;
    public TextMeshProUGUI voteDifferentCounterText;
    public TextMeshProUGUI scoreboard;
    //buttons
    public GameObject voteSame;
    public GameObject voteDifferent;
    //variables
    [UdonSynced] public int voteSameCounter;
    [UdonSynced] public int voteDifferentCounter; 
    [UdonSynced] public int totalVoteCounter;
    [UdonSynced] public bool peopleThinkThePicturesAreTheSame = true;
    [UdonSynced] public string successOrFail = "Choose wisely!";
    public Dropdown playerCounter;
    [UdonSynced] public int numberOfPlayers = 2;
    [UdonSynced] public int teamScore = 0;
    [UdonSynced] public int livesLeft = 3;
    [UdonSynced] public int highScore = 10;


    void Start()
    {

    }
        public void VoteSame()
    {
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        voteSameCounter++;
        voteSameCounterText.text = "Same: " + voteSameCounter.ToString();
        voteSame.SetActive(false);
        voteDifferent.SetActive(false);
        CountVotes();
    }
    public void VoteDifferent()
    {
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        voteDifferentCounter++;
        voteDifferentCounterText.text = "Different: " + voteDifferentCounter.ToString();
        voteDifferent.SetActive(false);
        voteSame.SetActive(false);
        CountVotes();
    }
    public void CountVotes()
    {
        totalVoteCounter = voteSameCounter + voteDifferentCounter;
        if (totalVoteCounter >= (numberOfPlayers - 1))
        {
            if (voteSameCounter > voteDifferentCounter)
            {
                peopleThinkThePicturesAreTheSame = true;
                //debugLog.text = "true";
            }
            else
            {
                peopleThinkThePicturesAreTheSame = false;
                //debugLog.text = "false";
            }
            
            if ((peopleThinkThePicturesAreTheSame == true && levelSelector.isEven == true) ||
                (peopleThinkThePicturesAreTheSame == false && levelSelector.isEven == false))
            {
                successOrFail = "Success!";
                teamScore++;
            }
            else
            {
                successOrFail = "Failure!";
                livesLeft--;                
            }
            WriteVotes();
            UpdateScoreboard();
            RequestSerialization();
            SameOrDifferentControls.ShowAnswer();
        }
        else
        {
            RequestSerialization();
        }
    }
    public void AdjustPlayerCount()
    {
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        int dropDownValue = playerCounter.value;
        numberOfPlayers = dropDownValue + 2;
        UpdateScoreboard();
        Debug.Log(numberOfPlayers);
        RequestSerialization();
    }
    public void ResetBoard()
    {
        voteDifferentCounterText.text = "";
        voteSameCounterText.text = "";
        voteSameCounter = 0;
        voteDifferentCounter = 0;
        totalVoteCounter = 0;
        successOrFail = "Choose wisely!";
        WriteVotes();
    }
    public void OnDeserialization()
    {
        WriteVotes();
        UpdateScoreboard();
    }

    public void WriteVotes()
    {
        //debugLog.text = peopleThinkThePicturesAreTheSame.ToString() + " " + levelSelector.isEven.ToString();
        voteDifferentCounterText.text = "Different: " + voteDifferentCounter.ToString();
        voteSameCounterText.text = "Same: " + voteSameCounter.ToString();
        levelResults.text = successOrFail;
    }
    public void UpdateScoreboard()
    {
        if (teamScore > highScore)
        {
            highScore = teamScore;
        }
        if (livesLeft == 0)
        {
            
            livesLeft = 3;
            scoreboard.text = $"You ran out of lives. Your score was: {teamScore}.";
            teamScore = 0;
            return;
        }
        scoreboard.text = $"Team Score: {teamScore}                Lives left: {livesLeft}              High Score: {highScore}";
        numberOfPlayersDisplay.text = $"There are {numberOfPlayers} playing. \n You can change the number above.";
    }
}
