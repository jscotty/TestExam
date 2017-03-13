using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour {

    [SerializeField]
    private int _maxScore;
    [SerializeField]
    private Text _scoreText;

    public int CurrentScore { get; private set; }
    public int MaxScore { get; private set; }

    private void Awake() {
        SetScore(_maxScore);
    }

    public void FinishedItem() {
        CurrentScore++;
        _scoreText.text = CurrentScore + "/" + MaxScore;
    }
    public void SetScore(int iMaxScore) {
        CurrentScore = 0;
        MaxScore = iMaxScore;
    }
}
