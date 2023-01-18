using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public enum ItemType
{
    Key = 0,
    Weapon = 1,
    Misc = 2,
}
public class Interactable : MonoBehaviour
{

    public bool needsItem = true;
    public int ID;
    public ItemType Item;

    public ItemType GetItemType()
    {
        return Item;
    }

    public virtual void AttemptInteract() { }

    public virtual void AttemptDialog() { }
    
}
