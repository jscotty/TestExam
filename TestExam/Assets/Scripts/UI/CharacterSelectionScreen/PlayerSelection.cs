using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Exam.Reference.Path;
using UnityEngine.SceneManagement;

public class PlayerSelection : MonoBehaviour
{

    [SerializeField]
    private Image[] _playerImages = new Image[4];

    [SerializeField]
    private GameObject _loadingscreen;

    [SerializeField]
    private float _selectSensitivity = 0.5f;
    [SerializeField]
    private float _selectedBlackness = 0.3f;
    [SerializeField]
    private float _deselectedBlackness = 1f;

    private bool[] _playerHasSelected = new bool[4] { false, false, false, false }; // check if player has selected a character
    private bool[] _playerHasSwitchedCharacter = new bool[4] { false, false, false, false }; // check if player has switched character to prevent switching every frame!
    private List<Sprite> _sprites = new List<Sprite>(); // all character sprites listed
    private int[] _playerSpriteIndex = new int[4] { 0, 0, 0, 0 }; // player current character index stored
    private Dictionary<Sprite, CharacterType> _characterPrefabReferences = new Dictionary<Sprite, CharacterType>(); // character prefab path references stored with sprite type

    private PlayerManager _playerManager;
    private XboxControllerManager _xboxControllerManager;
    private PlayerSelectionButtonIdentifier _selectionButtons;


    private void Start()
    {
        _selectionButtons = GetComponent<PlayerSelectionButtonIdentifier>();
        _playerManager = PlayerManager.Instance;
        _xboxControllerManager = XboxControllerManager.Instance;
        for (int i = 0; i < 4; i++)
        {
            Sprite tSprite = Resources.Load<Sprite>(SpritePaths.SpritePath[SpriteType.CHARACTER_SELECT_YELLOW + i]);
            if (tSprite == null)
            {
                Debug.LogError("Sprite not found!!!! given path:" + SpritePaths.SpritePath[SpriteType.CHARACTER_SELECT_BLUE + i]);
                return;
            }

            _characterPrefabReferences.Add(tSprite, CharacterType.CHARACTER_YELLOW + i);
            Debug.Log("sprite added " + SpritePaths.SpritePath[SpriteType.CHARACTER_SELECT_BLUE + i] + " " + tSprite);
            _sprites.Add(tSprite);
        }
    }

    private void Update()
    {
        _playerManager.UpdatePlayerList(); // update players list
        CheckAllPlayersSelected();

#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.Space)) SceneManager.LoadScene(2); // load scene only in editor mode
#endif
        // check input from all players
        for (int i = 0; i < _playerManager.Players.Count; i++)
        {
            PlayerInformation tPlayerInfo = _playerManager.Players[i]; // input found
#if UNITY_EDITOR
            if (_xboxControllerManager.GetButtonPressed(tPlayerInfo, ButtonType.BUTTON_START)) SceneManager.LoadScene(2); // load scene only in editor mode
#endif
            if (_playerHasSelected[i]) // check if already selected a character
            {

                if (_selectionButtons.GetButtonClicked(ButtonType.BUTTON_B, i)) // check if back button has been clicked
                {
                    Sprite tCurrentSprite = _playerImages[i].sprite;
                    _playerHasSelected[i] = false;
                    _sprites.Add(tCurrentSprite);
                    _playerImages[i].color = new Color(_deselectedBlackness, _deselectedBlackness, _deselectedBlackness, 1f);
                    _playerSpriteIndex[i] = _sprites.Count - 1;
                }
                else
                {
                    continue; // next 'i' index when not.
                }
            }

            //character next/previous selection
            if (_xboxControllerManager.GetLeftStickAxis(tPlayerInfo).x > _selectSensitivity)
            {
                if (_playerHasSwitchedCharacter[i]) break; // prevent fast player switching

                _playerHasSwitchedCharacter[i] = true;
                if (_playerSpriteIndex[i] >= _sprites.Count - 1)
                {
                    _playerSpriteIndex[i] = 0;
                }
                else
                {
                    _playerSpriteIndex[i]++;
                }
            }
            else if (_xboxControllerManager.GetLeftStickAxis(tPlayerInfo).x < -_selectSensitivity)
            {
                if (_playerHasSwitchedCharacter[i]) break; // prevent fast player switching

                _playerHasSwitchedCharacter[i] = true;
                if (_playerSpriteIndex[i] == 0)
                {
                    _playerSpriteIndex[i] = _sprites.Count - 1;
                }
                else
                {
                    _playerSpriteIndex[i]--;
                }
            }
            else
            {
                _playerHasSwitchedCharacter[i] = false;
            }
            if (_playerSpriteIndex[i] > _sprites.Count - 1) _playerSpriteIndex[i] = 0; // check index to prevent errors
            Sprite tSprite = _sprites[_playerSpriteIndex[i]];

            //select character
            if (_selectionButtons.GetButtonClicked(ButtonType.BUTTON_A, i))
            {
                _playerHasSelected[i] = true;
                _sprites.Remove(tSprite);
                _playerImages[i].color = new Color(_selectedBlackness, _selectedBlackness, _selectedBlackness, 1);
                tPlayerInfo.SetSelectedCharacterPath(_characterPrefabReferences[tSprite]);
                for (int j = 0; j < _playerImages.Length; j++)
                {
                    if (j == i) break;
                    if (_playerImages[j].sprite.Equals(tSprite))
                    {
                        _playerImages[j].sprite = _sprites[0];
                    }
                }
            }

            _playerImages[i].sprite = tSprite;
        }
    }

    private void CheckAllPlayersSelected() {
        bool tAllSelected = true;
        for (int i = 0; i < _playerHasSelected.Length; i++)
        {
            if (!_playerHasSelected[i])
                tAllSelected = false;
        }

        if (tAllSelected)
            SceneManager.LoadScene(2);
    }

    /* Nick code
    /// <summary>
    /// Let's the menu know a player has been connected
    /// </summary>
    /// <param name="iConnectedPlayer"></param>
    public void ConnectPlayer(int iConnectedPlayer) {
        _connectedPlayer[iConnectedPlayer] = true;
        _playerImages[iConnectedPlayer].color = Color.white;
        _joinText[iConnectedPlayer].SetActive(false);
    }

    /// <summary>
    /// Let's the menu know a player has disconnected
    /// </summary>
    /// <param name="iDisconnectedPlayer"></param>
    public void DisconnectPlayer(int iDisconnectedPlayer) {
        _connectedPlayer[iDisconnectedPlayer] = false;
        _playerImages[iDisconnectedPlayer].color = Color.gray;
        _joinText[iDisconnectedPlayer].SetActive(true);
    }
    */

    /// <summary>
    /// Checks if all players are connected and spawns a loading screen if they are
    /// </summary>
    public void StartGame()
    {
        Instantiate(_loadingscreen);
    }
}
