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
    private List<Image> _scorePlates = new List<Image>(4);
    [SerializeField]
    private List<Image> _playerPortrait = new List<Image>(4);
    [SerializeField]
    private List<Sprite> _characterPortraitSprites = new List<Sprite>(4);
    [SerializeField]
    private List<Sprite> _victoryPortraitSprites = new List<Sprite>(4);
    [SerializeField]
    private Sprite _mvpPlate;
    [SerializeField]
    private GameObject _loadingScreen;

    private PlayerManager _playerManager;

    private void Start() {
        _playerManager = PlayerManager.Instance;
    }

    public void SetVictoryScreen() {
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
                    _scorePlates[i].sprite = _mvpPlate;
                    _playerObject[i].transform.Translate(Vector2.up * 100);
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
    public void Continue() {
        if(GameInfoTracker.Instance.CurrentRound != 3) {
            Instantiate(_loadingScreen);
        }
        else {
            gameObject.AddComponent<GoToScene>().GoToThisScene(2);
        }
    }
}
