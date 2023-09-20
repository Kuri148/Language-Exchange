
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Teleport : UdonSharpBehaviour
{
    public Transform portalDestination;
    void Start()
    {
        
    }
    public void OnPlayerTriggerEnter()
    {
            Networking.LocalPlayer.TeleportTo(portalDestination.position,
                                            portalDestination.rotation,
                                            VRC_SceneDescriptor.SpawnOrientation.Default, false);
    }
}
