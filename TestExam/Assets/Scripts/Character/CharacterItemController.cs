using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItemController : Character {

    public bool amIHoldingAnItem = false;
    public ItemBase itemIAmHolding;
    public Transform holdItemPosition;
    
    public void PickItemUp(ItemBase iItem)
    {
        //TODO make a functionality to hold the item
        Debug.Log("Pick item up");
        itemIAmHolding = iItem;
        itemIAmHolding.transform.position = holdItemPosition.position;
        itemIAmHolding.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void RemoveItem()
    {
        Debug.Log("Remove item");
        //TODO remove the item from the player but not drop it (the item is used)
        itemIAmHolding = null;
    }

    public void DropItem()
    {
        Debug.Log("Drop item");
        //TODO add functionality to drop the item
        itemIAmHolding.transform.parent = null;
        itemIAmHolding.GetComponent<Rigidbody>().isKinematic = true;
        itemIAmHolding = null;
    }
}
