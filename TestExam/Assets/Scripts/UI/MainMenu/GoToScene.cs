using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour {

    private XboxControllerManager _xboxController;
    private PlayerManager _playerManager;

    void Start() {
        _xboxController = XboxControllerManager.Instance;
        _playerManager = PlayerManager.Instance;
    }

    void Update() {
        _playerManager.UpdatePlayerList();

        for (int i = 0; i < _playerManager.Players.Count; i++)
        {
            if (_xboxController.GetButtonPressed(_playerManager.Players[i], ButtonType.BUTTON_A))
                GoToThisScene(1);
        }
    }

    /// <summary>
    /// Makes the game go to the next scene
    /// </summary>
    /// <param name="iSceneNumber"></param>
	public void GoToThisScene(int iSceneNumber) {
        SceneManager.LoadScene(iSceneNumber);
    }
}
