using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes:MonoBehaviour {

	// Load scenes of the game
	public void LoadStarScene() {
		SceneManager.LoadScene(sceneName:"RollerBallerScene");
	}
}
