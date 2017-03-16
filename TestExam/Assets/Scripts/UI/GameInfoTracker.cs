using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoTracker : Singleton<GameInfoTracker> {

    public List<int> _playerScores { get; private set; }
    public List<int> _SaboteurScores { get; private set; }

    private void Awake() {
        ResetScore();
    }

    public void ResetScore() {
        _playerScores.Clear();
        _SaboteurScores.Clear();
        for (int i = 0; i < 4; i++) {
            _playerScores.Add(0);
            _SaboteurScores.Add(0);
        }
    }

    public void AddScore(int iSaboteurScore, int iSmithScore, int iSaboteurPlayer) {
        for (int i = 0; i < 4; i++) {
            if(i == iSaboteurPlayer) {
                _SaboteurScores[i] += iSaboteurScore;
            }
            else {
                _playerScores[i] += iSmithScore;
            }
        }
    }
}
