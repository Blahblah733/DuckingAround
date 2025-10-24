using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZonePrisoner : MonoBehaviour
{
    public GameObject characterGuard;
    public GameObject targetObject;


    [SerializeField] private GameObject uiTextObject;
    [SerializeField] private GameObject exclamationMarks;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetObject.name.Contains(characterGuard.name))
        {
            //Exclamation.InZone = true;
            uiTextObject.SetActive(true);

            exclamationMarks.SetActive(true);            
            Debug.Log("InZone = true");
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (targetObject.name.Contains(characterGuard.name))
        {
            uiTextObject.SetActive(false);
            exclamationMarks.SetActive(false);
        }
    }

}
