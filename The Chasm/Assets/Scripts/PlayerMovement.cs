using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public Animator playerAnimator;
    public AudioSource run;
    public float speed;
    public float jumpForce;
    float movementInput;

    private Rigidbody2D player;
    private bool dirRight = true;

    // Jump
    bool isGrounded = true;
    bool isJumping = false;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    int remainingJump;
    float remainingJumpTime;



    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (isGrounded)
        {
            remainingJump = 1;
            remainingJumpTime = 0.17f;
            
        }

            if (Input.GetButtonDown("Jump") && remainingJump > 0)
            {
            player.velocity = Vector2.up * jumpForce;
            isJumping = true;
            remainingJump--;
        }

        if (Input.GetButton("Jump") && isJumping)
        {
            if(remainingJumpTime > 0)
            {
                player.velocity = Vector2.up * 1.2f *jumpForce;
                remainingJumpTime -= Time.deltaTime;
            }

            else
            {
                isJumping = false;
            }

        }

        if(Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            remainingJumpTime = 0.17f;
        }

       
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        movementInput = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(movementInput * speed, player.velocity.y);       
        if((dirRight == false && movementInput > 0) || (dirRight == true && movementInput < 0))
        {
            Flip();
        }

        if (player.velocity.y > 0 && !isGrounded)
        {
            playerAnimator.SetBool("isJumpingUp", true);
            playerAnimator.SetBool("isFalling", false);
        }
        else if (!isGrounded)
        {
            playerAnimator.SetBool("isFalling", true);
            playerAnimator.SetBool("isJumpingUp", false);
        }
        else
        {
            playerAnimator.SetBool("isFalling", false);
        }



            if (player.velocity.x != 0 && isGrounded)
        {
            playerAnimator.SetBool("isRunning", true);
            if (!run.isPlaying)
            {
                Debug.Log("Biegnie");
                run.Play();
            }
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
            if (run.isPlaying)
            {
                Debug.Log("Stop");               
                run.Stop();
            }
        }

    }

    void Flip()
    {
        dirRight = !dirRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
