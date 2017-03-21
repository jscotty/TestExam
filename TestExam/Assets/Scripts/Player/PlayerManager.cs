//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PlayerManager : Singleton<PlayerManager>
{

    private List<PlayerInformation> _players = new List<PlayerInformation>();

    public List<PlayerInformation> Players // listed players
    {
        get
        {
            return _players;
        }
    }

    private bool _alreadyInitialized = false; // check if initialized

    public PlayerManager Init() // manual initialization
    {
        _alreadyInitialized = true;
        UpdatePlayerList();
        return this;
    }

    void Start()
    {
        if (_alreadyInitialized) return; // if not initialized initialize!
        for (int i = 0; i < 4; i++)
        {
            PlayerIndex tPlayerIndex = (PlayerIndex)i;
            GamePadState tPlayerState = GamePad.GetState(tPlayerIndex);
            if (tPlayerState.IsConnected)
            {
                PlayerInformation tPlayerInformation = new PlayerInformation().Init(tPlayerIndex);
                _players.Add(new PlayerInformation().Init(tPlayerIndex));
            }
        }
    }

    /// <summary>
    /// Updates the player list by checking if player already excists.
    /// </summary>
    public void UpdatePlayerList()
    {
        for (int i = 0; i < 4; i++)
        {
            PlayerIndex tPlayerIndex = (PlayerIndex)i;
            GamePadState tPlayerState = GamePad.GetState(tPlayerIndex);
            if (tPlayerState.IsConnected)
            {
                if (!IsPlayerIndexListed(tPlayerIndex))
                    _players.Add(new PlayerInformation().Init(tPlayerIndex));
            }
        }
    }

    /// <summary>
    /// Check if player index is already listed.
    /// </summary>
    /// <returns><c>true</c> if this instance is player index listed the specified iPlayerIndex; otherwise, <c>false</c>.</returns>
    /// <param name="iPlayerIndex">player index.</param>
    private bool IsPlayerIndexListed(PlayerIndex iPlayerIndex)
    {
        for (int i = 0; i < _players.Count; i++)
        {
            if (iPlayerIndex.Equals(_players[i].PlayerIndex)) return true;
        }
        return false;
    }
}
