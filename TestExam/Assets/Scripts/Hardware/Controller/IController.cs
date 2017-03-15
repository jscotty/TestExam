//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController
{

	void Vibrate (PlayerInformation iPlayerInformation, float iLeftPower, float iRightPower);

	Vector3 GetLeftStickAxis (PlayerInformation iPlayerInformation);

	bool GetLeftStickInteraction (PlayerInformation iPlayerInformation);

	bool GetButtonPressed (PlayerInformation iPlayerInformation, ButtonType iButton);
}

/// <summary>
/// Button type used for Button references.
/// </summary>
public enum ButtonType
{
	BUTTON_A,
	BUTTON_B,
	BUTTON_X,
	BUTTON_Y
}
