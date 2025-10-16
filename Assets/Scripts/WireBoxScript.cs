using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WireBoxScript : MonoBehaviour
{
    public string sceneToLoad;                 // LockPick Puzzle
    public KeyCode interactKey = KeyCode.E;    // key to press
    public BoxCollider2D colliderToDisable;      // Door that Unlocks

    private bool playerInside = false;

    void Start()
    {
        // If puzzle is already complete, disable the collider immediately
        if (PuzzleState.PuzzleComplete && colliderToDisable != null)
        {
            colliderToDisable.enabled = false;
        }
    }

    void Update()
    {
        // Only allow interaction if player is inside the trigger AND puzzle not completed
        if (playerInside && !PuzzleState.PuzzleComplete && Input.GetKeyDown(interactKey))
        {
            Debug.Log("Load Wire");
            SceneManager.LoadScene(sceneToLoad);
        }
        else if (playerInside && PuzzleState.PuzzleComplete && Input.GetKeyDown(interactKey))
        {
            Debug.Log("Puzzle already completed, cannot open Wire scene.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            Debug.Log("Press E to enter scene.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}
