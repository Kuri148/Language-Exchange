
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class LanguageLevelSwitch : UdonSharpBehaviour
{
    public LanguageProficiency LanguageProficiency;
    public string pressedButton;

    public override void Interact()
    {
        Debug.Log("Language Switch sends a" + gameObject.name);
        pressedButton = gameObject.name;
        LanguageProficiency.LevelSelect(pressedButton);
    }
}
