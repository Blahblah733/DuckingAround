using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// File was named as this to begin with for trying a way of fixing the teleportation
// Now controls just the appearing texts after player triggers their collider
public class Stairs : MonoBehaviour
{
    public GameObject text;   
    


    void Start()
    {
        text.SetActive(false);
    }

    void Update()
    {
       
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(false);
        }
    }
}
