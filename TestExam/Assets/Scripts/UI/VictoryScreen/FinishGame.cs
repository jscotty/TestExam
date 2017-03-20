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
        _victoryScreen.SetActive(true);
        _victoryScreen.GetComponentInChildren<VictoryScreen>().SetVictoryScreen();
        for (int i = 0; i < _scriptsToTurnOff.Count; i++) {
            _scriptsToTurnOff[i].enabled = false;
        }
    }
}
