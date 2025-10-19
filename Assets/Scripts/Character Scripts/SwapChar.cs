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

        if (GameManager.Instance != null && GameManager.Instance.hasSavedPosition)
        {
            spawnPos = GameManager.Instance.playerPosition;
            spawnRot = GameManager.Instance.playerRotation;
            Debug.Log("SwapChar: Restoring saved player position: " + spawnPos);
        }

        // Spawn starting character
        currentCharacter = Instantiate(characterPrisoner, spawnPos, spawnRot);
        currentIndex = 0;

        AssignTargetToSystems();
    }

    private void Update()
    {
        // Update trackers
        if (characterTracker != null) characterTracker.targetObject = currentCharacter;
        if (zonePrisoner != null) zonePrisoner.targetObject = currentCharacter;
        if (zoneGuard != null) zoneGuard.targetObject = currentCharacter;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchCharacter();
        }
    }

    public void SwitchCharacter()
    {
        // Save current position
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SavePlayerTransform(currentCharacter.transform);
        }

        Vector3 position = currentCharacter.transform.position;
        Quaternion rotation = currentCharacter.transform.rotation;

        Destroy(currentCharacter);

        currentIndex = (currentIndex + 1) % 2;

        if (currentIndex == 0)
            currentCharacter = Instantiate(characterPrisoner, position, rotation);
        else
            currentCharacter = Instantiate(characterGuard, position, rotation);

        AssignTargetToSystems();
    }

    private void AssignTargetToSystems()
    {
        if (characterTracker != null) characterTracker.targetObject = currentCharacter;
        if (zonePrisoner != null) zonePrisoner.targetObject = currentCharacter;
        if (zoneGuard != null) zoneGuard.targetObject = currentCharacter;
    }

    public GameObject GetCurrentCharacter()
    {
        return currentCharacter;
    }
}



   
   