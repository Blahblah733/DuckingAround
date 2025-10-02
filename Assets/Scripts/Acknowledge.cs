using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Acknowledge : MonoBehaviour
{
    
    private GameObject Clothes;

    void Start()
    {
        if (SortTracker.Instance != null)
        {
            SortTracker.Instance.RegisterItem();
        }
        else
        {
            Debug.LogWarning("SortTracker instance not found in the scene.");
        }
    }

    
    private void OnDestroy()
    {
        

        SortTracker.Instance.ItemSorted(true);
    }

}
