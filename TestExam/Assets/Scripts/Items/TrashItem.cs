using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItem : MonoBehaviour ,IInteract {

    public void Interact(CharacterItemController iItemController)
    {
        Destroy(iItemController.itemIAmHolding.gameObject);
        iItemController.RemoveItem();
    }
}
