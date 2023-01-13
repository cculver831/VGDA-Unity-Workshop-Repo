using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public enum ItemType
{
    Key,
    Weapon,
    Misc,
}
public class Interactable : MonoBehaviour
{

    public bool needsItem = true;
    public int ItemID;
    public ItemType Item;
    //[ConditionalField("Needs Item")] 

    public ItemType GetItemType()
    {
        return Item;
    }

    public int GetItemID()
    {
        return ItemID;
    }

    public virtual void AttemptInteract()
    {

    }

    public virtual void AttemptDialog()
    {

    }
}
