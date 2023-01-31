using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Inventory : MonoBehaviour
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
                    interactable.AttemptDialog();
                }
                else
                {
                    SearchItems(interactable);
                }

            }
        }
        
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public void AttemptInteract()
    {
       // if (inputValue.performed)
        {
            Collider2D hit = Physics2D.OverlapCircle(transform.position, 4, interactableLayer);
            Interactable interactable = hit.transform.gameObject.GetComponentInParent<Interactable>();

            //Debug.LogFormat("hit {0}}", hit);
            if (interactable != null)
            {

                if (items.Count == 0)
                {
                    interactable.AttemptDialog();
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
                interactable.AttemptInteract();
                return;
            }
        }

        interactable.AttemptDialog();
        
    }
}
