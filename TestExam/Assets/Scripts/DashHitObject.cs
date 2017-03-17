//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashHitObject : MonoBehaviour {

    [SerializeField]
    private AudioClip _dashHitClip;
    private SoundController _soundController;

    void Start()
    {
        _soundController = SoundController.Instance;
    }
    void OnHit(Vector3 iHitPosition)
    {
		ParticleManager tParticles = ParticleManager.Instance;
		tParticles.SpawnParticle(ParticleType.DASH_HIT_WALL,iHitPosition,true);

        if (_dashHitClip != null)
            _soundController.PlaySound(_dashHitClip, false);
	}
}
