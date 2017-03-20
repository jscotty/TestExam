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
    
    private void Start() {
        if (!_loadScene) {
            _loadScene = true;
            DontDestroyOnLoad(transform.parent.gameObject);
            StartCoroutine(LoadNewScene());
        }
    }

    /// <summary>
    /// Checks when the next scene is done loading
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadNewScene() {
        yield return new WaitForSeconds(1);
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
    public void RemoveLoadingScreen() {
        if (_destroyable) {
            Destroy(transform.parent.gameObject);
        }
    }
}