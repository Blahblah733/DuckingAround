using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEditor;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Components for dragged items
    public GameObject myPrefab;
    public Image image;
    public Sprite newImage;
    public Sprite oldImage;
    public GameObject Washer;
    public GameObject Bin;
    private Transform childTransform;
    [HideInInspector] public Transform parentAfterDrag;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickUpClip, _dropClip;

    // Player starts the drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");
        parentAfterDrag = transform.parent;

        // Keeps item layer above other layers
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;

        // Play Pickup Sound
        _source.PlayOneShot(_pickUpClip);

    }

    // Player is dragging item
    public void OnDrag(PointerEventData eventData)
    {

        transform.position = Input.mousePosition; // Item follows mouse on drag
        image.sprite = newImage; // Sets new image when item is dragged

    }

    // Player releases button
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag");
        transform.SetParent(parentAfterDrag); // Turns item into parent after drag
        image.raycastTarget = true;
        _source.PlayOneShot(_dropClip);
        image.sprite = oldImage;
    }

    /* public void CollectAllItems()
    {
        childTransform = Washer.transform.Find("childName");

        if (childTransform != null)
        {
            Debug.Log("Found child: " + childTransform.name);
            Destroy(childTransform);
        }

        childTransform = Bin.transform.Find(childTransform.name);

        if (childTransform != null)
        {
            Debug.Log("Found child: " + childTransform.name);
            Destroy(childTransform);
        }
    } */

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
    } */

}
