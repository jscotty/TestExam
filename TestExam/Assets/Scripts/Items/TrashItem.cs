using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItem : MonoBehaviour ,IInteract {

    public void Interact(CharacterItemController iItemController)
    {
        ParticleManager.Instance.SpawnParticle(ParticleType.OBJECT_VANISHED, iItemController.itemIAmHolding.transform.position, true);
        Destroy(iItemController.itemIAmHolding.gameObject);
        iItemController.RemoveItem();
    }
}
