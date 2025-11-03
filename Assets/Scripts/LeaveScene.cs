using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveScene : MonoBehaviour
{
    public string SceneName;
    public KeyCode interactKey = KeyCode.E;
    public GameObject interactText;

    private bool playerInside = false;

    private void Start()
    {
        if (interactText  == null)
            interactText.SetActive(false);
    }

    private void Update()
    {
        if (!playerInside) return;

        if (Input.GetKeyDown(interactKey))
        {
            SceneManager.LoadScene(SceneName);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;

            if (interactText != null)
                interactText.SetActive(true); // Show text when player enters
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;

            if (interactText != null)
                interactText.SetActive(false); // Hide text when player leaves
        }
    }
}
