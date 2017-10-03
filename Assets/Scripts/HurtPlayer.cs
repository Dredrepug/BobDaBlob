using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

    private LvlManager theLevelManager;

    public int damageToGive;

    // Use this for initialization
    void Start()
    {
        theLevelManager = FindObjectOfType<LvlManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)

    {
        if (other.tag == "Player")
        {

            theLevelManager.damagePlayer(damageToGive);

            var player = other.GetComponent<PlayerController>();

        }
    }
}
