//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class DestroyWhenFinished : MonoBehaviour {

	private ParticleSystem _particleSystem;

	void Start () {
		_particleSystem = GetComponent<ParticleSystem>();
	}

	void Update(){
		if(!_particleSystem.IsAlive()){
			Destroy(this.gameObject);
		}
	}
}
