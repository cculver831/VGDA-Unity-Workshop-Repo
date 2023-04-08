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
using ExitGames.Client.Photon;

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

    // If you have multiple custom events, it is recommended to define them in the used class
    public const byte UPDATETARGETIST = 1;
    ///-///////////////////////////////////////////////////////////
    ///
    IEnumerator SpawnPlayer()
    {
        yield return new WaitForSeconds(1f);

        Vector2 randPosition = new Vector2(Random.Range(minx, maxX), Random.Range(minY, maxY));
        GameObject player = PhotonNetwork.Instantiate("NetworkPlayer", randPosition, Quaternion.identity);


        //set nickName
        PhotonView photonView = player.GetComponentInChildren<PhotonView>();
        photonView.Owner.NickName = PhotonNetwork.LocalPlayer.NickName;


        TopDownMovement tdm = player.GetComponentInChildren<TopDownMovement>();
        tdm.playerName.enabled = true;
        tdm.playerName.text = PhotonNetwork.LocalPlayer.NickName;
        tdm.enabled = true;
        tdm.PlayerUI.gameObject.SetActive(true);
        tdm.playerCamera.SetActive(true);
        tdm.playerCamera.tag = "MainCamera";

        player.GetComponentInChildren<PlayerInput>().enabled = true;
        player.GetComponentInChildren<PlayerHealth>().enabled = true;


        if (photonView)
        {
            photonView.Owner.NickName = PhotonNetwork.LocalPlayer.NickName;

            photonView.RPC("SetPlayerName", RpcTarget.OthersBuffered, photonView.ViewID);
        }

    }




    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        StartCoroutine(SpawnPlayer());
    }
}
