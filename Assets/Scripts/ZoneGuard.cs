using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZoneGuard : MonoBehaviour
{
    public GameObject characterPrisoner;
    public CharacterTracker characterTracker; // Assign your CharacterTracker in inspector

    [Header("UI Elements")]
    [SerializeField] private GameObject uiTextObject;
    [SerializeField] private GameObject exclamationMarks;

    // Helper property to mimic the old targetObject field
    public GameObject targetObject
    {
        get
        {
            return characterTracker != null ? characterTracker.targetObject : null;
        }
        set
        {
            if (characterTracker != null)
            {
                characterTracker.targetObject = value;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetObject == null) return;

        if (targetObject.name.Contains(characterPrisoner.name))
        {
            uiTextObject.SetActive(true);
            exclamationMarks.SetActive(true);
            Debug.Log("InZone = true");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (targetObject == null) return;

        if (targetObject.name.Contains(characterPrisoner.name))
        {
            uiTextObject.SetActive(false);
            exclamationMarks.SetActive(false);
        }
    }
}
