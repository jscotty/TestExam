//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Exam.Reference.Path;

public class ParticleManager : Singleton<ParticleManager> {

	private Dictionary<ParticleType, ParticleInformation> _particleReference = new Dictionary<ParticleType, ParticleInformation>();
	private int[] _ticks;

	/// <summary>
	/// Initialization
	/// </summary>
	private void Start(){
		string[] tParticlePaths = ParticlePaths.PARTICLES;
		Debug.Log("initialize");
		for (int i = 0; i < tParticlePaths.Length; i++) {
			GameObject tParticle = (GameObject)Resources.Load(tParticlePaths[i]);

			if(tParticle==null) Debug.LogError("Could not find Particle prefab of: " + tParticlePaths[i]);
			else{
				Debug.Log("found!" + (ParticleType.DASH+i));
				_particleReference.Add(ParticleType.DASH+i, new ParticleInformation(tParticle));
			}
		}
		_ticks = new int[tParticlePaths.Length];
	}

	void Update(){
		for (int i = 0; i < _particleReference.Count; i++) {
			ParticleInformation tParticleInformation = _particleReference[ParticleType.DASH+i];
			if(_ticks[i] > tParticleInformation.Tick){
				Reset(ParticleType.DASH+i);
				Debug.Log("reset:" + (ParticleType.DASH+i));
				_ticks[i] = 0;
			}
			if(tParticleInformation.Tick!=0)
				_ticks[i]++;
		}
	}

	/// <summary>
	/// Reset the specified particle.
	/// </summary>
	/// <param name="iParticleType">I particle type.</param>
	public void Reset(ParticleType iParticleType){
		_particleReference[iParticleType].Reset();
	}

	#region spawners
	/// <summary>
	/// Spawn particles
	/// </summary>
	/// <param name="iParticleType">In particle type.</param>
	/// <param name="iPosition">In particle position.</param>
	public void SpawnParticle(ParticleType iParticleType, Vector3 iPosition){
		_particleReference[iParticleType].SetParticlePosition(iPosition);
	}

	/// <summary>
	/// Spawn particles
	/// </summary>
	/// <param name="iParticleType">In particle type.</param>
	/// <param name="iPosition">In particle position.</param>
	public void SpawnParticle(ParticleType iParticleType, Vector3 iPosition, Quaternion iRotation){
		_particleReference[iParticleType].SetParticlePosition(iPosition);
	}

	/// <summary>
	/// Spawn particles
	/// </summary>
	/// <param name="iParticleType">In particle type.</param>
	/// <param name="iPosition">In particle position.</param>
	public void SpawnParticle(ParticleType iParticleType, Vector3 iPosition, Vector3 iLocalRotation){
		_particleReference[iParticleType].SetParticlePosition(iPosition);
	}

	/// <summary>
	/// Spawns the particle assigned to object.
	/// </summary>
	/// <param name="iParticleType">I particle type.</param>
	/// <param name="iTransform">I transform.</param>
	public void SpawnParticleAssignedToObject(ParticleType iParticleType, Transform iTransform){
		_particleReference[iParticleType].SetParticleParent(iTransform, iTransform.localRotation.eulerAngles);
	}
	#endregion
}

/// <summary>
/// Particle type stored for reference and readability.
/// </summary>
public enum ParticleType{
	DASH = 0,
	DASH1 = 1,
	DASH2 = 2,
	DASH3 = 3,
	DASH_HIT_WALL = 4,
}