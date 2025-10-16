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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clothes"))
        {
            SortTracker.Instance.ItemSorted(true);  // Correct
            Debug.Log("Correctly washed laundry.");
        }
        else
        {
            SortTracker.Instance.ItemSorted(false); // Incorrect
            Debug.Log("Wrong item in washer!");
        }

        Destroy(other.gameObject); // Remove item after sorting
    }

}
