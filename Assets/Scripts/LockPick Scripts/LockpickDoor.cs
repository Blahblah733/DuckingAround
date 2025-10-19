using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockpickDoor : MonoBehaviour
{
    public string sceneToLoad;
    public KeyCode interactKey = KeyCode.E;
    public BoxCollider2D colliderToDisable;

    private bool playerInside = false;

    void Start()
    {
        if (PuzzleState.PuzzleComplete && colliderToDisable != null)
        {
            colliderToDisable.enabled = false;
        }
    }

    void Update()
    {
        if (!playerInside) return;

        if (!PuzzleState.PuzzleComplete && Input.GetKeyDown(interactKey))
        {
            // Save active player's position
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null && GameManager.Instance != null)
            {
                GameManager.Instance.SavePlayerTransform(player.transform);
            }

            SceneManager.LoadScene(sceneToLoad);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
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
