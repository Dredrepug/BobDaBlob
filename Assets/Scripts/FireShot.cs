using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShot : MonoBehaviour
{

    public float speed;
    public PlayerController thePlayer;
    private Rigidbody2D myRigidbody;


    // Use this for initialization
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        myRigidbody = GetComponent<Rigidbody2D>();

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
