//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	protected PlayerInformation pPlayerInformation;
    protected bool pIsStunned = false;

    protected XboxControllerManager pXboxControllerManager;

    public Character Init(PlayerInformation iPlayerInformation)
    {
        this.pPlayerInformation = iPlayerInformation;
        pXboxControllerManager = XboxControllerManager.Instance;
        return this;
    }

    void Start() {
        if(pPlayerInformation.isSaboteur)
            StartCoroutine(Vibrate(0.05f));
    }

    IEnumerator Vibrate(float iSeconds) {
        pXboxControllerManager.Vibrate(pPlayerInformation, 0.3f, 0.5f);
        yield return new WaitForSeconds(iSeconds);
        pXboxControllerManager.Vibrate(pPlayerInformation, 0.0f, 0.0f);
    }

    public void Stun(bool iIsStunned)
    {
        this.pIsStunned = iIsStunned;
    }
}
