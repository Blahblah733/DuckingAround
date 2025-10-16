using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staircase : MonoBehaviour
{
    public Transform targetLocation;
    private bool isInTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isInTrigger)
        {
            // Debug.Log("Is in trigger");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            // Debug.Log("Keycode working");
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            isInTrigger = true;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Pressed W (Staircase.cs)");
                other.transform.position = targetLocation.position;
            }
            
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Updated W");
        }
    }
}
