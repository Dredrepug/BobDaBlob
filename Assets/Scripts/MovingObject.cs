using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

    public GameObject objectToMove;
    public Transform startPoint;
    public Transform endPoint;
    private float moveSpeed;
    private Vector3 currentTarget;

    public float speedMin;
    public float speedMax;
	public AudioSource SpongeSound;
	public SpriteRenderer SpongeSprite;
	private bool SpongeVisibility;
	public float lowPitchRange = .8f;	
	public float highPitchRange = 1.2f;
	public float randomPitch;

    // Use this for initialization

    void Start()
    {
        currentTarget = endPoint.position;
		SpongeSprite = GetComponentInChildren<SpriteRenderer> ();
		SpongeSound = GetComponent<AudioSource>();
		randomPitch = Random.Range(lowPitchRange, highPitchRange);

    }

    // Update is called once per frame

    void Update()
    {
        moveSpeed = Random.Range(speedMin, speedMax);
        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);
        
        if (objectToMove.transform.position == endPoint.position)
        {
            currentTarget = startPoint.position;
        }

        if (objectToMove.transform.position == startPoint.position)
        {
            currentTarget = endPoint.position;
        }

		if (SpongeSprite.isVisible && SpongeVisibility == false) {
			SpongeSound.pitch = randomPitch;
			SpongeSound.Play();
			SpongeVisibility = true;
		}


    }
}