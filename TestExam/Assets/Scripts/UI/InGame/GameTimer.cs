using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    [SerializeField] private Text _timeText;
    private int _minutes;
    private int _seconds;
    [SerializeField] private int _startMinutes;
    [SerializeField] private int _startSeconds;

    [SerializeField] private ItemsToBuild _itemsToBuild;

    private void Start() {
        SetTimer(_startMinutes, _startSeconds);
    }

    /// <summary>
    /// Sets the time
    /// </summary>
    /// <param name="iMinutes"></param>
    /// <param name="iSeconds"></param>
    private void SetTimer(int iMinutes, int iSeconds) {
        _minutes = iMinutes;
        _seconds = iSeconds +1;
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
        if(_seconds != 0) {
            _seconds--;
        }
        else {
            if (_minutes != 0) {
                _minutes--;
                _seconds += 59;
            }
            else {
                _itemsToBuild.FinishedGame();
                StopCoroutine("TimerDelay");
            }
        }
        if (_seconds >= 10) {
            _timeText.text = _minutes + ":" + _seconds;
        }
        else {
            _timeText.text = _minutes + ":0" + _seconds;
        }
    }
}
