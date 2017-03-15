using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelection : MonoBehaviour {

    [SerializeField]
    private List<Image> _playerImages = new List<Image>();
    private List<bool> _connectedPlayer = new List<bool>(4);
    [SerializeField]
    private List<GameObject> _joinText = new List<GameObject>();
    [SerializeField]
    private GameObject _loadingscreen;

    private void Start() {
        for (int i = 0; i < _connectedPlayer.Capacity; i++) {
            _connectedPlayer.Add(false);
        }
    }

    /// <summary>
    /// Let's the menu know a player has been connected
    /// </summary>
    /// <param name="iConnectedPlayer"></param>
    public void ConnectPlayer(int iConnectedPlayer) {
        _connectedPlayer[iConnectedPlayer] = true;
        _playerImages[iConnectedPlayer].color = Color.white;
        _joinText[iConnectedPlayer].SetActive(false);
    }

    /// <summary>
    /// Let's the menu know a player has disconnected
    /// </summary>
    /// <param name="iDisconnectedPlayer"></param>
    public void DisconnectPlayer(int iDisconnectedPlayer) {
        _connectedPlayer[iDisconnectedPlayer] = false;
        _playerImages[iDisconnectedPlayer].color = Color.gray;
        _joinText[iDisconnectedPlayer].SetActive(true);
    }

    /// <summary>
    /// Checks if all players are connected and spawns a loading screen if they are
    /// </summary>
    public void StartGame() {
        if (!_connectedPlayer.Contains(false)) {
            Instantiate(_loadingscreen);
        }
    }
}
