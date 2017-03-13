//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using UnityEngine;
using System.Collections.Generic;
using XInputDotNetPure;

public class PlayerInformation {
	
	/// <summary>
	/// get; private set;
	/// </summary>
	public PlayerIndex PlayerIndex { get; private set; }

	/// <summary>
	/// Get player index int
	/// </summary>
	/// <value>The player I.</value>
	public int PlayerID{
		get{
			switch (this.PlayerIndex) {
			case PlayerIndex.One:
				return 0;
				break;
			case PlayerIndex.Two:
				return 1;
				break;
			case PlayerIndex.Three:
				return 2;
				break;
			case PlayerIndex.Four:
				return 3;
				break;
			default:
				return 0;
				break;
			}
		}
	}

	/// <summary>
	/// Gets the state of the player.
	/// </summary>
	public GamePadState PlayerState{
		get{ return GamePad.GetState(PlayerIndex); }
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
		this.PlayerIndex = iPlayerIndex;
		return this;
	}
}
