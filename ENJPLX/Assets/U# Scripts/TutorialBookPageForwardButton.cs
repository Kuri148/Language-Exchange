
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TutorialBookPageForwardButton : UdonSharpBehaviour
{
    public TutorialBookPageFlip TutorialBookPageFlip;
    public GameObject ForwardButton;

    public override void Interact()
    {
        TutorialBookPageFlip.PageCountUp();
    }
}
