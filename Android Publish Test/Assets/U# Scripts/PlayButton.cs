
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class PlayButton : UdonSharpBehaviour
{
    public countDownTimer countDownTimer;
    public override void Interact()
    {
        Debug.Log("You clicked it.");
        countDownTimer.StartPauseSwitch();
    }
}
