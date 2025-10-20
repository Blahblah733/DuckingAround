using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Saved Player Data")]
    public Vector3 playerPosition;
    public Quaternion playerRotation;
    public bool hasSavedPosition = false;

    [Header("Character Index")]
    public int lastCharacterIndex = 0; // 0 = Prisoner, 1 = Guard

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

    /// <summary>
    /// Saves player transform and the current active character index.
    /// </summary>
    public void SavePlayerTransform(Transform player, int characterIndex)
    {
        playerPosition = player.position;
        playerRotation = player.rotation;
        lastCharacterIndex = characterIndex;
        hasSavedPosition = true;

        Debug.Log($"[GameManager] Saved position: {playerPosition}, Character index: {characterIndex}");
    }

    /// <summary>
    /// Overload that saves using the last known character index.
    /// </summary>
    public void SavePlayerTransform(Transform player)
    {
        SavePlayerTransform(player, lastCharacterIndex);
    }
}
