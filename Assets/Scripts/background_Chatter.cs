using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_Chatter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider2D)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = true;
        }
    }
}
