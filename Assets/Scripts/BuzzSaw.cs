using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuzzSaw : MonoBehaviour {
    public Transform leftPoint;
    public Transform rightPoint;
    public float moveSpeed;
    public float scaleX;
    public float scaleY;
	public AudioSource BuzzsawSound;
	public SpriteRenderer BuzzsawSprite;
	private bool BuzzsawVisibility;
	public float lowPitchRange = .8f;	
	public float highPitchRange = 1.2f;
	public float randomPitch;

    private Rigidbody2D myRigidbody;

    public bool movingRight;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
		BuzzsawSprite = GetComponentInChildren<SpriteRenderer> ();
		BuzzsawSound = GetComponent<AudioSource>();
		randomPitch = Random.Range(lowPitchRange, highPitchRange);

    }

    // Update is called once per frame
    void Update()
    {

		if (BuzzsawSprite.isVisible && BuzzsawVisibility == false) {			
			BuzzsawSound.pitch = randomPitch;
			BuzzsawSound.Play();
			BuzzsawVisibility = true;
		}
			

        if (movingRight && transform.position.x > rightPoint.position.x)
        {
            movingRight = false;

        }
        if (!movingRight && transform.position.x < leftPoint.position.x)
        {
            movingRight = true;

        }
        if (movingRight)
        {
			myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
            transform.localScale = new Vector3(-scaleX, scaleY, 1f);
        }
        else
        {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
            transform.localScale = new Vector3(scaleX, scaleY, 1f);
        }


    }
}
