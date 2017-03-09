using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    [SerializeField] private Text _timeText;
    private int _minutes;
    private int _seconds;

    private void Start() {
        SetTimer(1, 32);
    }

    private void SetTimer(int iMinutes, int iSeconds) {
        _minutes = iMinutes;
        _seconds = iSeconds +1;
        InvokeRepeating("TimeCalculation", 0, 1);
    }
    private void TimeCalculation() {
        if(_seconds != 0) {
            _seconds--;
        }
        else {
            _minutes--;
            _seconds += 59;
        }
        if (_seconds >= 10) {
            _timeText.text = _minutes + ":" + _seconds;
        }
        else {
            _timeText.text = _minutes + ":0" + _seconds;
        }
    }
}
