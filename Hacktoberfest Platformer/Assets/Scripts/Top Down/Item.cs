using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    AudioSource source;
    public ItemType type = ItemType.Key;
    public int ID;

    ///-///////////////////////////////////////////////////////////
    /// When player touches item, add to inventory
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player") return;
 
        Inventory inventory = collision.GetComponent<Inventory>();

        if (inventory)
        {
            if(source != null)
            {
                source.Play();
            }

            inventory.AddItem(this);

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
      
    }
}
