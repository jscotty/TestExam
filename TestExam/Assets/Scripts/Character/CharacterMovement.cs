//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : Character {

	[SerializeField] private float _speed = 2.0f;

	private XboxControllerManager _xboxControllerManager;

	void Start(){
		_xboxControllerManager = XboxControllerManager.Instance;
	}

	void FixedUpdate(){
		float tSpeed = Time.deltaTime * _speed;
		Vector3 tDirection = _xboxControllerManager.GetLeftStickAxis(base.pPlayerInformation) *tSpeed;

		Vector3 tCurrentPosition = transform.position;
		tCurrentPosition += tDirection;
		transform.position = tCurrentPosition;

		if(tDirection.magnitude != 0)
			transform.forward = Vector3.Normalize(tDirection);
	}
}
