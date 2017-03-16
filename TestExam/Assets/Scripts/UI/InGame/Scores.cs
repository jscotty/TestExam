using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour {

    [SerializeField]
    private int _maxScore;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private FinishGame _finishGame;

    public int CurrentScore { get; private set; }
    public int MaxScore { get; private set; }

    private void Awake() {
        SetScore(_maxScore);
    }

    /// <summary>
    /// Updates the score if an item has been handed in
    /// </summary>
    public void FinishedItem() {
        CurrentScore++;
        _scoreText.text = CurrentScore + "/" + MaxScore;
        if(CurrentScore == MaxScore) {
            _finishGame.GameFinished();
        }
    }

    /// <summary>
    /// Resets the current score and sets a maximum score
    /// </summary>
    /// <param name="iMaxScore"></param>
    public void SetScore(int iMaxScore) {
        CurrentScore = 0;
        MaxScore = iMaxScore;
    }
}
