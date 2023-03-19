
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class RoomListTriggerS : UdonSharpBehaviour
{
    public GameObject PortalTrigger;
    public Transform PortalTarget;

    void Interact()
        {
            Networking.LocalPlayer.TeleportTo(PortalTarget.position,PortalTarget.rotation);
        }
}
