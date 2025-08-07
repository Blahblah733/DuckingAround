using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterTracker : MonoBehaviour
{
    public GameObject targetObject;
    public TextMeshProUGUI uiText;
    void Update()
    {
        if (targetObject != null)
        {
            uiText.text = "Prisoner";
        }
        else
        {
            uiText.text = "Guard";
        }
    }
}
