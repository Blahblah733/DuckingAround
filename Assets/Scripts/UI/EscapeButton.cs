using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeButton : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quit Game pressed.");

        
        Application.Quit();

        
    }
}

