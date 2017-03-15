//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using UnityEngine;
using System.Collections.Generic;
using XInputDotNetPure;

public class PlayerInformation {
	
	/// <summary>
	/// get; private set;
	/// </summary>
	public PlayerIndex PlayerID { get; private set; }

	/// <summary>
	/// Gets the state of the player.
	/// </summary>
	public GamePadState PlayerState{
		get{ return GamePad.GetState(PlayerID); }
	}

	/// <summary>
	/// get; private set;
	/// </summary>
	/// <value>The selected character path.</value>
	public string SelectedCharacterPath{ get; private set; }

	/// <summary>
	/// Gets a value indicating whether this instance is connected.
	/// </summary>
	/// <value><c>true</c> if this instance is connected; otherwise, <c>false</c>.</value>
	public bool IsConnected{
		get{ return PlayerState.IsConnected; }
	}

	public PlayerInformation Init(PlayerIndex iPlayerIndex){
		PlayerID = iPlayerIndex;
		return this;
	}
}


