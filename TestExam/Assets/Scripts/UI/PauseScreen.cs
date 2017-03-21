using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour {

    [SerializeField]
    private GameObject _pauseScreen;

#if UNITY_EDITOR
    void Update () {
        if (Input.GetKeyDown(KeyCode.P)) {
            PressPauseButton();
        }
	}
#endif

    public void RetryButton() {
        GameInfoTracker.Instance.ResetScore();
        Debug.Log("restarting scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PressPauseButton() {
        if (_pauseScreen.activeInHierarchy) {
            ResumeGame();
        }
        else {
            PauseGame();
        }
    }
    public void PauseGame() {
        Time.timeScale = 0;
        _pauseScreen.SetActive(true);
    }
    public void ResumeGame() {
        Time.timeScale = 1;
        _pauseScreen.SetActive(false);
    }
    private void OnDestroy() {
        GameInfoTracker.Instance.ResetScore();
        Time.timeScale = 1;
    }
}
