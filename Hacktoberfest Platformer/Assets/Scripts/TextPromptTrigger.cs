using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TextPromptTrigger : MonoBehaviour
{
    public string[] lines;
    public float textSpeed;


    ///-///////////////////////////////////////////////////////////
    ///
    public void TriggeredDialog(int photonID) {


        PhotonView pv = PhotonView.Find(photonID);
        TopDownMovement tdm = pv.GetComponent<TopDownMovement>();

        if (tdm.PlayerUI.DialogPanel.gameObject.activeSelf) { return; }
           
        Debug.LogFormat("triggering dialog...");
        tdm.PlayerUI.DisplayDialog(lines, textSpeed);

    }

}
