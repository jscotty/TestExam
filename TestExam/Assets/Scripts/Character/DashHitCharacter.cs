//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashHitCharacter : Character {

    [SerializeField]
    private float _stunTime = 2.0f;

    private float _playerHeight = 2.0f;

    private float _time = 0.0f;
    private ParticleManager _particleManager;

    void Start() {
        _particleManager = ParticleManager.Instance;
    }

    void OnDashHit(float iImpulse) {
        if (pIsStunned)
            return;
        pIsStunned = true;
        StartCoroutine(Stunned());
        
    }

    void Update() {
        if (pIsStunned) {
            Vector3 tParticlePosition = transform.position;
            tParticlePosition.y += _playerHeight;
            _particleManager.SpawnParticle(ParticleType.STUNNED + pPlayerInformation.PlayerID, tParticlePosition);
        }
    }

    IEnumerator Stunned() {
        Character[] tCharacters = GetComponentsInChildren<Character>();
        Debug.Log(tCharacters.Length);
        for (int i = 0; i < tCharacters.Length; i++)
        {
            tCharacters[i].Stun(true);
        }
        yield return new WaitForSeconds(_stunTime);
        pIsStunned = false;

        for (int i = 0; i < tCharacters.Length; i++)
        {
            tCharacters[i].Stun(false);
        }
    }
}
