using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Door : Interactable
{
    public Animator animator;

    public TextPromptTrigger textPrompt;

    [SerializeField]
    bool hasOpened = false;
    ///-///////////////////////////////////////////////////////////
    ///
    [PunRPC]
    public override void AttemptInteract()
    {
        if(animator.GetBool("isOpen") == false)
        {
            photonView.RPC("AttemptInteract", RpcTarget.AllBufferedViaServer);
            animator.SetBool("isOpen", true);
            Debug.LogFormat("attempt interact successful");
            hasOpened = true;
        }

        
        
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public override void AttemptDialog(int photonID)
    {
        if(hasInteracted == false)
        {
            base.AttemptDialog(photonID);
            textPrompt.TriggeredDialog(photonID);
            hasInteracted = true;
        }
    }
}
