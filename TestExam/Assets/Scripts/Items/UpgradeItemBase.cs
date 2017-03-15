using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeItemBase : MonoBehaviour, IInteract
{

    [SerializeField]
    protected float pTimeForItemToBeReady;
    
    
    [SerializeField]
    protected GameObject pObjecToHandOut;
    protected bool pIsCoroutineRunning = false;

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
        
        return Instantiate(pObjecToHandOut);
    }

    public virtual void Interact(CharacterItemController iItemController)
    {

    }
}
