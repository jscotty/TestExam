//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class XboxControllerManager : Singleton<XboxControllerManager> , IController
{

	/// <summary>
	/// Vibrate the specified controller of PlayerIndex
	/// </summary>
	/// <param name="iPlayerIndex">player index.</param>
	/// <param name="iLeftPower">left vibration power.</param>
	/// <param name="iRightPower">Right vibration power.</param>
	public void Vibrate (PlayerInformation iPlayerInformation, float iLeftPower, float iRightPower)
	{
		GamePad.SetVibration (iPlayerInformation.PlayerIndex, iLeftPower, iRightPower);
	}

	/// <summary>
	/// Gets the left stick axis.
	/// </summary>
	/// <returns>The left stick axis.</returns>
	/// <param name="iPlayerInformation">player information.</param>
	public Vector3 GetLeftStickAxis (PlayerInformation iPlayerInformation)
	{
		float tHorizontalInput = iPlayerInformation.PlayerState.ThumbSticks.Left.X;
		float tVerticalInput = iPlayerInformation.PlayerState.ThumbSticks.Left.Y;
		return new Vector3 (tHorizontalInput, 0, tVerticalInput);
	}

	/// <summary>
	/// Gets the left stick interaction.
	/// </summary>
	/// <returns><c>true</c>, if left stick interaction was gotten, <c>false</c> otherwise.</returns>
	/// <param name="iPlayerInformation">player information.</param>
	public bool GetLeftStickInteraction (PlayerInformation iPlayerInformation)
	{
		float tHorizontalInput = iPlayerInformation.PlayerState.ThumbSticks.Left.X;
		float tVerticalInput = iPlayerInformation.PlayerState.ThumbSticks.Left.Y;
		if (tHorizontalInput != 0 && tVerticalInput != 0)
			return true;

		return false;
	}

	/// <summary>
	/// Gets the button pressed.
	/// </summary>
	/// <returns><c>true</c>, if button pressed was gotten, <c>false</c> otherwise.</returns>
	/// <param name="iPlayerInformation">player information.</param>
	/// <param name="iButton">button.</param>
	public bool GetButtonPressed (PlayerInformation iPlayerInformation, ButtonType iButton)
	{
		switch (iButton) {

		case ButtonType.BUTTON_A:
			return iPlayerInformation.PlayerState.Buttons.A.Equals (ButtonState.Pressed);
		case ButtonType.BUTTON_B:
			return iPlayerInformation.PlayerState.Buttons.B.Equals (ButtonState.Pressed);
		case ButtonType.BUTTON_X:
			return iPlayerInformation.PlayerState.Buttons.X.Equals (ButtonState.Pressed);
		case ButtonType.BUTTON_Y:
                return iPlayerInformation.PlayerState.Buttons.Y.Equals(ButtonState.Pressed);
		case ButtonType.BUTTON_START:
			return iPlayerInformation.PlayerState.Buttons.Start.Equals (ButtonState.Pressed);
		case ButtonType.BUTTON_SELECT:
			return iPlayerInformation.PlayerState.Buttons.Guide.Equals (ButtonState.Pressed);
		case ButtonType.BUTTON_LB:
			return iPlayerInformation.PlayerState.Buttons.LeftShoulder.Equals (ButtonState.Pressed);
		case ButtonType.BUTTON_RB:
			return iPlayerInformation.PlayerState.Buttons.RightShoulder.Equals (ButtonState.Pressed);
		}

		return false;
	}
}