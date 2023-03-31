using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// PlayerData to send over the network via Photon HashTable
/// </summary>
public class PlayerNetworkData
{
    public const string PLAYER_READY = "isPlayerReady"; //Bool returning player Ready Status
    public const string PLAYER_SELECTION_NUMBER = "Player_Selection_Number"; //Int value of player we want
    public const string PLAYER_LOADOUT = "Player_Loadout"; //Int value for loadout bitflags
    public const string PLAYER_OVERLORD = "isPlayerOverlord"; //bool returning player Overlord status ( For Overlord Pregame)

}