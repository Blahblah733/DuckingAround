using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChildren : MonoBehaviour
{
    private int lastChildCount;

    private void Start()
    {
        lastChildCount = transform.childCount;
    }

    private void Update()
    {
        if (transform.childCount > lastChildCount)
        {
            for (int i = lastChildCount; i <transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        lastChildCount = transform.childCount;
    }
}
