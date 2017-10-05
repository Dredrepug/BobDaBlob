using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlManager : MonoBehaviour
{
    public Transform platformBottomGenerator;
    private Vector3 platformBottomStartPoint;
    public Transform platformTopGenerator;
    private Vector3 platformTopStartPoint;
    public float timeToReset;
    private Vector3 playerStartPoint;
    private Vector3 playerStartScale;
    public  float playerGravity;
    public int maxHealth;
    public int healthCount;

    public GameObject death;

    public PlayerController thePlayer;

    public bool playerDead;

    private ScoreManager theScoreManager;

    // Use this for initialization
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        death.gameObject.SetActive(true);
        healthCount = maxHealth;
        theScoreManager = FindObjectOfType<ScoreManager>();
        platformBottomStartPoint = platformBottomGenerator.position;
        platformTopStartPoint = platformTopGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        playerStartScale = thePlayer.transform.localScale;
        playerGravity = thePlayer.myRigidBody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthCount <= 0)
        {
            RestartGame();
        }
    }
    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }

    public void damagePlayer(int damageToTake)
    {

        healthCount -= damageToTake;
    }
    public IEnumerator RestartGameCo()
    {
        thePlayer.gameObject.SetActive(false);
        //Instantiate(death, thePlayer.transform.position, thePlayer.transform.rotation);
        //death.gameObject.SetActive(false);
        playerDead = true;
        yield return new WaitForSeconds(timeToReset);
        playerDead = false;
        thePlayer.transform.position = playerStartPoint;
        thePlayer.transform.localScale = playerStartScale;
        thePlayer.myRigidBody.gravityScale = playerGravity;
        platformBottomGenerator.position = platformBottomStartPoint;
        platformTopGenerator.position = platformTopStartPoint;
        healthCount = maxHealth;
        thePlayer.gameObject.SetActive(true);
        //death.gameObject.SetActive(true);

    }
}
