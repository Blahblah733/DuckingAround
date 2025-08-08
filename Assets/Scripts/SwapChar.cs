using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapChar : MonoBehaviour
{
    public GameObject characterPrisoner;
    public GameObject characterGuard;

    private int currentIndex = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchCharacter();
        }
    }

    void SwitchCharacter()
    {
        if (characterPrefabs.Length == 0 || currentCharacter == null)
                return;

        // Save Character Position
        Vector3 position = currentCharacter.transform.position;
        Quaternion rotation = currentCharacter.transform.rotation;

        // destroy the current character
        Destroy(currentCharacter);

        //cycle to the next character

        

    }
}

   
   