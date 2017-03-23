using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    private bool _loadScene = false;
    private bool _destroyable = false;
    [SerializeField]
    private Text _loadingScreenText;
    [SerializeField]
    private GameObject _buttonImage;

    [SerializeField]
    private string _loadingScreenDoneText;

    [SerializeField]
    private int scene;

    private XboxControllerManager _xboxControllerManager;
    private PlayerManager _playerManager;
    
    private void Start() {
        if (!_loadScene) {
            _xboxControllerManager = XboxControllerManager.Instance;
            _playerManager = PlayerManager.Instance;
            _loadScene = true;
            DontDestroyOnLoad(transform.parent.gameObject);
            Time.timeScale = 0;
            StartCoroutine(LoadNewScene());
        }
    }

    /// <summary>
    /// Checks when the next scene is done loading
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadNewScene() {
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);
        
        while (!async.isDone) {
            yield return null;
        }
        Debug.Log("Scene done loading");
        _destroyable = true;
        _loadingScreenText.text = _loadingScreenDoneText;
        _buttonImage.SetActive(true);
    }

    /// <summary>
    /// Removes the loading screen if the scene is done loading
    /// </summary>
    private void Update() {
        if (_destroyable) {
            for (int i = 0; i < _playerManager.Players.Count; i++) {
                if (_xboxControllerManager.GetButtonPressed(_playerManager.Players[i], ButtonType.BUTTON_A)) {
                    Time.timeScale = 1;
                    Destroy(transform.parent.gameObject);
                }
            }
        }
    }
}