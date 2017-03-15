using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour, IInteract
{

    public Items whatItemAmI;
    public ItemTiers WhatItemTierAmI;

    public virtual GameObject PickMeUp()
    {
        return this.gameObject;
    }

    public void Interact(CharacterItemController iItemController)
    {
        iItemController.PickItemUp(this);
    }

}

public enum Items
{
    ORE, INGOT, //resource start
    LOG, PLANK, //resource after convert
    SWORD, SHIELD, BOW //finished item
}

public enum ItemTiers
{
    TIER1,
    TIER2,
    TIER3
}