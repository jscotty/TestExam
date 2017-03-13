//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	protected PlayerInformation pPlayerInformation;

	public Character Init(PlayerInformation iPlayerInformation){
		this.pPlayerInformation = iPlayerInformation;
		return this;
	}

	void Start(){
		
	}
}
