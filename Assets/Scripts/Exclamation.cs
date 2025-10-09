using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exclamation : MonoBehaviour
{
    public static bool InZone = false;

    [SerializeField] private GameObject warning;


    private void Start()
    {
        warning.SetActive(false);
        Debug.Log("setactive=false");
    }
    // Update is called once per frame
    private void Update()
    {
        if (InZone == true)
        {
            Debug.Log("please work");
            warning.SetActive(true);
            Debug.Log("SetActive");
        }
        else
        {
            warning.SetActive(false);
        }
    }
}
