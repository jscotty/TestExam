using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodWorking : UpgradeItemBase
{

    public Items requestedItem;


    public override void PutItemIn(ItemBase iItemType, CharacterItemController iPlayerInfo)
    {
        base.PutItemIn(iItemType, iPlayerInfo);
        if (iItemType.whatItemAmI == requestedItem)
        {
            Destroy(iItemType.gameObject);
            iPlayerInfo.RemoveItem();
            GameObject tItem = CollectHandout();
            iPlayerInfo.PickItemUp(tItem.GetComponentInChildren<ItemBase>());
        }
    }

    public override void Interact(CharacterItemController iItemController)
    {
        base.Interact(iItemController);
        PutItemIn(iItemController.itemIAmHolding, iItemController);
    }
}
