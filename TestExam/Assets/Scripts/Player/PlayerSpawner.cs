//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact @justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public List<GameObject> Players { get; private set; }
    private PlayerManager _playerManager;
    private List<GameObject> _spawnPoints = new List<GameObject>();

    void Start()
    {
        this.Players = new List<GameObject>();

        _playerManager = PlayerManager.Instance.Init();
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                _spawnPoints.Add(transform.GetChild(i).gameObject);
            }
        }
        else
        {
            _spawnPoints.Add(this.gameObject);
        }

        for(int i = 0; i < _playerManager.Players.Count; i++)
        {
            PlayerInformation tPlayer = _playerManager.Players[i];
            GameObject tCharacter = (GameObject)Resources.Load(tPlayer.SelectedCharacterPath+tPlayer.PlayerID);
            // stop if nothing found
            if (tCharacter == null) {
                Debug.LogError("Could not find given character path!");
                return;
            }

            tCharacter = (GameObject)Instantiate(tCharacter);
            tCharacter.GetComponent<Character>().Init(tPlayer);
            int tIndex = i;
            if (tIndex > _spawnPoints.Count)
                tIndex = 0;
            tCharacter.transform.position = _spawnPoints[tIndex].transform.position; 
            Players.Add(tCharacter);
            
        }
    }
}
