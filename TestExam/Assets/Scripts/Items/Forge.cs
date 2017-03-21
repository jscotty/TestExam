using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forge : UpgradeItemBase
{

    [SerializeField]
    private GameObject _handoutReadyIcon;
    public Items requestedItem;

    public override void PutItemIn(ItemBase iInputItem, CharacterItemController iCharacterItemController)
    {
        if (iInputItem.whatItemAmI == requestedItem && !pIsCoroutineRunning)
        {
            StartTimeTillhandout();
            iCharacterItemController.RemoveItem();
            Destroy(iInputItem.gameObject);
        }
        else
        {
            iCharacterItemController.DropItem();
        }
    }

    public bool IsItemReady()
    {
        return _handoutReadyIcon.activeSelf;
    }

    protected override void HandoutReady()
    {
        base.HandoutReady();
        _handoutReadyIcon.SetActive(true);
    }

    public override GameObject CollectHandout()
    {
        _handoutReadyIcon.SetActive(false);
        return base.CollectHandout();
    }

    public override void Interact(CharacterItemController iItemController)
    {
        base.Interact(iItemController);
        if (iItemController.amIHoldingAnItem && _handoutReadyIcon.activeSelf)
        {
            iItemController.DropItem();
        }
        else if (!iItemController.amIHoldingAnItem && _handoutReadyIcon.activeSelf)
        {
            GameObject tObjectToHAndout = CollectHandout();
            tObjectToHAndout.GetComponentInChildren<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            ItemBase tItembase = tObjectToHAndout.GetComponentInChildren<ItemBase>();
            iItemController.PickItemUp(tItembase);
        }
        else if (iItemController.amIHoldingAnItem && !_handoutReadyIcon.activeSelf && !pIsCoroutineRunning)
        {
            PutItemIn(iItemController.itemIAmHolding, iItemController);
        }
        else
        {
            iItemController.DropItem();
        }
    }

}
