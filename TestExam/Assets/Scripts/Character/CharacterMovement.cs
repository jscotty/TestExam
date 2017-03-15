//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : Character {

	[SerializeField] private float _speed = 200.0f;
	[SerializeField] private float _dashSpeed = 250.0f;
	[SerializeField] private float _dashCooldownInSeconds = 2.0f;
	[SerializeField] private float _dashLengthSeconds = 1.0f;
	[SerializeField] private ButtonType _dashButton;

	private float _dashCooldown = 0.0f;
	private float _dashCount = 0.0f;
	private bool _isDashCooldown = false;
	private bool _isDashing = false;

	private ParticleManager _particleManager;
	private Rigidbody _rigidbody;
	private XboxControllerManager _xboxControllerManager;

	void Start(){
		_xboxControllerManager = XboxControllerManager.Instance;
		_rigidbody = GetComponent<Rigidbody>();

		_particleManager = ParticleManager.Instance;
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

		_rigidbody.velocity = tDirection;

		if(tDirection.sqrMagnitude > 0.0f)
			transform.forward = Vector3.Normalize(tDirection);
	}

	private Vector3 Dash(Vector3 iDirection){
		_particleManager.SpawnParticleAssignedToObject(ParticleType.DASH+pPlayerInformation.PlayerID,this.transform);
		//Dash behaviour
		_dashCount+=Time.deltaTime;
		if(_dashCount>= _dashLengthSeconds){
			_dashCount = 0.0f;
			_isDashing = false;
			_isDashCooldown = true;
        }

        float tSpeed = Time.deltaTime * _dashSpeed;
        iDirection = transform.forward* tSpeed;
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
		Debug.Log(iCollision.impulse.magnitude);

		Vector3 tHitPosition = transform.position+(transform.forward);

        if (iCollision.impulse.magnitude > 4000)
			iCollision.gameObject.SendMessage("OnHit", tHitPosition, SendMessageOptions.DontRequireReceiver);
		if(!_isDashing)
			return;
		_isDashing = false;
		iCollision.gameObject.SendMessage("OnDashHit", tHitPosition, SendMessageOptions.DontRequireReceiver);
	}

    void OnCollisionStay(Collision iCollision) {
        Debug.Log("collision stayed!" + iCollision.gameObject.name);
    }
}
