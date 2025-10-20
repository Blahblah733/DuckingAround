using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapChar : MonoBehaviour
{
    public GameObject characterPrisoner;
    public GameObject characterGuard;

    public CharacterTracker characterTracker;
    public ZonePrisoner zonePrisoner;
    public ZoneGuard zoneGuard;

    private GameObject currentCharacter;
    private int currentIndex = 0; // 0 = Prisoner, 1 = Guard

    private void Start()
    {
        // Determine spawn position
        Vector3 spawnPos = Vector3.zero;
        Quaternion spawnRot = Quaternion.identity;

        // If we have saved data, use that instead
        if (GameManager.Instance != null && GameManager.Instance.hasSavedPosition)
        {
            spawnPos = GameManager.Instance.playerPosition;
            spawnRot = GameManager.Instance.playerRotation;
            currentIndex = GameManager.Instance.lastCharacterIndex;
            Debug.Log($"SwapChar: Restoring saved player position {spawnPos} for character {currentIndex}");
        }

        // Spawn whichever character was last used
        SpawnCharacter(currentIndex, spawnPos, spawnRot);
    }

    private void Update()
    {
        if (characterTracker != null) characterTracker.targetObject = currentCharacter;
        if (zonePrisoner != null) zonePrisoner.targetObject = currentCharacter;
        if (zoneGuard != null) zoneGuard.targetObject = currentCharacter;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchCharacter();
        }
    }

    private void SpawnCharacter(int index, Vector3 position, Quaternion rotation)
    {
        if (currentCharacter != null)
            Destroy(currentCharacter);

        if (index == 0)
            currentCharacter = Instantiate(characterPrisoner, position, rotation);
        else
            currentCharacter = Instantiate(characterGuard, position, rotation);

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

    public GameObject GetCurrentCharacter() => currentCharacter;
}



   
   