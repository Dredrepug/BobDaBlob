using UnityEngine;
using System.Collections;
using System.Collections.Generic;


	public class SoundManager : MonoBehaviour 
	{

		public static SoundManager instance = null;					
		public float lowPitchRange = .995f;				
		public float highPitchRange = 1.005f;			
		public GameObject EFX1;


		void Awake ()
		{
			if (instance == null)
				instance = this;
			else if (instance != this)
				Destroy (gameObject);

			DontDestroyOnLoad (gameObject);
		}



		public void PlaySingle(AudioClip clip)
		{
			GameObject RANDOMSOUND = GameObject.Instantiate (EFX1) as GameObject;
			AudioSource SOURCESEND = RANDOMSOUND.GetComponent<AudioSource> ();
			SOURCESEND.clip = clip;
			SOURCESEND.Play ();
		}




		public void Update ()
		{

		}

	}
