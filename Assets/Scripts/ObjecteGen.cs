using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjecteGen : MonoBehaviour {

    public Transform genPoint;
    public float distanceBetween;

    private float objectWidthInst;

    public float distanceBewtweenMin;
    public float distancebetweenMax;

    private float transformY;

    public float yMax;
    public float ymin;

    public float element1Pos;
    public float element2Pos;
    public float element3Pos;
    public float element4Pos;
    public float element5Pos;
    public float element6Pos;
    public float element7Pos;

    public GameObject[] theDangers;
    private int dangerSelector;
    private float[] dangerWidth;

	// Use this for initialization
	void Start () {

        dangerWidth = new float[theDangers.Length];

        for (int i = 0; i < theDangers.Length; i++)
        {
            dangerWidth[i] = theDangers[i].GetComponent<BoxCollider2D>().size.x;
        }

    }
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x <genPoint.transform.position.x)
        {
            transformY = Random.Range(ymin, yMax);
            distanceBetween = Random.Range(distanceBewtweenMin, distancebetweenMax);

            dangerSelector = Random.Range(0, theDangers.Length);
            if (dangerSelector == 0)
            {
                transform.position = new Vector3(transform.position.x + dangerWidth[dangerSelector] + distanceBetween, transformY,transform.position.z);
            }
            if (dangerSelector == 1)
            {
                transform.position = new Vector3(transform.position.x + dangerWidth[dangerSelector] + distanceBetween, element1Pos, transform.position.z);
            }
            if (dangerSelector == 2)
            {
                transform.position = new Vector3(transform.position.x + dangerWidth[dangerSelector] + distanceBetween, element2Pos, transform.position.z);
            }
            if (dangerSelector == 3)
            {
                transform.position = new Vector3(transform.position.x + dangerWidth[dangerSelector] + distanceBetween, element3Pos, transform.position.z);
            }
            if (dangerSelector == 4)
            {
                transform.position = new Vector3(transform.position.x + dangerWidth[dangerSelector] + distanceBetween, element4Pos, transform.position.z);
            }
            if (dangerSelector == 5)
            {
                transform.position = new Vector3(transform.position.x + dangerWidth[dangerSelector] + distanceBetween, element5Pos, transform.position.z);
            }
            if (dangerSelector == 6)
            {
                transform.position = new Vector3(transform.position.x + dangerWidth[dangerSelector] + distanceBetween, element6Pos, transform.position.z);
            }
            if (dangerSelector == 7)
            {
                transform.position = new Vector3(transform.position.x + dangerWidth[dangerSelector] + distanceBetween, element7Pos, transform.position.z);
            }
           
            Instantiate(theDangers[dangerSelector], transform.position, transform.rotation);
        }
	}
}
