using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlManager : MonoBehaviour
{
    public Transform platformBottomGenerator;
    private Vector3 platformBottomStartPoint;

    public Transform platformTopGenerator;
    private Vector3 platformTopStartPoint;

    public Transform backgroundGenerator;
    private Vector3 backgroundStartPoint;

    public Transform objectGenerator;
    private Vector3 objectGeneratorStartPoint;

    public float timeToReset;

    private Vector3 playerStartPoint;
    private float playerStartScale;
    public  float playerGravity;

    public int maxHealth;
    public int healthCount;

    public GameObject death;

    public PlayerController thePlayer;

    public bool playerDead;

    private ScoreManager theScoreManager;

    private Boost theBoost;

    private PlatofrmDestoryer[] platformList;

    private ObjectDestroyer[] objectList;


    // Use this for initialization
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();

        death.gameObject.SetActive(true);

        healthCount = maxHealth;

        theScoreManager = FindObjectOfType<ScoreManager>();

        platformBottomStartPoint = platformBottomGenerator.position;

        platformTopStartPoint = platformTopGenerator.position;

        backgroundStartPoint = backgroundGenerator.position;

        objectGeneratorStartPoint = objectGenerator.position;

        playerStartPoint = thePlayer.transform.position;
        playerStartScale = 0.5f;
        playerGravity = 2;
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
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        Instantiate(death, thePlayer.transform.position, thePlayer.transform.rotation);
        Destroy(death.gameObject);
        playerDead = true;
        //theBoost.boostActive =false;

        yield return new WaitForSeconds(timeToReset);

        objectList = FindObjectsOfType<ObjectDestroyer>();

        for (int i = 0; i < objectList.Length; i++)
        {
            Destroy(objectList[i].gameObject);
            
        }

        platformList = FindObjectsOfType<PlatofrmDestoryer>();

        for (int i = 0; i<platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        playerDead = false;
        thePlayer.transform.position = playerStartPoint;
        thePlayer.transform.localScale = new Vector3(playerStartScale, playerStartScale, 0);
        thePlayer.myRigidBody.gravityScale = playerGravity;

        platformBottomGenerator.position = platformBottomStartPoint;
        platformTopGenerator.position = platformTopStartPoint;
        backgroundGenerator.position = backgroundStartPoint;
        objectGenerator.position = objectGeneratorStartPoint;

        healthCount = maxHealth;

        thePlayer.gameObject.SetActive(true);
        death.gameObject.SetActive(true);
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;

    }
}
