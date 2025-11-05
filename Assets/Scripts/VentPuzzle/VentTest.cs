using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VentTest : MonoBehaviour
{
    public string SceneToLoad;
    public KeyCode interactKey = KeyCode.E;

    public GameObject MissingToolText;

    private bool PlayerInside = false;

    public bool ScrewDriver = false;

    private void Start()
    {
        if (MissingToolText != null)
            MissingToolText.SetActive(false);
    }

    private void Update()
    {
        if (!PlayerInside) return;

        if (Input.GetKeyDown(interactKey))
        {
            if (!ScrewDriver)
            {
                Debug.Log("You need a screwdriver to continue!");
                if (MissingToolText != null)
                    MissingToolText.SetActive(true);
                return;
            }

            GameObject player = GameObject.FindWithTag("Player");
            if (player != null && GameManager.Instance != null)
            {
                
                GameManager.Instance.SavePlayerTransform(player.transform, 0); // 0 = Prisoner
            }

            SceneManager.LoadScene(SceneToLoad);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player near vent");
            PlayerInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInside = false;

            if (MissingToolText != null)
                MissingToolText.SetActive(false);
        }
    }
}
