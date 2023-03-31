// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AsteroidsGameManager.cs" company="Exit Games GmbH">
//   Part of: Asteroid demo
// </copyright>
// <summary>
//  Game Manager for the Asteroid Demo
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections;

using UnityEngine;
using UnityEngine.UI;

using Photon.Realtime;
using Photon.Pun.UtilityScripts;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Pun;
using UnityEngine.InputSystem;

public class NetworkSpawner : MonoBehaviourPunCallbacks
    {
        public static NetworkSpawner Instance = null;

        public float minx;
        public float maxX;
        public float minY;
        public float maxY;

    ///-///////////////////////////////////////////////////////////
    ///
    private void Start()
    {
        
    }

    ///-///////////////////////////////////////////////////////////
    ///
    IEnumerator SpawnPlayer()
    {
        yield return new WaitForSeconds(1f);

        Vector2 randPosition = new Vector2(Random.Range(minx, maxX), Random.Range(minY, maxY));
        GameObject player = PhotonNetwork.Instantiate("NetworkPlayer", randPosition, Quaternion.identity);
        player.GetComponentInChildren<TopDownMovement>().enabled = true;
        player.GetComponentInChildren<TopDownMovement>().PlayerUI.SetActive(true);
        player.GetComponentInChildren<TopDownMovement>().playerCamera.SetActive(true);
        player.GetComponentInChildren<TopDownMovement>().playerCamera.tag = "MainCamera";
        player.GetComponentInChildren<TopDownMovement>().playerName.text = PhotonNetwork.LocalPlayer.NickName;
        player.GetComponentInChildren<PlayerInput>().enabled = true;
        player.GetComponentInChildren<PlayerHealth>().enabled = true;


    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();



        StartCoroutine(SpawnPlayer());
    }
}
