using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    private GameObject targetObject;
    public float speed = 2f;

    public SwapChar swapCharScript;

    private Rigidbody2D rb;

    private bool isPlayerInRange = false;  // Track if player is within range

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (swapCharScript != null)
        {
            targetObject = swapCharScript.GetCurrentCharacter();
        }
    }

    void Update()
    {
        // Only update target reference if the player is in range
        if (isPlayerInRange)
        {
            // Always update target reference before using it
            if (swapCharScript != null && swapCharScript.GetCurrentCharacter() != targetObject)
            {
                targetObject = swapCharScript.GetCurrentCharacter();
            }
        }
    }

    void FixedUpdate()
    {
        if (isPlayerInRange && targetObject != null)
        {
            Vector2 direction = (targetObject.transform.position - transform.position).normalized;
            Vector2 newPosition = rb.position + direction * speed * Time.fixedDeltaTime;

            rb.MovePosition(newPosition);
        }
    }

    // Called when the player enters the collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;  // Start moving towards the player
        }
    }

    // Called when the player exits the collider
    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;  // Stop moving when the player exits
        }
    }
}