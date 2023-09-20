
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ImageAccessSameDifferent : UdonSharpBehaviour
{
    public GameObject[] accessButtons;
    public GameObject desiredPicture;

    void Start()
    {
        
    }

    public override void Interact()
    {
        desiredPicture.SetActive(true);
        foreach (GameObject button in accessButtons)
        {
            button.SetActive(false);
        }
    }
}
