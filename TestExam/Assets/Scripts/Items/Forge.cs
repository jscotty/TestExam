using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forge : UpgradeItemBase
{
    public Items requestedItem;

    public override void PutItemIn(ItemBase iInputItem)
    {
        if (iInputItem.whatItemAmI == requestedItem && pIsCoroutineRunning)
        {
            StartTimeTillhandout();
            Destroy(iInputItem);
        }
    }
}
