//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraBehaviour : MonoBehaviour {

    [SerializeField]
    private float _minFOV = 30.0f;
    private PlayerSpawner _spawner;
    private Camera _camera;

    private float _cachedFOV;

	void Start () {
        _camera = GetComponent<Camera>();
        _cachedFOV = _camera.fieldOfView;

        _spawner = (PlayerSpawner)FindObjectOfType(typeof(PlayerSpawner));
	}

    void Update() {
        Vector3 center = CalculateCenterOfPlayers();

        Vector3 tCameraPosition = transform.position;
        tCameraPosition.x = center.x;
        transform.position = tCameraPosition;
        Debug.Log(CalculateDistanceFactor());
        _camera.fieldOfView = _minFOV + (_minFOV * CalculateDistanceFactor())/30;
        _camera.fieldOfView = Mathf.Clamp(_camera.fieldOfView, _minFOV, _cachedFOV);
    }

    private Vector3 CalculateCenterOfPlayers() {
        Vector3 center = Vector3.zero;
        for (int i = 0; i < _spawner.Players.Count; i++)
        {
            center += _spawner.Players[i].transform.position;
        }
        return center/_spawner.Players.Count;
    }

    private float CalculateDistanceFactor() {
        float xMinFactor = _spawner.Players[0].transform.position.x;
        float xMaxFactor = _spawner.Players[0].transform.position.x;
        for (int i = 0; i < _spawner.Players.Count; i++)
        {
            if (xMinFactor > _spawner.Players[i].transform.position.x)
                xMinFactor = _spawner.Players[i].transform.position.x;
            if (xMaxFactor < _spawner.Players[i].transform.position.x)
                xMaxFactor = _spawner.Players[i].transform.position.x;
        }


        return -1*(xMinFactor - xMaxFactor);
    }
}
