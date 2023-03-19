
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class portalNameGrab : UdonSharpBehaviour
{
    public GameObject RoomListTrigger;
    public string[] nameList = new string[8];
    public Text nameDisplay;
    public string playerNameTag;
    public Transform target;
    
    void OnPlayerJoined()
    {
        RequestSerialization();
    }
    void RoomListChange()
        {
            RequestSerialization();
            nameDisplay.text = nameList[0] + "\n" + nameList[1]+ "\n" + nameList[2]+ "\n" + nameList[3]+ "\n" + nameList[4]+ "\n" + nameList[5]+ "\n" + nameList[6]+ "\n" + nameList[7]+ "\n";
            
        }
    void OnPlayerTriggerEnter()
        {
            Debug.Log("You entered.");
            nameDisplay = GetComponentInChildren<Text>();
            playerNameTag = Networking.LocalPlayer.displayName;
            for(int i=0; i < nameList.Length; i++)
                {
                if (nameList[i] == "")
                    {
                    nameList[i] = playerNameTag;
                    Debug.Log(nameList);
                    RoomListChange();
                    break;
                    }
                }
        }
    void OnPlayerTriggerExit()
        {
            Debug.Log("You left.");
            for (int i=0; i < nameList.Length; i++)
                {
                if (nameList[i] == playerNameTag)
                    {
                    nameList[i] = "";
                    Debug.Log(nameList);
                    RoomListChange();
                    break;
                    }
                }
        } 
    void OnPlayerLeft()
        {
            Debug.Log("You logged out.");
            for (int i=0; i < nameList.Length; i++)
                {
                if (nameList[i] == playerNameTag)
                    {
                    nameList[i] = "";
                    Debug.Log(nameList);
                    RoomListChange();
                    break;
                    }
                }
        } 
 }