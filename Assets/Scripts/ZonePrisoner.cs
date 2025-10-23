using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZonePrisoner : MonoBehaviour
{
    public GameObject characterGuard;
    public GameObject targetObject;


    [SerializeField] private GameObject uiTextObject;
    [SerializeField] private string Tag = "PrisonerZone";



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetObject.name.Contains(characterGuard.name))
        {
            //Exclamation.InZone = true;
            uiTextObject.SetActive(true);

            GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject obj in objects)
            {
                obj.SetActive(true);
                Debug.Log("! Should be there");
            }
            Debug.Log("InZone = true");
        }

    }

    public void ActivateAllWithTag(string tag)
    {
        Debug.Log("! Should Appear");
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject obj in objects)
        { 
            obj.SetActive(true);
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
