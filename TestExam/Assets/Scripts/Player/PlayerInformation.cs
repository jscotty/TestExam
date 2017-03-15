//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using UnityEngine;
using System.Collections.Generic;
using XInputDotNetPure;
using Exam.Reference.Path;

public class PlayerInformation {

    /// <summary>
    /// Stored character path references, which can be collected by a character type enumaration
    /// </summary>
    private Dictionary<CharacterType, string> _characterReference = new Dictionary<CharacterType, string>() {
        { CharacterType.CUBE, CharacterPaths.CHARACTER }
    };

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
			switch (this.PlayerIndex) { // no need to break because of returns
			case PlayerIndex.One:
				return 0;
			case PlayerIndex.Two:
				return 1;
			case PlayerIndex.Three:
				return 2;
			case PlayerIndex.Four:
				return 3;
			default:
				return 0;
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

	public PlayerInformation Init(PlayerIndex iPlayerIndex, CharacterType iCharacterType = CharacterType.CUBE){
		this.PlayerIndex = iPlayerIndex;
        this.SelectedCharacterPath = _characterReference[iCharacterType];
		return this;
	}
}


