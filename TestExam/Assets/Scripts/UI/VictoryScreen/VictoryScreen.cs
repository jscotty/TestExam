using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour {

    [SerializeField]
    private List<Text> _scoreText = new List<Text>(4);
    [SerializeField]
    private List<Text> _totalScores = new List<Text>(4);
    [SerializeField]
    private List<GameObject> _playerPortraits = new List<GameObject>(4);
    [SerializeField]
    private List<Image> _scorePlates = new List<Image>(4);
    [SerializeField]
    private Sprite _mvpPlate;

    private void Start() {
        GameInfoTracker.Instance.AddScore(6, 4, 3);
        GameInfoTracker.Instance.AddScore(3, 7, 1);
        GameInfoTracker.Instance.AddScore(8, 2, 2);
    }

    public void SetVictoryScreen() {
        int tSaboteur = Random.Range(0, 5);
        _playerPortraits[tSaboteur].transform.Translate(Vector2.up * 50);
        List<int> tRecipeScores = GameInfoTracker.Instance.PlayerScores;
        List<int> tSaboteurScores = GameInfoTracker.Instance.SaboteurScores;
        List<int> tTotalScores = new List<int>();

        int tHighestScore = 0;

        for (int i = 0; i < 4; i++) {
            tTotalScores.Add(tRecipeScores[i] + tSaboteurScores[i]);
            _scoreText[i].text = tRecipeScores[i] + "\n" + tSaboteurScores[i];
            _totalScores[i].text = tTotalScores[i].ToString();
            if (tTotalScores[i] > tHighestScore) {
                tHighestScore = tTotalScores[i];
            }
        }
        for (int i = 0; i < 4; i++) {
            if(tTotalScores[i] == tHighestScore) {
                _scorePlates[i].sprite = _mvpPlate;
                _playerPortraits[i].transform.Translate(Vector2.up * 50);
            }
        }
    }
}
