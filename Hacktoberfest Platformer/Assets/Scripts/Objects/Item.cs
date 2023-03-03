using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType type = ItemType.Key;
    public int ID;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Inventory inventory = collision.GetComponent<Inventory>();
            if (inventory)
            {
                inventory.AddItem(this);
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Collider2D>().enabled = false;
            }
           
        }
    }
}
