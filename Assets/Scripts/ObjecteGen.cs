using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjecteGen : MonoBehaviour {

    public GameObject dangerPreFab;
    public Transform genPoint;
    public float distanceBetween;

    private float spongeWidth;

    public float distanceBewtweenMin;
    public float distancebetweenMax;

    public float transformY;

    public float yMax;
    public float ymin;
    
	// Use this for initialization
	void Start () {
        spongeWidth = dangerPreFab.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x <genPoint.transform.position.x)
        {
            transformY = Random.Range(ymin, yMax);
            distanceBetween = Random.Range(distanceBewtweenMin, distancebetweenMax);

            transform.position = new Vector3(transform.position.x + spongeWidth + distanceBetween, transformY, transform.position.z);

            Instantiate(dangerPreFab, transform.position, transform.rotation);
        }
	}
}
