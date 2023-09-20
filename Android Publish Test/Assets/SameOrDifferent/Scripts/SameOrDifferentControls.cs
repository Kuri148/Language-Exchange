
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class SameOrDifferentControls : UdonSharpBehaviour
{
    public levelSelector levelSelector;
    public Text debugLog;
    [UdonSynced]int noodle = 1;

    
    void Start()
    {

    }
        public void ShowAnswer()
    {
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        levelSelector.redPicture.SetActive(true);
        levelSelector.bluePicture.SetActive(true);
        Debug.Log("Show answer button is pressed.");
        RequestSerialization();
    }

    public void ShowRed()
    {
        Debug.Log(levelSelector.redPicture.name);
        levelSelector.redPicture.SetActive(true);
        levelSelector.blueButton.SetActive(false);
        //levelSelector.answerButton.SetActive(true);
    }

    public void ShowBlue()
    {
        levelSelector.bluePicture.SetActive(true);
        levelSelector.redButton.SetActive(false);
        //levelSelector.answerButton.SetActive(true);
    }
    public void OnDeserialization()
    {
        levelSelector.redPicture.SetActive(true);
        levelSelector.bluePicture.SetActive(true);
    }
}
