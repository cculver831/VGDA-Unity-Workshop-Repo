using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

[System.Serializable]
public class DefaultRoom
{
    public string Name;
    public int sceneIndex;
    public int maxPlayer;
}

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public GameObject StartUI;
    public GameObject roomUI;
    public GameObject DungeonList;
    public TextMeshProUGUI debugOutput;
    public List<DefaultRoom> defaultRooms;
    // Start is called before the first frame update
    void Start()
    {
        //ConnectToServer();
    }

    // Update is called once per frame
    void Update()
    {

    }


    ///-///////////////////////////////////////////////////////////
    /// Called when pressing play
    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        debugOutput.text = "trying to connect to server... ";
    }

    ///-///////////////////////////////////////////////////////////
    /// Called when player successfully connects to Master
    public override void OnConnectedToMaster()
    {
        //Tell console we are connected
        debugOutput.text = "conneceted to server.";
        base.OnConnectedToMaster();

        PhotonNetwork.JoinLobby();
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        debugOutput.text = "connected to lobby";
        StartUI.SetActive(false);
        roomUI.SetActive(true);
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public void InititalizeRoom(int defaultRoomIndex)
    {
        DefaultRoom roomSettings = defaultRooms[defaultRoomIndex];

        //Load Scene
        PhotonNetwork.LoadLevel(roomSettings.sceneIndex);
        //Create new room options, will change to 2 players probabaly
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)roomSettings.maxPlayer;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        //Create a room or join with the room options
        PhotonNetwork.JoinOrCreateRoom(roomSettings.Name, roomOptions, TypedLobby.Default);
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public override void OnJoinedRoom()
    {
        debugOutput.text = "joined room";
        base.OnJoinedRoom();
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        debugOutput.text = "A new player joined the room";
        base.OnPlayerEnteredRoom(newPlayer);

    }

    ///-///////////////////////////////////////////////////////////
    ///
    public void GetPlayerNickName(string name)
    {
        PhotonNetwork.LocalPlayer.NickName = name;
        roomUI.SetActive(false);
        DungeonList.SetActive(true);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        debugOutput.text = message;
    }
}
