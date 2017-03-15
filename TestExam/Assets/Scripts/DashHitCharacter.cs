//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashHitCharacter : Character {

    void OnDashHit(float iImpulse) {
        if (iImpulse > 15000) {
            Debug.Log("Stun!");
            pIsStunned = true;
        }
    }
}
