using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            SortTracker.Instance.ItemSorted(true);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Shirt"))
        {
            SortTracker.Instance.ItemSorted(false);
            Destroy(other.gameObject); // or send back if you want retries
        }
    }
}
