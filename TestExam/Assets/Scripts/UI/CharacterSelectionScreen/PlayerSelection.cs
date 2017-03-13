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

    private void Start() {
        for (int i = 0; i < _connectedPlayer.Capacity; i++) {
            _connectedPlayer.Add(false);
        }
    }

    public void ConnectPlayer(int iConnectedPlayer) {
        _connectedPlayer[iConnectedPlayer] = true;
        _playerImages[iConnectedPlayer].color = Color.white;
        _joinText[iConnectedPlayer].SetActive(false);
    }

    public void DisconnectPlayer(int iDisconnectedPlayer) {
        _connectedPlayer[iDisconnectedPlayer] = false;
        _playerImages[iDisconnectedPlayer].color = Color.gray;
        _joinText[iDisconnectedPlayer].SetActive(true);
    }
}
