using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoTracker : Singleton<GameInfoTracker> {

    public List<int> PlayerScores { get; private set; }
    public List<int> SaboteurScores { get; private set; }
    public int CurrentRound { get; private set; }

    public void ResetScore() {
        CurrentRound = 0;
        PlayerScores = new List<int>();
        SaboteurScores = new List<int>();
        for (int i = 0; i < 4; i++) {
            PlayerScores.Add(0);
            SaboteurScores.Add(0);
        }
    }

    public void AddScore(int iSaboteurScore, int iSmithScore, int iSaboteurPlayer) {
        for (int i = 0; i < 4; i++) {
            if(i == iSaboteurPlayer) {
                SaboteurScores[i] += iSaboteurScore;
            }
            else {
                PlayerScores[i] += iSmithScore;
            }
        }
        CurrentRound++;
    }
}
