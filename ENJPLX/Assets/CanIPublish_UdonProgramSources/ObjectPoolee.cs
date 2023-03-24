using JetBrains.Annotations;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

[AddComponentMenu("")]
public class ObjectPoolee : UdonSharpBehaviour
{
    // Who is the current owner of this object. Null if object is not currently in use. 
    [PublicAPI, HideInInspector]
    public VRCPlayerApi Owner;
    private VRCPlayerApi _localPlayer;
    public bool woot;
    // This method will be called on all clients when the object is enabled and the Owner has been assigned.
    [PublicAPI]
    public void _OnOwnerSet()
    {
        _localPlayer = Networking.LocalPlayer;
        woot = true;
    }

    // This method will be called on all clients when the original owner has left and the object is about to be disabled.
    [PublicAPI]
    public void _OnCleanup()
    {
        // Cleanup the object here
    }
}