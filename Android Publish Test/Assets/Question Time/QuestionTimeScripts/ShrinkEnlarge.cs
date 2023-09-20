
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ShrinkEnlarge : UdonSharpBehaviour
{
    public GameObject podium;
    [UdonSynced]public Vector3 podiumTransform;
    [UdonSynced] public bool podiumIsSmall = false;

    public override void Interact()
    {
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        ChangeSize();
    }
    public void ChangeSize()
    {
        if (podiumIsSmall)
        {
            podiumTransform = new Vector3(.37f, .37f, .37f);
            podiumIsSmall = false;
        }
        else
        {
            podiumTransform = new Vector3(.2f, .2f, .2f);
            podiumIsSmall = true;
        }
        RequestSerialization();
        ApplySize();
    }
    public void ApplySize()
    {
        podium.transform.localScale = podiumTransform;
    }
    public override void OnDeserialization()
    {
        ApplySize();
    }
}
