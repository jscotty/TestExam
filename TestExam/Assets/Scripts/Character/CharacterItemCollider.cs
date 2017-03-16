using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterItemCollider : MonoBehaviour
{
    public bool sendInteractableCollider = false;

    public delegate void SendInterActibleItem(IInteract iInteract);
    public SendInterActibleItem SendInteractibleItem;
    [SerializeField]private Transform topOfCapsule;
    [SerializeField]private Transform bottomOfCapsule;

    void OnTriggerStay(Collider other)
    {
        if (sendInteractableCollider)
        {
            Collider[] tOverlapcapsulehits = Physics.OverlapCapsule(topOfCapsule.position,bottomOfCapsule.position,0.5f);
            for (int i = 0; i < tOverlapcapsulehits.Length; i++)
            {
                Debug.Log(tOverlapcapsulehits.ToString());
            }
            if (SendInteractibleItem != null && other.GetComponent<IInteract>() != null)
            {
                SendInteractibleItem(other.GetComponent<IInteract>());
            }
            sendInteractableCollider = false;
        }
    }

}
