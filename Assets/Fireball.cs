using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public GameObject TheFireball;
	public AudioSource FireballSound;
	public SpriteRenderer FireballSprite;
	private bool FlameVisibility;
	public float lowPitchRange = .8f;	
	public float highPitchRange = 1.2f;
	public float randomPitch;

	// Use this for initialization
	void Start () {

		//TheFireball.SetActive(false);
		FireballSprite = GetComponentInChildren<SpriteRenderer> ();
		FireballSound = GetComponent<AudioSource>();
		randomPitch = Random.Range(lowPitchRange, highPitchRange);

	}

	// Update is called once per frame
	void Update() {

		FireballSprite = GetComponentInChildren<SpriteRenderer> ();


		if (FireballSprite != null) {
			if (FireballSprite.isVisible && FlameVisibility == false) {
				FireballSound.pitch = randomPitch;
				FireballSound.Play ();
				FlameVisibility = true;
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			TheFireball.SetActive(true);

		}
	}

}