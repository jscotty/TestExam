//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : Character {

	[SerializeField] private float _speed = 2.0f;
	[SerializeField] private float _dashSpeedMultiplier = 2.0f;
	[SerializeField] private float _dashCooldownInSeconds = 2.0f;
	[SerializeField] private float _dashLengthSeconds = 1.0f;
	[SerializeField] private ButtonType _dashButton;

	private float _dashCooldown = 0.0f;
	private float _dashCount = 0.0f;
	private bool _isDashCooldown = false;
	private bool _isDashing = false;

	private ParticleSystem _particleSystem;

	private XboxControllerManager _xboxControllerManager;

	void Start(){
		_xboxControllerManager = XboxControllerManager.Instance;


		_particleSystem = GetComponentInChildren<ParticleSystem>();
		_particleSystem.Stop();
	}

	#region Update
	void FixedUpdate(){
		float tSpeed = Time.deltaTime * _speed;
		Vector3 tDirection = _xboxControllerManager.GetLeftStickAxis(base.pPlayerInformation) *tSpeed;

		if(_xboxControllerManager.GetButtonPressed(base.pPlayerInformation,_dashButton) && !_isDashCooldown && !_isDashing){
			_isDashing = true;
		}
		if(_isDashing)
			tDirection = Dash(tDirection);

		Vector3 tCurrentPosition = transform.position;
		tCurrentPosition += tDirection;
		transform.position = tCurrentPosition;

		if(tDirection.sqrMagnitude > 0.0f)
			transform.forward = Vector3.Normalize(tDirection);
	}

	private Vector3 Dash(Vector3 iDirection){
		//Dash behaviour
		_particleSystem.Play();
		_dashCount+=Time.deltaTime;
		if(_dashCount>= _dashLengthSeconds){
			_dashCount = 0.0f;
			_isDashing = false;
			_isDashCooldown = true;
			_particleSystem.Stop();
		}
		iDirection += transform.forward*_dashSpeedMultiplier;
		return iDirection;
	}

	void Update(){
		if(_isDashCooldown){
			_dashCooldown+=Time.deltaTime;
			if(_dashCooldown>= _dashCooldownInSeconds){
				_dashCooldown = 0.0f;
				_isDashCooldown = false;
			}
		}
	}
	#endregion

	void OnCollisionEnter(Collision iCollision){
		if(!_isDashing)
			return;
		_isDashing = false;

		Vector3 tHitPosition = transform.position+(transform.forward*0.5f);
		Vector3 tRotation = transform.localEulerAngles;

		iCollision.gameObject.SendMessage("OnDashHit", tHitPosition, SendMessageOptions.DontRequireReceiver);
	}
}
