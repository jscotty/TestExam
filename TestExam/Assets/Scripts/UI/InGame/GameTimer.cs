using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    [SerializeField]
    private Text _timeText;
    public int Minutes { get; private set; }
    public int Seconds { get; private set; }
    public int MaxMinutes { get; private set; }
    public int MaxSeconds { get; private set; }
    [SerializeField]
    private int _startMinutes;
    [SerializeField]
    private int _startSeconds;

    [SerializeField]
    private FinishGame _finishGame;

    private void Start() {
        SetTimer(_startMinutes, _startSeconds);
    }

    /// <summary>
    /// Sets the time
    /// </summary>
    /// <param name="iMinutes"></param>
    /// <param name="iSeconds"></param>
    private void SetTimer(int iMinutes, int iSeconds) {
        MaxMinutes = iMinutes;
        MaxSeconds = iSeconds;
        Minutes = iMinutes;
        Seconds = iSeconds + 1;
        StartCoroutine("TimerDelay");
    }

    /// <summary>
    /// Updates the time each second
    /// </summary>
    /// <returns></returns>
    IEnumerator TimerDelay() {
        while (true) {
            TimeCalculation();
            yield return new WaitForSeconds(1);
        }
    }

    /// <summary>
    /// Calculates the current time, updates the text in the UI and checks if time is 0
    /// </summary>
    private void TimeCalculation() {
        if (Seconds != 0) {
            Seconds--;
        }
        else {
            if (Minutes != 0) {
                Minutes--;
                Seconds += 59;
            }
            else {
                _finishGame.GameFinished();
                StopCoroutine("TimerDelay");
            }
        }
        if (Seconds >= 10) {
            _timeText.text = Minutes + ":" + Seconds;
        }
        else {
            _timeText.text = Minutes + ":0" + Seconds;
        }
    }
}
