using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour {

    [SerializeField]
    private Scores _scores;
    [SerializeField]
    private GameObject _victoryScreen;
    [SerializeField]
    private GameTimer _gameTimer;

    [SerializeField]
    private List<MonoBehaviour> _scriptsToTurnOff = new List<MonoBehaviour>();

    /// <summary>
    /// Instantiates the victory screen when the function is called and gives it the information it needs
    /// </summary>
	public void GameFinished() {
        GameObject tVictoryScreen = Instantiate(_victoryScreen, transform, false);
        bool tSabotourWon;
        if((_gameTimer.Seconds > 0 || _gameTimer.Minutes > 0) && _scores.CurrentScore < (_scores.MaxScore / 2)) {
            tSabotourWon = true;
        }
        else {
            tSabotourWon = false;
        }
        tVictoryScreen.GetComponentInChildren<VictoryScreen>().SetVictoryScreen(tSabotourWon, _scores.CurrentScore, _scores.MaxScore, _gameTimer.Minutes, _gameTimer.Seconds, _gameTimer.MaxMinutes, _gameTimer.MaxSeconds);
        for (int i = 0; i < _scriptsToTurnOff.Count; i++) {
            _scriptsToTurnOff[i].enabled = false;
        }
    }
}
