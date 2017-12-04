using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameSpawn : MonoBehaviour {

    public GameObject theFlame;
	public AudioSource FlameSound;
	public SpriteRenderer FlameSprite;
	private bool FlameVisibility;
	public float lowPitchRange = .8f;	
	public float highPitchRange = 1.2f;
	public float randomPitch;

	// Use this for initialization
	void Start () {

        theFlame.SetActive(false);
		FlameSprite = GetComponentInChildren<SpriteRenderer> ();
		FlameSound = GetComponent<AudioSource>();
		randomPitch = Random.Range(lowPitchRange, highPitchRange);

	}

    // Update is called once per frame
    void Update() {


    	}

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                theFlame.SetActive(true);

				if (FlameVisibility == false) {
					FlameSound.pitch = randomPitch;
					FlameSound.Play ();
					FlameVisibility = true;
				}
				
            }
        }

    }


