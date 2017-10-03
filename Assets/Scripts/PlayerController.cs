using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed;

    public float jumpForce;

    public float jumpTime;
    public float jumpTimeCounter;

    private Rigidbody2D myRiggidBody;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;

    private Animator myAnmin;

    public bool jump;
    public float jumpTimer;
    public float jumpAnimTime;


    // Use this for initialization
    void Start () {

        myRiggidBody = GetComponent<Rigidbody2D>();
        myAnmin = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    void Update () {
        myRiggidBody.velocity = new Vector3(moveSpeed, myRiggidBody.velocity.y, 0);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {  
            jump = true;
            StartCoroutine("jumpMove");
        }
        if (Input.GetButtonDown("Jump") && !isGrounded)
        {

            myRiggidBody.gravityScale = -myRiggidBody.gravityScale;
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, 0);

        }

        if (Input.GetButtonUp("Jump"))
        {
            jump = false;
        }
        if (Input.GetButton("Jump") && !isGrounded)
        {
            jump = false;
        }

        myAnmin.SetFloat("Speed", myRiggidBody.velocity.x);
        myAnmin.SetBool("Grounded", isGrounded);
        myAnmin.SetBool("Jump", jump);
    }
    public IEnumerator jumpMove()

    {
        yield return new WaitForSeconds(jumpAnimTime);
        if(transform.localScale.y >0)
        myRiggidBody.velocity = new Vector3(myRiggidBody.velocity.x, jumpForce, 0f);
        if (transform.localScale.y < 0)
            myRiggidBody.velocity = new Vector3(myRiggidBody.velocity.x, -jumpForce, 0f);
    }
}
