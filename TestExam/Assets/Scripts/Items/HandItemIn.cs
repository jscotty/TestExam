﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandItemIn : MonoBehaviour , IInteract{


    [SerializeField]
    private ItemsToBuild _itemsToBuild;

    public void Interact(CharacterItemController iItemController)
    {
        if (_itemsToBuild.CanHandInItem(iItemController.itemIAmHolding.whatItemAmI))
        {
            ParticleManager.Instance.SpawnParticle(ParticleType.OBJECT_FINISHED, iItemController.itemIAmHolding.transform.position, true);
            Destroy(iItemController.itemIAmHolding.gameObject);
            iItemController.RemoveItem();
        }
    }
}
