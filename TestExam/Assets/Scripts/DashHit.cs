//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashHit : MonoBehaviour {

	[SerializeField] private GameObject hitParticle;
	void OnDashHit(Vector3 iHitPosition){
		GameObject tHit = hitParticle;
		tHit.transform.position = iHitPosition;
		Instantiate(hitParticle);
	}
}
