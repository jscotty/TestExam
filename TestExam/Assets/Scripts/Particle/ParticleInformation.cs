﻿//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleInformation {

	public ParticleSystem ParticleSystem { get; private set; }

	public GameObject Particle { get; private set; }

	public int Tick { get; private set; }

    public bool IsDestroyable;

	private Transform _parent;

	/// <summary>
	/// Initializes a new instance of the <see cref="ParticleInformation"/> class.
	/// </summary>
	/// <param name="iParticle">In particle gameobject.</param>
	public ParticleInformation(GameObject iParticle){
		this.Particle = iParticle;
		if(iParticle.GetComponent<ParticleSystem>().Equals(null)){
			Debug.LogError("Particle resource does not contain a particle system!");
			return; // stop constructor
		} 

		this.Particle = GameObject.Instantiate(iParticle);
		this.ParticleSystem = this.Particle.GetComponent<ParticleSystem>();
		Reset();

	}

	#region properties
	/// <summary>
	/// Sets the particle position.
	/// </summary>
	/// <param name="iPosition">In position.</param>
	public void SetParticlePosition(Vector3 iPosition){
		this.Particle.transform.position = iPosition;

        if(!this.ParticleSystem.isPlaying)
		    this.ParticleSystem.Play();
		Tick++;
	}

	/// <summary>
	/// Sets the particle parent and rotation.
	/// </summary>
	/// <param name="iParent">I parent.</param>
	/// <param name="iLocalRotation">I local rotation.</param>
	public void SetParticleParent(Transform iParent, Vector3 iLocalRotation){
		if(iLocalRotation == null)iLocalRotation = this.Particle.transform.localEulerAngles;

		this.Particle.transform.SetParent(iParent);
		this.Particle.transform.position = iParent.position;
		this.Particle.transform.localEulerAngles = iLocalRotation;

		this.ParticleSystem.Play();
		Tick++;
	}

	/// <summary>
	/// Sets the particle parent.
	/// </summary>
	/// <param name="iParent">In parent.</param>
	/// <param name="iLocalRotation">In local rotation.</param>
	public void SetParticleParent(Transform iParent){
			
		this.Particle.transform.SetParent(iParent);
		this.Particle.transform.position = iParent.position;
        this.Particle.transform.localEulerAngles = iParent.localEulerAngles;

		this.ParticleSystem.Play();
		Tick++;
	}



	public void SetColor(Color iColor){
		this.ParticleSystem.startColor = iColor;
	}
	#endregion

	/// <summary>
	/// Reset this instance.
	/// </summary>
	public void Reset(){
        this.Particle.transform.position = new Vector3(999,999,999);
		Tick = 0;
	}

    public void Remove() {
        GameObject.Destroy(this.Particle);
    }
}
