using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatofrmDestoryer : MonoBehaviour {
    public GameObject platorformDestroy;
	// Use this for initialization
	void Start () {
        platorformDestroy = GameObject.Find("platorformDestroy");

    }
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < platorformDestroy.transform.position.x)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
	}
}
