using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using Photon.Pun;

public class Inventory : MonoBehaviourPun
{

    public List<Item> items;
    public TopDownMovement player;
    public LayerMask interactableLayer;

    ///-///////////////////////////////////////////////////////////
    ///
    public void AddItem(Item item)
    {
        items.Add(item);
    }


    ///-///////////////////////////////////////////////////////////
    ///
    public void AttemptInteract(CallbackContext inputValue)
    {
        if (inputValue.performed)
        {
            Collider2D hit = Physics2D.OverlapCircle(transform.position, 4, interactableLayer);
            Interactable interactable = hit.transform.gameObject.GetComponentInParent<Interactable>();

            //Debug.LogFormat("hit {0}}", hit);
            if (interactable != null)
            {

                if (items.Count == 0)
                {
                    interactable.AttemptDialog(photonView.ViewID);
                }
                else
                {
                    SearchItems(interactable);
                }

            }
        }
        
    }

    private void SearchItems(Interactable interactable)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == interactable.ID)
            {
                photonView.RequestOwnership();
                interactable.AttemptInteract();
                return;
            }
        }

        interactable.AttemptDialog(photonView.ViewID);
        
    }
}
