using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaundryDoor : MonoBehaviour
{
    public string sceneToLoad;
    public KeyCode interactKey = KeyCode.E;
    public BoxCollider2D colliderToDisable;

    private bool playerInside = false;

    void Start()
    {
        if (laundryState.LaundryComplete && colliderToDisable != null)
            colliderToDisable.enabled = false;
    }

    void Update()
    {
        if (playerInside && Input.GetKeyDown(interactKey))
        {
            if (!laundryState.LaundryComplete)
            {
                SavePlayerAndLoadScene();
            }
            else
            {
                Debug.Log("Puzzle already completed");
            }
        }
    }

    void SavePlayerAndLoadScene()
    {
        SwapChar swapChar = FindObjectOfType<SwapChar>();
        if (swapChar != null && GameManager.Instance != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                GameManager.Instance.SavePlayerTransform(player.transform, swapChar.currentIndex);
                Debug.Log($"[LaundryDoor] Saved player position {player.transform.position}, index {swapChar.currentIndex}");
            }
        }

        // Load asynchronously to ensure save completes
        StartCoroutine(LoadSceneAsync(sceneToLoad));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        yield return null; // wait one frame
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
            yield return null;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInside = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInside = false;
    }
}