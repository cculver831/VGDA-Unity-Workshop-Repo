using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Door : Interactable
{
    public Animator animator;

    public TextPromptTrigger textPrompt;

    ///-///////////////////////////////////////////////////////////
    ///
    public override void AttemptInteract()
    {
        animator.SetBool("isOpen", true);
        Debug.LogFormat("attempt interact successful");
        photonView.RequestOwnership();
        
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
