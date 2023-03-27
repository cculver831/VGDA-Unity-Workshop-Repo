using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// Data to display in lobby (name and ready status)
/// </summary>
public class PlayerLobbyData : MonoBehaviour
{
    public string PlayerName;
    public Photon.Realtime.Player player;

}