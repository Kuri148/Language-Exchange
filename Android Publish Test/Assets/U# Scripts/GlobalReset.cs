
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class GlobalReset : UdonSharpBehaviour
{
    public GameObject[] promptPictures;
    public GameObject[] promptButtons;
    [UdonSynced] bool picturesVisible = false;
    [UdonSynced] bool buttonsVisible = true;

    void Start()
    {
        
    }

    public override void Interact()
    {
        
        ResetStage();
        RequestSerialization();
    }

    void ResetStage()
    {
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        foreach (GameObject picture in promptPictures)
        {
            picture.SetActive(picturesVisible);
        }
        foreach (GameObject button in promptButtons)
        {
            button.SetActive(buttonsVisible);
        }
    }
    public override void OnDeserialization()
    {
        ResetStage();
    }
}
