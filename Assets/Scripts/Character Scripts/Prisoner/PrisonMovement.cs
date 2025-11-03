using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;

public class PrisonMovement : MonoBehaviour
{
    private Animator animator;
    private float horizontal; 
    private float speed = 4f; // How fast the character moves
    private float jumpingPower = 12f; // How strong the jump is
    private bool isFacingRight = true; // Variable for if they are facing right
    private SpriteRenderer sr;

    public AudioSource footstepSound;

    [SerializeField] private Rigidbody2D rb; // Gets rigidbody2D info
    [SerializeField] private Transform GroundCheck; // Follows GroundCheck GameObject
    [SerializeField] private LayerMask GroundLayer;  // Recognises Ground Layer



    private void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        footstepSound.Play(); // just to test at start
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        HandleFootsteps();
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

    private void HandleFootsteps()
    {
        // Check if player is moving left or right
        if (Mathf.Abs(horizontal) > 0.1f)
        {
            if (!footstepSound.isPlaying)
            {
                footstepSound.Play();
            }
        }
        else
        {
            if (footstepSound.isPlaying)
            {
                footstepSound.Stop();
            }
        }
    }
}
