using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	//public static StartGame instance = null;	
	public Scene currentScene;
	public string sceneName;

	// Use this for initialization
	void Awake ()
	{
//		if (instance == null)
//			instance = this;
//		else if (instance != this)
//			Destroy (gameObject);
//
//		DontDestroyOnLoad (gameObject);

	}

	public void GameStarter() {
		SceneManager.LoadScene ("Endless");
	}

	// Update is called once per frame
	void Update () {
		currentScene = SceneManager.GetActiveScene ();
		sceneName = currentScene.name;

		if (Input.GetKey ("escape")) {
			Application.Quit ();
		}

		if (Input.GetKeyDown(KeyCode.Alpha0) && sceneName == "Endless") {
			SceneManager.LoadScene ("Debug");
		}

	}
}
