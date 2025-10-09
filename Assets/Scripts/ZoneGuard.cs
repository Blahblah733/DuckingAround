using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZoneGuard : MonoBehaviour
{
    public GameObject characterPrisoner;
    public GameObject targetObject;


    [SerializeField] private GameObject uiTextObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetObject.name.Contains(characterPrisoner.name))
        {
            Exclamation.InZone = true;
            Debug.Log("InZone = true");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (targetObject.name.Contains(characterPrisoner.name))
        {
            Exclamation.InZone = false;
        }
    }
    
}
