using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItemController : Character {

    public bool amIHoldingAnItem = false;
    public ItemBase itemIAmHolding;
	[SerializeField] private ButtonType _interactButton;
    private int _buttonPressedCounter = 0;
    [SerializeField]
    private Transform topOfCapsule;
    [SerializeField]
    private Transform bottomOfCapsule;
    //public Transform holdItemPosition;


    public void PickItemUp(ItemBase iItem)
    {
        //TODO make a functionality to hold the item
        Debug.Log("Pick item up");
        itemIAmHolding = iItem;
#if UNITY_EDITOR
        Debug.Log(iItem);
#endif
        itemIAmHolding.transform.position = transform.position;
        itemIAmHolding.transform.parent = this.transform;
        Rigidbody tRigidbody =  itemIAmHolding.GetComponent<Rigidbody>();
        tRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        amIHoldingAnItem = true;
    }

    public void RemoveItem()
    {
        Debug.Log("Remove item");
        //TODO remove the item from the player but not drop it (the item is used)
        itemIAmHolding = null;
        amIHoldingAnItem = false;
    }

    public void DropItem()
    {
        Debug.Log("Drop item");
        //TODO add functionality to drop the item
        if (itemIAmHolding == null)
        {
            return;
        }
        itemIAmHolding.transform.parent = null;
        itemIAmHolding.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        itemIAmHolding = null;
        amIHoldingAnItem = false;
    }

    void Update()
    {
        if (pXboxControllerManager == null)
        {
            pXboxControllerManager = XboxControllerManager.Instance;
        }
        if (_buttonPressedCounter == 0 && base.pXboxControllerManager.GetButtonPressed(base.pPlayerInformation, _interactButton))
        {
            IInteract tInteractable = null;
            Collider[] tOverlapcapsulehits = Physics.OverlapCapsule(topOfCapsule.position, bottomOfCapsule.position, 0.5f);
            for (int i = 0; i < tOverlapcapsulehits.Length; i++)
            {
                tInteractable = tOverlapcapsulehits[i].GetComponent<IInteract>();
                if (tInteractable != null && tInteractable != itemIAmHolding)
                {
#if UNITY_EDITOR
                    Debug.Log(tInteractable);
#endif
                    if (tInteractable.GetType() == typeof(ItemBase) && amIHoldingAnItem)
                    {
                        tInteractable = null;
                        continue;
                    }
                    tInteractable.Interact(this);
                    break;
                }
            }
            if (tInteractable == null && amIHoldingAnItem)
            {
                DropItem();
            }
            _buttonPressedCounter++;
        }
        else if (base.pXboxControllerManager.GetButtonPressed(base.pPlayerInformation, _interactButton))
        {
            _buttonPressedCounter++;
        }
        else
        {
            _buttonPressedCounter = 0;
        }
    }

    public void GetInteractibleItem(IInteract iItem)
    {
        Debug.Log(iItem.ToString());
        iItem.Interact(this);
    }

}
