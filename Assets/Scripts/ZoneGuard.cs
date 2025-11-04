using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZoneGuard : MonoBehaviour
{
    public GameObject characterPrisoner;
    public GameObject targetObject;


    [SerializeField] private GameObject uiTextObject;
    [SerializeField] private GameObject exclamationMarks;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetObject.name.Contains(characterPrisoner.name))
        {
            //Exclamation.InZone = true;
            uiTextObject.SetActive(true);

            exclamationMarks.SetActive(true);
            Debug.Log("InZone = true");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (targetObject.name.Contains(characterPrisoner.name))
        {
            uiTextObject.SetActive(false);
            exclamationMarks.SetActive(false);
        }
    }
    
}
