using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed;

    public float jumpForce;
    public float boost;
    public float slowDown;
    public Boost theBoost;

    private float startMoveSpeed;
    public Rigidbody2D myRigidBody;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;

    private Animator myAnmin;

    public bool jump;
    public float jumpTimer;
    public float jumpAnimTime;

    public LvlManager theLevelManager;

	public float IncreaseSpeedRate;
	public float IncreaseSpeedFrequency;
	public float OriginalMoveSpeed;

	public AudioClip[] Jumps;



    // Use this for initialization
    void Start () {
		
		//moveSpeed = OriginalMoveSpeed;

		moveSpeed = DebugInfo.OriginalMoveSpeed;
		IncreaseSpeedFrequency = DebugInfo.SpeedFrequency;
		IncreaseSpeedRate = DebugInfo.SpeedRate;


		//startMoveSpeed = moveSpeed;
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnmin = GetComponent<Animator>();
        theBoost = FindObjectOfType<Boost>();
        theLevelManager = FindObjectOfType<LvlManager>();

		StartCoroutine ("IncreaseSpeed");
    }
		

    // Update is called once per frame
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    void Update () {
        myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0);
        if(Input.GetKeyDown(KeyCode.A) && isGrounded)
            {
            moveSpeed = moveSpeed * (1+boost);
            theBoost.boostActive = true;
            }
        if (Input.GetKeyUp(KeyCode.A) || !isGrounded)
            {
           // moveSpeed = startMoveSpeed;
            theBoost.boostActive = false;
        }
        if (Input.GetKeyDown(KeyCode.S) && isGrounded)
        {
            moveSpeed = moveSpeed * (1 - slowDown);
        }
        if (Input.GetKeyUp(KeyCode.S) || !isGrounded)
        {
            //moveSpeed = startMoveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.A))
        {
            //moveSpeed = startMoveSpeed;
            theBoost.boostActive = false;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {  
            jump = true;
            StartCoroutine("jumpMove");
			int RandomIndex = Random.Range (0, Jumps.Length);
			SoundManager.instance.PlaySingle (Jumps [RandomIndex]);
        }
        if (Input.GetButtonDown("Jump") && !isGrounded)
        {

            myRigidBody.gravityScale = -myRigidBody.gravityScale;
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, 0);
			int RandomIndex = Random.Range (0, Jumps.Length);
			SoundManager.instance.PlaySingle (Jumps [RandomIndex]);
        }

        if (Input.GetButtonUp("Jump"))
        {
            jump = false;
        }
        if (Input.GetButton("Jump") && !isGrounded)
        {
            jump = false;
        }

        myAnmin.SetFloat("Speed", myRigidBody.velocity.x);
        myAnmin.SetBool("Grounded", isGrounded);
        myAnmin.SetBool("Jump", jump);


    }
    
    public IEnumerator jumpMove()

    {
        yield return new WaitForSeconds(jumpAnimTime);
        if(transform.localScale.y >0)
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpForce, 0f);
        if (transform.localScale.y < 0)
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, -jumpForce, 0f);
    }

	public IEnumerator IncreaseSpeed()

	{
		yield return new WaitForSeconds(IncreaseSpeedFrequency);
		moveSpeed = moveSpeed * IncreaseSpeedRate;
		StartCoroutine ("IncreaseSpeed");
	}
    
}
