//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Exam.References.Names.ControllerInput;

public class XboxControllerManager : Singleton<XboxControllerManager> {

	private const float _SENSIVITY = 0.5f;

	/// <summary>
	/// Gets the left stick axis.
	/// </summary>
	/// <returns>The left stick axis.</returns>
	/// <param name="playerID">Player I.</param>
	public Vector3 GetLeftStickAxis(int iPlayerID){
		return new Vector3(
			Input.GetAxis(ControllerInput.HORIZONTAL+iPlayerID), //X
			0, //Y
			Input.GetAxis(ControllerInput.VERTICAL+iPlayerID) //Z
		);
	}

	/// <summary>
	/// Gets the left stick interaction.
	/// </summary>
	/// <returns><c>true</c>, if left stick interacted, <c>false</c> otherwise.</returns>
	/// <param name="iPlayerID">player ID.</param>
	public bool GetLeftStickInteraction(int iPlayerID){
		if(Input.GetAxis(ControllerInput.HORIZONTAL+iPlayerID) > _SENSIVITY  || Input.GetAxis(ControllerInput.HORIZONTAL+iPlayerID) < -_SENSIVITY
			|| Input.GetAxis(ControllerInput.VERTICAL+iPlayerID) > _SENSIVITY || Input.GetAxis(ControllerInput.VERTICAL+iPlayerID) < -_SENSIVITY)
			return true;
		return false;
	}

	/// <summary>
	/// Gets the given button state.
	/// </summary>
	/// <returns><c>true</c>, if button was gotten, <c>false</c> otherwise.</returns>
	/// <param name="iPlayerID">Player ID.</param>
	/// <param name="iButton">Button type enum.</param>
	public bool GetButton(int iPlayerID, ButtonType iButton){
		bool tButtonPressed;

		//chech if button is pressed
		float tAxis = Input.GetAxis(GetButtonReference(iButton)+ iPlayerID.ToString());
		if(tAxis  > 0) return true;
		return false;
	}

	/// <summary>
	/// Gets axis reference for the given button type.
	/// </summary>
	/// <returns>Returns button axis reference.</returns>
	/// <param name="iButton">Button type enum.</param>
	private string GetButtonReference(ButtonType iButton){
		switch (iButton) {
		case ButtonType.BUTTON_A:
			return ControllerInput.BUTTON_A;
			break;
		case ButtonType.BUTTON_B:
			return ControllerInput.BUTTON_B;
			break;
		case ButtonType.BUTTON_X:
			return ControllerInput.BUTTON_X;
			break;
		case ButtonType.BUTTON_Y:
			return ControllerInput.BUTTON_Y;
			break;
		}
		return "";
	}
}

/// <summary>
/// Button type.
/// </summary>
public enum ButtonType{
	BUTTON_A,
	BUTTON_B,
	BUTTON_X,
	BUTTON_Y
}