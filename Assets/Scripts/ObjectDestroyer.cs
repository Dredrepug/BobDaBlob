using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

    public GameObject objectDestroyPoint;

	// Use this for initialization
	void Start () {
        objectDestroyPoint = GameObject.Find("ObjectDestroyPoint");	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < objectDestroyPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
	}
}
