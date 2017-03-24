using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour {

    [SerializeField]
    private GameObject _pauseScreen;
    [SerializeField]
    private List<Image> _buttonImages = new List<Image>();

    private PlayerManager _playerManager;
    private XboxControllerManager _xboxControllerManager;

    [SerializeField]
    private float _sensitivity;
    private List<bool> _changedButton = new List<bool>(4) { false, false, false, false };
    private List<bool> _pressedButton = new List<bool>(4) { false, false, false, false };

    private int _selectedButton = 0;

    private void Awake() {
        _playerManager = PlayerManager.Instance;
        _xboxControllerManager = XboxControllerManager.Instance;
    }

    void Update() {
        for (int i = 0; i < _playerManager.Players.Count; i++) {
            if (_xboxControllerManager.GetButtonPressed(_playerManager.Players[i], ButtonType.BUTTON_START)) {
                if (!_pressedButton[i]) {
                    PressPauseButton();
                    _pressedButton[i] = true;
                }
            }
            else if (_pressedButton[i]) {
                _pressedButton[i] = false;
            }
            if (_pauseScreen.activeInHierarchy) {
                if(_xboxControllerManager.GetButtonPressed(_playerManager.Players[i], ButtonType.BUTTON_A)) {
                    if(_selectedButton == 0) {
                        ResumeGame();
                    }
                    else if(_selectedButton == 1) {
                        RetryButton();
                    }
                    else {
                        QuitGame();
                    }
                }

                if (_changedButton[i]) {
                    if (_xboxControllerManager.GetLeftStickAxis(_playerManager.Players[i]).z > _sensitivity) {
                        if (!_changedButton[i]) {
                            _changedButton[i] = true;
                            _selectedButton--;
                            if (_selectedButton == -1) {
                                _selectedButton = _buttonImages.Count - 1;
                            }
                        }
                    }
                    else if (_xboxControllerManager.GetLeftStickAxis(_playerManager.Players[i]).z < -_sensitivity) {
                        if (!_changedButton[i]) {
                            _changedButton[i] = true;
                            _selectedButton++;
                            if (_selectedButton >= _buttonImages.Count) {
                                _selectedButton = 0;
                            }
                        }
                    }
                    else {
                        _changedButton[i] = false;
                    }
                    for (int j = 0; j < _buttonImages.Count; j++) {
                        if (_selectedButton != j) {
                            _buttonImages[j].color = Color.grey;
                        }
                        else {
                            _buttonImages[j].color = Color.white;
                        }
                    }
                }
            }
        }
    }

    private void RetryButton() {
        GameInfoTracker.Instance.ResetScore();
        Debug.Log("restarting scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void PressPauseButton() {
        if (_pauseScreen.activeInHierarchy) {
            ResumeGame();
            _selectedButton = 0;
        }
        else {
            PauseGame();
        }
    }
    private void PauseGame() {
        Time.timeScale = 0;
        _pauseScreen.SetActive(true);
    }
    private void ResumeGame() {
        Time.timeScale = 1;
        _pauseScreen.SetActive(false);
    }
    private void QuitGame() {
        GameInfoTracker.Instance.ResetScore();
        Time.timeScale = 1;
        gameObject.AddComponent<GoToScene>().GoToThisScene(1);
    }
}
