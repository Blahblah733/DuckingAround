using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractions : MonoBehaviour
{
    public GameObject bubble;

    void Start()
    {
        bubble.SetActive(false);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bubble.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bubble.SetActive(false);
        }
    }
}
