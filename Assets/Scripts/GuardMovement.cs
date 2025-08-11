using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 4f; // How fast the character moves
    private float jumpingPower = 6f; // How strong the jump is
    private bool isFacingRight = true; // Variable for if they are facing right


    [SerializeField] private Rigidbody2D rb; // Gets rigidbody2D info
    [SerializeField] private Transform GroundCheck; // Follows GroundCheck GameObject
    [SerializeField] private LayerMask GroundLayer;  // Recognises Ground Layer



    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");


        if (Input.GetButtonDown("Jump") && IsGrounded()) // If the player presses spacebar and is on the ground
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower); // Add jumppower to Y Axis
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) // If player lets go of jump stop jumping
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * -0.2f); // add more gravity
        }


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
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) // If player has any movement recognise what direction they are moving. 
        {
            isFacingRight = !isFacingRight;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1f;
            transform.localScale = localscale;
        }

    }
}
