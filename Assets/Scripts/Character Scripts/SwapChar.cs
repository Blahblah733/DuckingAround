using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapChar : MonoBehaviour
{
    [Header("Character Prefabs")]
    public GameObject characterPrisoner;
    public GameObject characterGuard;

    [Header("References")]
    public CharacterTracker characterTracker;
    public ZonePrisoner zonePrisoner;
    public ZoneGuard zoneGuard;

    [Header("Spawn Settings")]
    public Transform spawnPoint; // optional

    [Header("Gameplay Conditions")]
    public bool LaundryDone = false;

    private GameObject currentCharacter;
    public int currentIndex = 0; // 0 = Prisoner, 1 = Guard

    void Start()
    {
        Vector3 spawnPos;
        Quaternion spawnRot;

        if (GameManager.Instance != null && GameManager.Instance.hasSavedPosition)
        {
            spawnPos = GameManager.Instance.playerPosition;
            spawnRot = GameManager.Instance.playerRotation;
            currentIndex = GameManager.Instance.lastCharacterIndex;
            Debug.Log($"[SwapChar] Restoring saved position {spawnPos} for character {currentIndex}");
        }
        else if (spawnPoint != null)
        {
            spawnPos = spawnPoint.position;
            spawnRot = spawnPoint.rotation;
            currentIndex = 0;
            Debug.Log($"[SwapChar] No saved position, spawning at spawnPoint {spawnPos}");
        }
        else
        {
            // Safe fallback
            spawnPos = new Vector3(0f, 1f, 0f);
            spawnRot = Quaternion.identity;
            currentIndex = 0;
            Debug.Log("[SwapChar] No saved position or spawnPoint, spawning at default location (0,1,0)");
        }

        SpawnCharacter(currentIndex, spawnPos, spawnRot);
    }

    private void Update()
    {
        if (characterTracker != null) characterTracker.targetObject = currentCharacter;
        if (zonePrisoner != null) zonePrisoner.targetObject = currentCharacter;
        if (zoneGuard != null) zoneGuard.targetObject = currentCharacter;

        if (Input.GetKeyDown(KeyCode.Space) && LaundryDone)
        {
            SwitchCharacter();
        }
    }

    private void SpawnCharacter(int index, Vector3 position, Quaternion rotation)
    {
        if (currentCharacter != null)
            Destroy(currentCharacter);

        currentCharacter = Instantiate(index == 0 ? characterPrisoner : characterGuard, position, rotation);
        currentCharacter.tag = "Player"; // camera can follow
        currentIndex = index;
        AssignTargetToSystems();
    }

    public void SwitchCharacter()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SavePlayerTransform(currentCharacter.transform, currentIndex);
        }

        Vector3 position = currentCharacter.transform.position;
        Quaternion rotation = currentCharacter.transform.rotation;

        int newIndex = (currentIndex + 1) % 2;
        SpawnCharacter(newIndex, position, rotation);
    }

    private void AssignTargetToSystems()
    {
        if (characterTracker != null) characterTracker.targetObject = currentCharacter;
        if (zonePrisoner != null) zonePrisoner.targetObject = currentCharacter;
        if (zoneGuard != null) zoneGuard.targetObject = currentCharacter;
    }
}




