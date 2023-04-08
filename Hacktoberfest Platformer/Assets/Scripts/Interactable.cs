using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Photon.Pun;



public enum ItemType
{
    Key = 0,
    Weapon = 1,
    Misc = 2,
}
public class Interactable : MonoBehaviourPun
{

    public bool needsItem = true;
    public int ID;
    public ItemType Item;
    protected bool hasInteracted = false;

    public ItemType GetItemType()
    {
        return Item;
    }

    public virtual void AttemptInteract() { }

    public virtual void AttemptDialog(int photonID) {


    }
    
}
