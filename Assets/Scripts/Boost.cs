using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour {

    public bool boostActive;
    public Animator myAnim;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        myAnim.SetBool("Boost", boostActive);
        
	}
}
