using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Washer : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;
        }
    }

    public string childTagToDestroy = "DestroyableChild";
    
    /* public void DestroyAllChildren()
    {
        List<GameObject> childToDestroy = new List<GameObject>();
        foreach (Transform child in transform)
        {
            childToDestroy.Add(child.gameObject);
        }

        foreach (GameObject child in childToDestroy)
        {
            Destroy(child);
        }

        foreach (Transform child in transform)
        {
            if (child.CompareTag(childTagToDestroy))
            {
                Destroy(child.gameObject);
            }
        }
    } */

    public void OnTriggerEnter(Collider other)
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Transform child = transform.GetChild(i);

            if (child.gameObject.CompareTag(childTagToDestroy))
            {
                Destroy(child.gameObject);
            }
        }
    }


}
