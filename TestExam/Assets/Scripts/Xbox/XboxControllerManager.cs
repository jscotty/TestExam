//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Exam.References.Names.ControllerInput;
using XInputDotNetPure;

public class XboxControllerManager : Singleton<XboxControllerManager> {

	private const float _SENSITIVITY = 0.5f;

	/// <summary>
	/// Vibrate the specified controller of PlayerIndex
	/// </summary>
	/// <param name="iPlayerIndex">player index.</param>
	/// <param name="iLeftPower">left vibration power.</param>
	/// <param name="iRightPower">Right vibration power.</param>
	public void Vibrate(PlayerIndex iPlayerIndex, float iLeftPower, float iRightPower){
		GamePad.SetVibration(iPlayerIndex,iLeftPower,iRightPower);
	}

	/// <summary>
	/// Gets the left stick axis.
	/// </summary>
	/// <returns>The left stick axis.</returns>
	/// <param name="iPlayerInformation">player information.</param>
	public Vector3 GetLeftStickAxis(PlayerInformation iPlayerInformation){
		float tHorizontalInput = iPlayerInformation.PlayerState.ThumbSticks.Left.X;
		float tVerticalInput = iPlayerInformation.PlayerState.ThumbSticks.Left.Y;
		return new Vector3(tHorizontalInput,0,tVerticalInput);
	}

	/// <summary>
	/// Gets the left stick interaction.
	/// </summary>
	/// <returns><c>true</c>, if left stick interaction was gotten, <c>false</c> otherwise.</returns>
	/// <param name="iPlayerInformation">player information.</param>
	public bool GetLeftStickInteraction(PlayerInformation iPlayerInformation){
		float tHorizontalInput = iPlayerInformation.PlayerState.ThumbSticks.Left.X;
		float tVerticalInput = iPlayerInformation.PlayerState.ThumbSticks.Left.Y;
		if(tHorizontalInput!=0 &&tVerticalInput!=0) return true;
		return false;
	}
}