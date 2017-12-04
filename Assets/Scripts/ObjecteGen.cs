using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjecteGen : MonoBehaviour {

    public Transform genPoint;
    public float distanceBetween;

    private float objectWidthInst;

    public float distanceBewtweenMin;
    public float distancebetweenMax;

    private float transformY;

    public float yMax;
    public float ymin;

	public float TurretBottomPos;
	public float TurretTopPos;
    public float FlameHolderBottomPos;
	public float FlameHolderTopPos;
    public float Buzzsaw1Pos;
    public float Buzzsaw2Pos;
    public float FireballPos;
    public float SpongePos;

    public GameObject[] theDangers;
    private int dangerSelector;
    private float[] dangerWidth;

	private bool TurretWait;

	public static float RoundNumber;
	public float StartingRound;
	public float TimeBetweenRounds;

	// Use this for initialization
	void Start () {
		StartingRound = DebugInfo.StartingRound;
		TimeBetweenRounds = DebugInfo.TimeBetweenRounds;

		if (StartingRound > 4) {
			StartingRound = 4;
		}
			
		RoundNumber = StartingRound;
		//print ("Round " + RoundNumber);
		StartCoroutine ("NextRound");

		TurretWait = false;

        dangerWidth = new float[theDangers.Length];

        for (int i = 0; i < theDangers.Length; i++)
        {
            dangerWidth[i] = theDangers[i].GetComponent<BoxCollider2D>().size.x;
        }



    }
		

	public IEnumerator NextRound()
	{
		//print ("Round " + RoundNumber);
		yield return new WaitForSeconds(TimeBetweenRounds);
		RoundNumber = RoundNumber + 1;
		StartCoroutine ("NextRound");
	}

	public IEnumerator WaitToSpawnTurret()
	{
		TurretWait = true;
		//print ("WAITING TO SPAWN TURRET");
		yield return new WaitForSeconds(2);
		TurretWait = false;
		//print ("OK TO SPAWN TURRET");
	}

	// Update is called once per frame
	void Update () {

		if(transform.position.x <genPoint.transform.position.x)
        {
            transformY = Random.Range(ymin, yMax);
            distanceBetween = Random.Range(distanceBewtweenMin, distancebetweenMax);

			dangerSelector = Random.Range (0, Mathf.RoundToInt (RoundNumber * 2)); //theDangers.Length); 
			if (dangerSelector == 0 && TurretWait == false)
            {
				transform.position = new Vector3(transform.position.x + dangerWidth[dangerSelector] + distanceBetween, TurretBottomPos,transform.position.z);
            }
			if (dangerSelector == 1 && TurretWait == false)
            {
				transform.position = new Vector3(transform.position.x + dangerWidth[dangerSelector] + distanceBetween, TurretTopPos, transform.position.z);
            }
			if (dangerSelector == 2)
            {
				transform.position = new Vector3(transform.position.x + dangerWidth[dangerSelector] + distanceBetween, FlameHolderBottomPos, transform.position.z);
				StartCoroutine ("WaitToSpawnTurret");
            }
            if (dangerSelector == 3)
            {
				transform.position = new Vector3(transform.position.x + dangerWidth[dangerSelector] + distanceBetween, FlameHolderTopPos, transform.position.z);
				StartCoroutine ("WaitToSpawnTurret");
            }
            if (dangerSelector == 4)
            {
				transform.position = new Vector3(transform.position.x + dangerWidth[dangerSelector] + distanceBetween, Buzzsaw1Pos, transform.position.z);
            }
            if (dangerSelector == 5)
            {
				transform.position = new Vector3(transform.position.x + dangerWidth[dangerSelector] + distanceBetween, Buzzsaw2Pos, transform.position.z);
            }
            if (dangerSelector == 6)
            {
				transform.position = new Vector3(transform.position.x + dangerWidth[dangerSelector] + distanceBetween, FireballPos, transform.position.z);
            }
            if (dangerSelector == 7)
            {
                transform.position = new Vector3(transform.position.x + dangerWidth[dangerSelector] + distanceBetween, SpongePos, transform.position.z);
            }
           
            Instantiate(theDangers[dangerSelector], transform.position, transform.rotation);
        }

		if (RoundNumber == 0) {
			StopCoroutine ("NextRound");
			RoundNumber = StartingRound;
			StartCoroutine ("NextRound");
		}

		if (RoundNumber >= 4) {
			StopCoroutine ("NextRound");
			RoundNumber = 4;
		}

	}
}
