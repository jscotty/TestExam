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
            //TODO start craft animation
        }
    }
}
