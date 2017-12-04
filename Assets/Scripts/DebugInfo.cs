using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DebugInfo : MonoBehaviour {

	//public static DebugInfo instance = null;	
	public InputField SpeedRateInput;
	public InputField SpeedFrequencyInput;
	public InputField OriginalMoveSpeedInput;
	public InputField StartingRoundInput;
	public InputField TimeBetweenRoundsInput;
	public static float SpeedRate;
	public static float SpeedFrequency;
	public static float OriginalMoveSpeed;
	public static float StartingRound;
	public static float TimeBetweenRounds;
	public Scene currentScene;
	public string sceneName;
	private static bool DebugEnabled;


	// Use this for initialization
	void Awake ()
	{

		if (DebugEnabled == false) {
			SpeedRate = 1f;
			SpeedFrequency = 60f;
			OriginalMoveSpeed = 6f;
			StartingRound = 4f;
			TimeBetweenRounds = 15f;
		}

		currentScene = SceneManager.GetActiveScene ();
		sceneName = currentScene.name;

//		if (instance == null)
//			instance = this;
//		else if (instance != this)
//			Destroy (gameObject);
//
//		DontDestroyOnLoad (gameObject);
	
	}
		

	public void ChangeStuff(){
		SpeedRate = float.Parse(SpeedRateInput.text);
		SpeedFrequency = float.Parse(SpeedFrequencyInput.text);
		OriginalMoveSpeed = float.Parse(OriginalMoveSpeedInput.text);
		StartingRound = float.Parse(StartingRoundInput.text);
		TimeBetweenRounds = float.Parse(TimeBetweenRoundsInput.text);
	}

	// Update is called once per frame
	void Update () {
		currentScene = SceneManager.GetActiveScene ();
		sceneName = currentScene.name;

		if (sceneName == "Debug") {
			SpeedRate = float.Parse (SpeedRateInput.text);
			SpeedFrequency = float.Parse (SpeedFrequencyInput.text);
			OriginalMoveSpeed = float.Parse (OriginalMoveSpeedInput.text);
			StartingRound = float.Parse (StartingRoundInput.text);
			TimeBetweenRounds = float.Parse (TimeBetweenRoundsInput.text);
			DebugEnabled = true;


		}						
	}
}
