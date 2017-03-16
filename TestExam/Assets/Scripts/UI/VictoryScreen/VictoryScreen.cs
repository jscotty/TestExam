using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour {

    [SerializeField]
    private Text _text;

    /// <summary>
    /// Sets the text for the victory screen
    /// </summary>
    /// <param name="iSaboteurWon"></param>
    /// <param name="iCurrentScore"></param>
    /// <param name="iMaxScore"></param>
    /// <param name="iMinutesRemaining"></param>
    /// <param name="iSecondRemaining"></param>
    /// <param name="iMaxMinutes"></param>
    /// <param name="iMaxSeconds"></param>
	public void SetVictoryScreen(bool iSaboteurWon, int iCurrentScore, int iMaxScore, int iMinutesRemaining, int iSecondRemaining, int iMaxMinutes, int iMaxSeconds) {
        if (iSaboteurWon) {
            _text.text = "Saboteur won with sabotaging " + iCurrentScore + " of the " + iMaxScore + " orders";
        }
        else {
            if(iMinutesRemaining == 0 && iSecondRemaining == 0) {
                _text.text = "Order makers won with getting " + iCurrentScore + " of the " + iMaxScore + " orders done in time";
            }
            else {
                _text.text = "Order makers won with getting " + iCurrentScore + " of the " + iMaxScore + " orders with " +iMinutesRemaining + ":" + iSecondRemaining + " left";
            }
        }
    }
}
