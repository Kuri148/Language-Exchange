
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TutorialBookPageFlipBackward : UdonSharpBehaviour
{
    public TutorialBookPageFlip TutorialBookPageFlip;
    public GameObject backwardButton;

    public override void Interact()
    {
        TutorialBookPageFlip.PageCountDown();
    }

}
