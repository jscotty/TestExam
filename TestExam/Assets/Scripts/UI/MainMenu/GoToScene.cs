using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour {

    /// <summary>
    /// Makes the game go to the next scene
    /// </summary>
    /// <param name="iSceneNumber"></param>
	public void GoToThisScene(int iSceneNumber) {
        SceneManager.LoadScene(iSceneNumber);
    }
}
