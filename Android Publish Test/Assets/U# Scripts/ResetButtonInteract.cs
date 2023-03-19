
using UdonSharp;
using UnityEngine;

public class ResetButtonInteract : UdonSharpBehaviour
{
    public countDownTimer countDownTimer;
    public override void Interact()
    {
        Debug.Log("You clicked reset.");
        countDownTimer.ResetTime();
    }
}
