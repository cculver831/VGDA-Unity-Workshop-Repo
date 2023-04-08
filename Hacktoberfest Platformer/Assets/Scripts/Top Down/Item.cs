using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviourPun
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
        PhotonView pv = collision.GetComponent<PhotonView>();

        Inventory inventory = pv.GetComponent<Inventory>();

        if (inventory)
        {
            if(source != null)
            {
                source.Play();
            }

            inventory.AddItem(this);

            photonView.GetComponent<SpriteRenderer>().enabled = false;
            photonView.GetComponent<Collider2D>().enabled = false;
        }
      
    }
}
