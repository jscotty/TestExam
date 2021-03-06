﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeItemBase : MonoBehaviour, IInteract
{

    [SerializeField]
    protected float pTimeForItemToBeReady;
    
    
    [SerializeField]
    protected GameObject pObjecToHandOut;
    protected bool pIsCoroutineRunning = false;

    protected ParticleManager pParticleManager;

    void Start()
    {
        pParticleManager = ParticleManager.Instance;
    }

    public virtual void PutItemIn(ItemBase iItemType, CharacterItemController iPlayerInfo)
    {

    }

    public virtual void StartTimeTillhandout()
    {
        if (!pIsCoroutineRunning)
        {
            StartCoroutine(TimeTillhandout());
            pIsCoroutineRunning = true;
        }

    }

    protected virtual IEnumerator TimeTillhandout()
    {
        yield return new WaitForSeconds(pTimeForItemToBeReady);
        HandoutReady();
        pIsCoroutineRunning = false;
    }

    protected virtual void HandoutReady()
    {
        
    }

    public virtual GameObject CollectHandout()
    {
        pParticleManager.SpawnParticle(ParticleType.OBJECT_CREATED, transform.position, true);
        return Instantiate(pObjecToHandOut,transform.position,Quaternion.identity);
    }

    public virtual void Interact(CharacterItemController iItemController)
    {

    }
}
