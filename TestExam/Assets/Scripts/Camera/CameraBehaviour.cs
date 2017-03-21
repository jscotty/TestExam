﻿//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraBehaviour : MonoBehaviour
{

    [SerializeField]
    private float _minFOV = 30.0f; // max zoom in
    [SerializeField]
    private float _maxFOV = 54.0f; // max zoom out
    [SerializeField]
    private float _sensitivity = 30.0f; // sensitivity

    private PlayerSpawner _spawner;
    private Camera _camera;

    /// <summary>
    /// Initialization
    /// </summary>
    void Start()
    {
        _camera = GetComponent<Camera>();

        _spawner = (PlayerSpawner)FindObjectOfType(typeof(PlayerSpawner));
    }

    void Update()
    {
        Vector3 center = CalculateCenterOfPlayers();

        // set x position
        Vector3 tCameraPosition = transform.position;
        tCameraPosition.x = center.x;
        transform.position = tCameraPosition;

        // set FOV (Zoom in and out)
        _camera.fieldOfView = _minFOV + (_minFOV * CalculateDistanceFactor()) / _sensitivity; // set field of view
        _camera.fieldOfView = Mathf.Clamp(_camera.fieldOfView, _minFOV, _maxFOV); // clamp to prevent weird looking zooming
    }

    #region Calculations
    /// <summary>
    /// Calculate center of all players
    /// </summary>
    /// <returns>Center of all players</returns>
    private Vector3 CalculateCenterOfPlayers()
    {
        Vector3 center = Vector3.zero;
        for (int i = 0; i < _spawner.Players.Count; i++)
        {
            center += _spawner.Players[i].transform.position; // add positions to cached vector
        }
        return center / _spawner.Players.Count; // devide the positions by the amount of players ex: ( (1 + 2) / 2 = 1.5 )
    }

    /// <summary>
    /// Calculate distance factor of all players
    /// </summary>
    /// <returns>distance factor</returns>
    private float CalculateDistanceFactor()
    {
        float tXMinFactor = _spawner.Players[0].transform.position.x;
        float tXMaxFactor = _spawner.Players[0].transform.position.x;
        for (int i = 0; i < _spawner.Players.Count; i++)
        {
            if (tXMinFactor > _spawner.Players[i].transform.position.x) // check if min x is bigger than current x position
                tXMinFactor = _spawner.Players[i].transform.position.x;
            if (tXMaxFactor < _spawner.Players[i].transform.position.x) // check if max x is smaller than current x position
                tXMaxFactor = _spawner.Players[i].transform.position.x;
        }


        return -1 * (tXMinFactor - tXMaxFactor);
    }
    #endregion
}
