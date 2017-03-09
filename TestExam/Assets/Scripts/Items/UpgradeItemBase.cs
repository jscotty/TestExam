using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeItemBase : MonoBehaviour {

	[SerializeField] protected float timeForIngotToBeReady;
    [SerializeField] protected GameObject handoutReadyIcon;
    [SerializeField] protected GameObject objecToHandOut;

    public virtual void StartTimeTillhandout()
    {
        StartCoroutine("TimeTillhandout");
    }

    protected virtual IEnumerator TimeTillhandout()
    {
        yield return new WaitForSeconds(timeForIngotToBeReady);
        HandoutReady();
    }

    protected virtual void HandoutReady()
    {
        handoutReadyIcon.SetActive(true);
    }

    protected virtual GameObject CollectHandout()
    {
        handoutReadyIcon.SetActive(false);
        return Instantiate(objecToHandOut);
    }
}
