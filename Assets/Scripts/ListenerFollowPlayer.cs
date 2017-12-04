using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerFollowPlayer : MonoBehaviour {

	public Transform PlayerPosition;
	public GameObject Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		if (Player != null) {
			PlayerPosition = Player.transform;
			gameObject.transform.position = PlayerPosition.position;
		}
	}
}
