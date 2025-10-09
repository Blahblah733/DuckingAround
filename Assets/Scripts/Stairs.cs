using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public Transform targetLocation;
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

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Pressed W (Stars.cs)");
            other.transform.position = targetLocation.position;
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
