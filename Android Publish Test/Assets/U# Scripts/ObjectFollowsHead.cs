
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class ObjectFollowsHead : UdonSharpBehaviour
{
    public GameObject prefab;     // nothing here yet

    public Text debugText;
    public Vector3 objectOnHead;
    public float headOffset = 1.8f;
    public Quaternion myQuaternion = new Quaternion(0, 0, 0, 1);

    void Update()
    {
        var player = Networking.LocalPlayer;

        if (player != null)
        {
            // Get the position of the players head
            Vector3 headData = player.GetPosition();
            myQuaternion = player.GetRotation();
            // var headData = player.GetTrackingData(VRCPlayerApi.TrackingDataType.Head); 
            Debug.Log(headData.GetType());
            objectOnHead = headData;
            prefab.transform.position = new Vector3(objectOnHead.x, headOffset, headData.z + .3f);
            debugText.text = string.Format("Head-Rot: {0}\r\n", myQuaternion.ToString());
            prefab.transform.rotation = myQuaternion;
            //prefab.transform.RotateAround(headData, Vector3.up, myQuaternion.y);
            //transform.LookAt(headData);
        }
    } 
}