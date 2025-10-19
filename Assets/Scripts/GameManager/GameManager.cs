using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Vector3 playerPosition;
    public Quaternion playerRotation;
    public bool hasSavedPosition = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Call this before leaving a scene
    public void SavePlayerTransform(Transform player)
    {
        playerPosition = player.position;
        playerRotation = player.rotation;
        hasSavedPosition = true;
        Debug.Log("GameManager: Saved player position " + playerPosition);
    }
}
