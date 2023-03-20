
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ShrinkEnlarge : UdonSharpBehaviour
{
    public GameObject podium;
    public Vector3 podiumTransform;
    [UdonSynced]
    public bool podiumIsSmall = false;

    public override void Interact()
    {
        if (podiumIsSmall)
        {
            podiumTransform = new Vector3(.47f, .47f, .47f);
            podiumIsSmall = false;
        }
        else
        {
            podiumTransform = new Vector3(.2f, .2f, .2f);
            podiumIsSmall = true;
        }
        podium.transform.localScale = podiumTransform;
    }
}
