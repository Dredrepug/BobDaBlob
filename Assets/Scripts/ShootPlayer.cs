using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour {
    public float playerRange;

    public GameObject slimeShot;

    public PlayerController thePlayer;

    public Transform origin;

    public float timeBetweenShots;
    private float shotCounter;

    public LvlManager theLevelManager;

    // Use this for initialization
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        shotCounter = timeBetweenShots;
        theLevelManager = FindObjectOfType<LvlManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));
        shotCounter -= Time.deltaTime;

        if (transform.localScale.x < 0 && thePlayer.transform.position.x > transform.position.x && thePlayer.transform.position.x < transform.position.x + playerRange && shotCounter < 0)
        {
            Instantiate(slimeShot, origin.position, origin.rotation);
            shotCounter = timeBetweenShots;
        }

        if (transform.localScale.x > 0 && thePlayer.transform.position.x < transform.position.x && thePlayer.transform.position.x > transform.position.x - playerRange && shotCounter < 0)
        {
            Instantiate(slimeShot, origin.position, origin.rotation);
            shotCounter = timeBetweenShots;
        }
        if (thePlayer.transform.position.x >= transform.position.x || theLevelManager.playerDead ==true)
        {
            playerRange = 0;
        }
    }
    }
