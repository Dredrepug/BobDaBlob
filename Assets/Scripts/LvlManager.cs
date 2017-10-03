using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlManager : MonoBehaviour
{

    public int maxHealth;
    public int healthCount;

    public GameObject death;

    public PlayerController thePlayer;

    public bool playerDead;


    // Use this for initialization
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        death.gameObject.SetActive(true);
        healthCount = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthCount <= 0)
        {
            thePlayer.gameObject.SetActive(false);
            Instantiate(death, thePlayer.transform.position, thePlayer.transform.rotation);
            death.gameObject.SetActive(false);
            playerDead = true;

        }
    }
    public void damagePlayer(int damageToTake)
    {

        healthCount -= damageToTake;
    }
}
