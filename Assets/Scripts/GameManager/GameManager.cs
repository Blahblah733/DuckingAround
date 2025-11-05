using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool LaundryDone = false;
    public bool WiresDone = false;

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

    public void SavePlayerTransform(Transform player, int characterIndex)
    {
        playerPosition = player.position;
        playerRotation = player.rotation;
        lastCharacterIndex = characterIndex;
        hasSavedPosition = true;

        Debug.Log($"[GameManager] Saved position: {playerPosition}, Character index: {characterIndex}");
    }

    public void ClearSavedPosition()
    {
        playerPosition = Vector3.zero;
        playerRotation = Quaternion.identity;
        hasSavedPosition = false;

        Debug.Log("[GameManager] Cleared saved player position.");
    }
}
