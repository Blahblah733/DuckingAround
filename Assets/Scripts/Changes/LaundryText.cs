using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LaundryText : MonoBehaviour
{
    public TextMeshPro statusText;
    public GameObject guardZone;

    private bool laundryMessageShown = false;

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.LaundryDone && !laundryMessageShown)
        {
            statusText.text = "Good, now go to lunch";
            laundryMessageShown = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && laundryMessageShown)
        {
            if (guardZone != null)
            {
                guardZone.SetActive(true);

                statusText.text = "It's lunch time";
            }

        }
    }
}
