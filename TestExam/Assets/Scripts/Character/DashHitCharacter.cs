//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashHitCharacter : Character {

    [SerializeField]
    private float _stunTime = 2.0f;
    [SerializeField]
    private AudioClip _dashHitClip;

    private float _playerHeight = 2.0f;

    private float _time = 0.0f;
    private ParticleManager _particleManager;
    private SoundController _soundController;

    void Start() {
        _particleManager = ParticleManager.Instance;
        _soundController = SoundController.Instance;
    }

    void OnDashHit(float iImpulse) {
        if (pIsStunned)
            return;
        pIsStunned = true;
        if (_dashHitClip != null)
            _soundController.PlaySound(_dashHitClip, false);
        StartCoroutine(Stunned());
        
    }

    void Update() {
        Stun();
        if (pIsStunned) {
            Vector3 tParticlePosition = transform.position;
            tParticlePosition.y += _playerHeight;
            _particleManager.SpawnParticle(ParticleType.STUNNED + pPlayerInformation.PlayerID, tParticlePosition);
        }
    }

    void Stun()
    {
        Character[] tCharacters = GetComponentsInChildren<Character>();
        for (int i = 0; i < tCharacters.Length; i++)
        {
            tCharacters[i].Stun(pIsStunned);
        }
    }

    IEnumerator Stunned() {
        yield return new WaitForSeconds(_stunTime);
        pIsStunned = false;
    }
}
