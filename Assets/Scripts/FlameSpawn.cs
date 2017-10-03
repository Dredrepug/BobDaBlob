using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameSpawn : MonoBehaviour {

    public GameObject theFlame;

	// Use this for initialization
	void Start () {

        theFlame.SetActive(false);

	}

    // Update is called once per frame
    void Update() {

    }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                theFlame.SetActive(true);
            }
        }
    }


