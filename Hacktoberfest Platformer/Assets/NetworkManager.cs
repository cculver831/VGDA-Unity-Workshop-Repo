using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[System.Serializable]
public class DefaultRoom
{
    public string Name;
    public int sceneIndex;
    public int maxPlayer;
}

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public GameObject roomUI;
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
    ///
    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try connect to server... ");
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public override void OnConnectedToMaster()
    {
        //Tell console we are connected
        Debug.Log("Conneceted to server.");
        base.OnConnectedToMaster();

        PhotonNetwork.JoinLobby();
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("We joined the lobby!");
        roomUI.SetActive(true);
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public void initializeRoom(int defaultRoomIndex)
    {
        DefaultRoom roomSettings = defaultRooms[defaultRoomIndex];

        //LOad Scene
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
        Debug.Log("Joined a room");
        base.OnJoinedRoom();
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A new player joined the room");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
