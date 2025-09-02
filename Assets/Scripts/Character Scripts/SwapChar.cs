using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SwapChar : MonoBehaviour
{
    public GameObject characterPrisoner;
    public GameObject characterGuard;
    public CharacterTracker characterTracker;
    public ZonePrisoner zonePrisoner;

    private GameObject currentCharacter;
    private int currentIndex = 0; // 0 = Prisoner, 1 = Guard

    private void Start()
    {
        // Start as prisoner
        currentCharacter = Instantiate(characterPrisoner, Vector3.zero, Quaternion.identity);
        currentIndex = 0;
    }

    private void Update()
    {
        characterTracker.targetObject = currentCharacter;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchCharacter();
        }
    }

    void SwitchCharacter()
    {
        // Save Position of Character
        Vector3 position = currentCharacter.transform.position;
        Quaternion rotation = currentCharacter.transform.rotation;

        // Destory Current Character
        Destroy(currentCharacter);

        // Switch Index (0 -> 1)
        currentIndex = (currentIndex + 1) % 2;

        if (currentIndex == 0)
        {
            currentCharacter = Instantiate(characterPrisoner, position, rotation);
        }
        else
        {
            currentCharacter = Instantiate(characterGuard, position, rotation);
        }

        if (characterTracker != null)
        { 
            characterTracker.targetObject = currentCharacter;
        }

        if (zonePrisoner != null)
        {
            zonePrisoner.targetObject = currentCharacter;
        }
        
    }

    public GameObject GetCurrentCharacter()
    {
        return currentCharacter;
    }
}

   
   