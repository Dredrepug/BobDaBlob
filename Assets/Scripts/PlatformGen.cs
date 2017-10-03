using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGen : MonoBehaviour {
    public GameObject thePlatform;
    public Transform genPoint;
    public float distanceBetween;
    public float transformY;
    public ObjectPooler theObjectPool;

    private float platformWidth;


	// Use this for initialization
	void Start () {
		platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x; 
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < genPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transformY, transform.position.z);
            //Instantiate(thePlatform, transform.position, transform.rotation);
           GameObject newPlatform =  theObjectPool.GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
        }
	}
}
