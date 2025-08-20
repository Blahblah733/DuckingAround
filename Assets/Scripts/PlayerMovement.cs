using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal; 
    private float speed = 8f; // How fast the character moves
    private float jumpingPower = 12f; // How strong the jump is
    private bool isFacingRight = true; // Variable for if they are facing right

    public int maxHealth = 100; // Player health is valued to 100
    public int currentHealth; // Defined later to update player health from ingame events
    public HealthStats healthStats; // Updates on 'HealthStats'script


    [SerializeField] private Rigidbody2D rb; // Gets rigidbody2D info
    [SerializeField] private Transform GroundCheck; // Follows GroundCheck GameObject
    [SerializeField] private LayerMask GroundLayer;  // Recognises Ground Layer

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth; // On Start current health is stated as max health
        healthStats.SetMaxHealth(maxHealth); // On Start player has max health
    }

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

        // Not yet finished as 'TakeDamage' must be activated by an event for example; player being attacked
        /* void TakeDamage(int damage)
        {
            currentHealth -= damage; // Updates damage to players current health
            
            healthStats.SetHealth(currentHealth);
        } */
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
