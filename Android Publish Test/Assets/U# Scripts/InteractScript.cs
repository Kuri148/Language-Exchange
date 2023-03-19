
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class InteractScript : UdonSharpBehaviour
{
    public UdonBehaviour SourceScript;

    void Start()
    {
        
    }
    public override void Interact()
    {
        SourceScript.SendCustomEvent("ExteriorFunction");
    }
}
