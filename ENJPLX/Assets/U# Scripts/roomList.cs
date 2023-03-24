
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class roomList : UdonSharpBehaviour
{
    public GameObject RoomList;
    public string[] nameList = new string[8];
    public Text nameDisplay;
    public string playerNameTag;
    public Transform target;
    public int playerID;
    public VRCPlayerApi dude;
    public string outputText; 

    void OnPlayerJoined()
    {
        RequestSerialization();
    }
    void RoomListChange()
        {
            nameDisplay.text = nameList[0] + "\n" + nameList[1]+ "\n" + nameList[2]+ "\n" + nameList[3]+ "\n" + nameList[4]+ "\n" + nameList[5]+ "\n" + nameList[6]+ "\n" + nameList[7]+ "\n";
            RequestSerialization();
        }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
        {
            Debug.Log("You entered.");
            outputText = player.displayName;
            for(int i=0; i < nameList.Length; i++)
                {
                if (nameList[i] == "")
                    {
                    nameList[i] = outputText;
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
                if (nameList[i] == outputText)
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
                if (nameList[i] == outputText)
                    {
                    nameList[i] = "";
                    Debug.Log(nameList);
                    RoomListChange();
                    break;
                    }
                }
        } 
 }