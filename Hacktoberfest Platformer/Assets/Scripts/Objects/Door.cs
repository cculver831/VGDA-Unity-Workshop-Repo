using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public Animator animator;

    public TextPromptTrigger textPrompt;

    ///-///////////////////////////////////////////////////////////
    ///
    public override void AttemptInteract()
    {
        animator.SetBool("isOpen", true);
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public override void AttemptDialog()
    {
        base.AttemptDialog();
        textPrompt.TriggeredDialog();
    }
}
