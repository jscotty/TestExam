using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{

    [SerializeField] protected ItemTier pItemTier;
    public Items whatItemAmI;

    public virtual GameObject PickMeUp()
    {
        return this.gameObject;
    }

}

public enum Items
{
    ore, ingot,
    log, plank,
    sword, shield, bow
}


public enum ItemTier
{
    Tier1, //resource start
    Tier2, //resource after conver
    Tier3  //finished item
}