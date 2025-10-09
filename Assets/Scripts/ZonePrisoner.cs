using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZonePrisoner : MonoBehaviour
{
    public GameObject characterGuard;
    public GameObject targetObject;
    

    [SerializeField] private GameObject uiTextObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetObject.name.Contains(characterGuard.name))
        {
            uiTextObject.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (targetObject.name.Contains(characterGuard.name))
        {
            uiTextObject.SetActive(false);
        }
    }
}
