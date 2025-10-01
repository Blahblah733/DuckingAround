using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortableItem : MonoBehaviour
{
    void Start()
    {
        SortTracker.Instance.RegisterItem();
    }
}
