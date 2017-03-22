using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBaseResource : MonoBehaviour , IInteract {

    public GameObject itemToSpawn;

    public void Interact(CharacterItemController iCharacterController)
    {
        if (!iCharacterController.amIHoldingAnItem)
        {
            iCharacterController.PickItemUp(Instantiate(itemToSpawn).GetComponentInChildren<ItemBase>()); 
        }
    }
}
