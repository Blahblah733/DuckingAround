using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Washer : MonoBehaviour, IDropHandler
{

    public int destroyedObjectCount = 0;
    public int clothesSuccess = 0;
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
            Debug.Log("Clothes Washed");
            SortTracker.Instance.ItemSorted(true);
            
        }
        else if (other.CompareTag("Bin")) 
        {
            SortTracker.Instance.ItemSorted(false);
        } 

        // Destroy AFTER tracking
        Destroy(other.gameObject);

    }



}
