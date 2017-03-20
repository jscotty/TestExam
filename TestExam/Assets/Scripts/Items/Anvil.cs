using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil : UpgradeItemBase {

    public ItemBase itemOne;
    public GameObject bowHandout;
    public GameObject shieldHandout;
    public GameObject swordHandout;

    public GameObject itemOnAnilPosition;
    private bool _isSomeoneInteracting = false;

    public override void PutItemIn(ItemBase iItemType, CharacterItemController iPlayerInfo)
    {
        base.PutItemIn(iItemType, iPlayerInfo);
        if (itemOne == null)
        {
            itemOne = iItemType;
            itemOne.transform.parent = this.transform;
            itemOne.transform.position = itemOnAnilPosition.transform.position;
            itemOne.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            iPlayerInfo.RemoveItem();
        }
        else if (itemOne.WhatItemTierAmI == ItemTiers.TIER2 && iItemType.WhatItemTierAmI == ItemTiers.TIER2)
        {
            Recipe tRecipeToMake = RecipeHolder.Instance.ReturnRecipeFromItem(itemOne, iItemType);
            if (tRecipeToMake!= null)
            {
                _isSomeoneInteracting = true;
                CreateRecipe(tRecipeToMake);
                iPlayerInfo.RemoveItem();
                Destroy(itemOne.gameObject);
                Destroy(iItemType.gameObject);
                ClearAnvilItem();
                ItemBase tItemBase = CollectHandout().GetComponentInChildren<ItemBase>();
#if UNITY_EDITOR
                Debug.Log(tItemBase);
#endif
                iPlayerInfo.PickItemUp(tItemBase);
            }
        }
    }

    public override void Interact(CharacterItemController iItemController)
    {
        if (_isSomeoneInteracting)
        {
            return;
        }
        base.Interact(iItemController);
        if (iItemController.amIHoldingAnItem)
        {
            PutItemIn(iItemController.itemIAmHolding, iItemController);
        }
        else if (itemOne != null)
        {
            iItemController.PickItemUp(itemOne);
            ClearAnvilItem();
        }
    }

    private void CreateRecipe(Recipe iRecipe)
    {
        switch (iRecipe.whatItemWillIBecome)
        {
            case Items.SWORD:
                pObjecToHandOut = swordHandout;
                break;
            case Items.SHIELD:
                pObjecToHandOut = shieldHandout;
                break;
            case Items.BOW:
                pObjecToHandOut = bowHandout;
                break;
        }
    }

    public override GameObject CollectHandout()
    {
        _isSomeoneInteracting = false;
        return base.CollectHandout();
    }

    public void ClearAnvilItem()
    {
        itemOne = null;
    }

}

