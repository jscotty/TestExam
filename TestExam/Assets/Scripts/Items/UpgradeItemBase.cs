using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeItemBase : MonoBehaviour {

	[SerializeField] protected float pTimeForIngotToBeReady;
    [SerializeField] protected GameObject pHandoutReadyIcon;
    [SerializeField] protected GameObject pObjecToHandOut;
    protected bool pIsCoroutineRunning = false;

    public virtual void PutItemIn(ItemBase iItemType)
    {

    }

    public virtual void StartTimeTillhandout()
    {
        if (!pIsCoroutineRunning)
        {
            StartCoroutine("TimeTillhandout");
            pIsCoroutineRunning = true;
        }

    }

    protected virtual IEnumerator TimeTillhandout()
    {
        yield return new WaitForSeconds(pTimeForIngotToBeReady);
        HandoutReady();
        pIsCoroutineRunning = false;
    }

    protected virtual void HandoutReady()
    {
        pHandoutReadyIcon.SetActive(true);
    }

    protected virtual GameObject CollectHandout()
    {
        pHandoutReadyIcon.SetActive(false);
        return Instantiate(pObjecToHandOut);
    }
}
