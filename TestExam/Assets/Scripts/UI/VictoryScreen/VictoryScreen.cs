using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Exam.Reference.Path;
public class VictoryScreen : MonoBehaviour {

    [SerializeField]
    private List<Text> _scoreText = new List<Text>(4);
    [SerializeField]
    private List<Text> _totalScores = new List<Text>(4);
    [SerializeField]
    private List<GameObject> _playerObject = new List<GameObject>(4);
    [SerializeField]
    private List<GameObject> _scorePlates = new List<GameObject>(4);
    [SerializeField]
    private List<Image> _playerPortrait = new List<Image>(4);
    [SerializeField]
    private List<Sprite> _characterPortraitSprites = new List<Sprite>(4);
    [SerializeField]
    private List<Sprite> _victoryPortraitSprites = new List<Sprite>(4);
    [SerializeField]
    private List<GameObject> _mvpPlates = new List<GameObject>(4);
    [SerializeField]
    private GameObject _loadingScreen;
    [SerializeField]
    private GameObject _continueButton;

    private PlayerManager _playerManager;
    private XboxControllerManager _xboxControllerManager;

    private void Start() {
        _playerManager = PlayerManager.Instance;
        _xboxControllerManager = XboxControllerManager.Instance;
        GameInfoTracker.Instance.ResetScore();
        GameInfoTracker.Instance.AddScore(3, 7, Random.Range(0, 4));
        GameInfoTracker.Instance.AddScore(6, 4, Random.Range(0, 4));
        GameInfoTracker.Instance.AddScore(2, 8, Random.Range(0, 4));
        SetVictoryScreen();
    }

    public void SetVictoryScreen() {
        StartCoroutine(SkipDelay());

        List<int> tRecipeScores = GameInfoTracker.Instance.PlayerScores;
        List<int> tSaboteurScores = GameInfoTracker.Instance.SaboteurScores;
        List<int> tTotalScores = new List<int>();

        int tHighestScore = 0;

        for (int i = 0; i < 4; i++) {
            CharacterType type = CharacterPaths.CHARACTER_COLOR[_playerManager.Players[i].SelectedCharacterPath];
            _playerPortrait[i].sprite = _playerSprite(type, false);
            tTotalScores.Add(tRecipeScores[i] + tSaboteurScores[i]);
            _scoreText[i].text = tRecipeScores[i] + "\n" + tSaboteurScores[i];
            _totalScores[i].text = tTotalScores[i].ToString();
            if (tTotalScores[i] > tHighestScore) {
                tHighestScore = tTotalScores[i];
            }
        }
        if (GameInfoTracker.Instance.CurrentRound == 3) {
            for (int i = 0; i < 4; i++) {
                if (tTotalScores[i] == tHighestScore) {
                    _scorePlates[i].SetActive(false);
                    _mvpPlates[i].SetActive(true);
                    _playerObject[i].transform.Translate(Vector2.up * 70);
                    _playerPortrait[i].sprite = _playerSprite(CharacterPaths.CHARACTER_COLOR[_playerManager.Players[i].SelectedCharacterPath], true);
                }
            }
        }
    }
    private Sprite _playerSprite(CharacterType iType, bool victory) {
        int tColour = 0;
        if (iType == CharacterType.CHARACTER_BLUE) {
            tColour = 0;
        }
        else if (iType == CharacterType.CHARACTER_GREEN) {
            tColour = 1;
        }
        else if (iType == CharacterType.CHARACTER_RED) {
            tColour = 2;
        }
        else if (iType == CharacterType.CHARACTER_YELLOW) {
            tColour = 3;
        }

        if (!victory) {
            return _characterPortraitSprites[tColour];
        }
        else {
            return _victoryPortraitSprites[tColour];
        }
    }
    private bool _canContinue = false;
    IEnumerator SkipDelay() {
        yield return new WaitForSeconds(3);
        _canContinue = true;
        _continueButton.SetActive(true);
    }
    public void Update() {
        if (_canContinue) {
            for (int i = 0; i < _playerManager.Players.Count; i++) {
                if (_xboxControllerManager.GetButtonPressed(_playerManager.Players[i], ButtonType.BUTTON_A)) {
                    if (GameInfoTracker.Instance.CurrentRound != 3) {
                        Instantiate(_loadingScreen);
                    }
                    else {
                        gameObject.AddComponent<GoToScene>().GoToThisScene(2);
                    }
                }
            }
        }
    }
}
