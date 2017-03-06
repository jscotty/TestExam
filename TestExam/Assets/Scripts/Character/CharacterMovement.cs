//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	[SerializeField] private float _speed = 2.0f;
	[SerializeField] private float _jumpSpeed = 200.0f;
	[SerializeField] private ButtonType _jumpKey;

	private Rigidbody _body;
	private XboxControllerManager _xboxControllerManager;
	private float _distanceToGround = 0f;

	void Start(){
		_xboxControllerManager = XboxControllerManager.Instance;
		_body = GetComponent<Rigidbody>();
	}

	void FixedUpdate(){
		bool tInteraction = _xboxControllerManager.GetLeftStickInteraction(0);
		if(!tInteraction) return;

		float tSpeed = Time.deltaTime * _speed;
		Vector3 tDirection = _xboxControllerManager.GetLeftStickAxis(0) *tSpeed;

		Vector3 tCurrentPosition = transform.position;
		tCurrentPosition += tDirection;
		transform.position = tCurrentPosition;

		Vector3 desiredVelocity = _body.velocity;
		if(_xboxControllerManager.GetButton(0,_jumpKey) && IsGrounded()){
			desiredVelocity.y = _jumpSpeed;
			_body.velocity = desiredVelocity;
		}

		transform.forward = Vector3.Normalize(tDirection);
	}

	private bool IsGrounded(){
		return Physics.Raycast(transform.position, Vector3.down, _distanceToGround + 0.1f);
	}
}
