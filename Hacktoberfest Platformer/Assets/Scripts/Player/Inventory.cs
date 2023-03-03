using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Inventory : MonoBehaviour
{

    public List<Item> items;
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, 10, interactableLayer);

        if (hit)
        {
            Interactable interactable = hit.transform.gameObject.GetComponentInParent<Interactable>();

            if (interactable) {
                if(items.Count == 0)
                {
                    interactable.AttemptDialog();
                }
                else
                {
                    foreach (Item item in items)
                    {
                       
                        if (item.ID == interactable.ID)
                        {
                            interactable.AttemptInteract();
                        }
                    }
                }
                
            }
        }
    }
}