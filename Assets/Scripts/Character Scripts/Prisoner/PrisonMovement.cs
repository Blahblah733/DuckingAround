using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;

public class PrisonMovement : MonoBehaviour
{
    private Animator animator;
    private float horizontal; 
    private float speed = 8f; // How fast the character moves
    private float jumpingPower = 12f; // How strong the jump is
    private bool isFacingRight = true; // Variable for if they are facing right
    private SpriteRenderer sr;

    [SerializeField] private Rigidbody2D rb; // Gets rigidbody2D info
    [SerializeField] private Transform GroundCheck; // Follows GroundCheck GameObject
    [SerializeField] private LayerMask GroundLayer;  // Recognises Ground Layer



    private void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        /* if (Input.GetButtonDown("Jump") && IsGrounded()) // If the player presses spacebar and is on the ground
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower); // Add jumppower to Y Axis
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) // If player lets go of jump stop jumping
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * -0.2f); // add more gravity
        } */

        


        Flip();
    }

    
    


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }





    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
    }




    private void Flip() // Tracks which direction player is facing
    {
        if (horizontal > 0)
        {
            sr.flipX = true;
        }
        else if (horizontal < 0)
        {
            sr.flipX= false;
        }


    }
}
