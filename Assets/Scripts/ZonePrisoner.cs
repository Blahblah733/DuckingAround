using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZonePrisoner : MonoBehaviour
{
    public GameObject characterPrisoner;
    public GameObject characterGuard;
    public GameObject targetObject;
    public TextMeshProUGUI uiText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetObject.name.Contains(characterPrisoner.name))
        {
            
        }
        if (targetObject.name.Contains(characterGuard.name))
        {
            uiText.text = "Wrong Costume";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        uiText.text = "don't mind me";
    }
}
