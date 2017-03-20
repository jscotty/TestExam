//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Exam.Reference.Path;

public class PlayerSelectionButtonIdentifier : MonoBehaviour {

    [SerializeField]
    private Image[] _buttons = new Image[4]; // UI images

    private PlayerManager _playerManager;
    private XboxControllerManager _xboxControllerManager;

    private bool[] _buttonPressed = new bool[4] { false, false, false, false }; // stored pressing boolean
    private ButtonType[] _buttonType = new ButtonType[4] { ButtonType.BUTTON_A, ButtonType.BUTTON_A, ButtonType.BUTTON_A, ButtonType.BUTTON_A }; // stored buttontype
    private int[] _buttonClicked = new int[4] { 0, 0, 0, 0 }; // stored index

    private int _aClicked = 1, _bClicked = 2;

    private void Start()
    {
        _playerManager = PlayerManager.Instance;
        _xboxControllerManager = XboxControllerManager.Instance;

        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].color = new Color(1, 1, 1, 0); // hide all buttons
        }
    }

    private void Update()
    {
        for (int i = 0; i < _playerManager.Players.Count; i++)
        {
            if(_buttons[i].color.a == 0.0f)
                _buttons[i].color = new Color(1, 1, 1, 1); // player is connected so show button!

            PlayerInformation tPlayerInfo = _playerManager.Players[i];
            Sprite tSprite;
            switch (_buttonType[i])
            {
                case ButtonType.BUTTON_A:
                    tSprite = Resources.Load<Sprite>(SpritePaths.SpritePath[SpriteType.BUTTON_A_RELEASED]);
                    break;
                case ButtonType.BUTTON_B:
                    tSprite = Resources.Load<Sprite>(SpritePaths.SpritePath[SpriteType.BUTTON_B_RELEASED]);
                    break;
                default:
                    tSprite = Resources.Load<Sprite>(SpritePaths.SpritePath[SpriteType.BUTTON_A_RELEASED]);
                    break;
            }
            if (_xboxControllerManager.GetButtonPressed(tPlayerInfo, _buttonType[i])) {
                _buttonPressed[i] = true;
                switch (_buttonType[i])
                {
                    case ButtonType.BUTTON_A:
                        tSprite = Resources.Load<Sprite>(SpritePaths.SpritePath[SpriteType.BUTTON_A_PRESSED]);
                        break;
                    case ButtonType.BUTTON_B:
                        tSprite = Resources.Load<Sprite>(SpritePaths.SpritePath[SpriteType.BUTTON_B_PRESSED]);
                        break;
                }
            }
            else if (!_xboxControllerManager.GetButtonPressed(tPlayerInfo, _buttonType[i]))
            {
                if (_buttonPressed[i]) {
                    if (_buttonType[i].Equals(ButtonType.BUTTON_A))
                    {
                        _buttonClicked[i] = _aClicked;
                        _buttonType[i] = ButtonType.BUTTON_B;
                    }
                    else if (_buttonType[i].Equals(ButtonType.BUTTON_B))
                    {
                        _buttonClicked[i] = _bClicked;
                        _buttonType[i] = ButtonType.BUTTON_A;
                    } 
                    _buttonPressed[i] = false;
                }
            }

            _buttons[i].sprite = tSprite;
        }
    }

    public bool GetButtonClicked(ButtonType iButton, int iIndex) {
        switch (iButton)
        {
            case ButtonType.BUTTON_A:
                if (_buttonClicked[iIndex].Equals(_aClicked)) return true;
                else return false;
            case ButtonType.BUTTON_B:
                if (_buttonClicked[iIndex].Equals(_bClicked)) return true;
                else return false;
            default:

                return false;
        }
    }
}
