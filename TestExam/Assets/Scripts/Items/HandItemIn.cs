using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandItemIn : MonoBehaviour , IInteract{


    [SerializeField]
    private ItemsToBuild _itemsToBuild;

    public void Interact(CharacterItemController iItemController)
    {
        if (_itemsToBuild.CanHandInItem(iItemController.itemIAmHolding.whatItemAmI))
        {
            Destroy(iItemController.itemIAmHolding.gameObject);
            iItemController.RemoveItem();
        }
    }
}
