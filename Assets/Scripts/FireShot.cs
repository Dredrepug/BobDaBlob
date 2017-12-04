using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShot : MonoBehaviour
{

    public float speed;
    public PlayerController thePlayer;
    private Rigidbody2D myRigidbody;
	public AudioClip[] Fireshots;
	public AudioSource FireshotSound;
	public float lowPitchRange = .8f;	
	public float highPitchRange = 1.2f;
	public float randomPitch;


    // Use this for initialization
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        myRigidbody = GetComponent<Rigidbody2D>();
		FireshotSound = GetComponent<AudioSource>();
		randomPitch = Random.Range(lowPitchRange, highPitchRange);
		int RandomIndex = Random.Range (0, Fireshots.Length);
		FireshotSound.clip = Fireshots [RandomIndex];
		FireshotSound.pitch = randomPitch;
		FireshotSound.Play();



        if (thePlayer.transform.position.x < transform.position.x)
        {
           // speed = speed;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector3(speed, myRigidbody.velocity.y, 0f);
        if(thePlayer.transform.position.x > transform.position.y)
        {
            myRigidbody.velocity = new Vector3(-speed, myRigidbody.velocity.y, 0f);
        }
 

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")

        {
            Destroy(gameObject);
        }
    }



}
