﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour {

	public void GoToThisScene(int iSceneNumber) {
        SceneManager.LoadScene(iSceneNumber);
    }
}
