using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    // Item Drag Components
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickUpClip, _dropClip;
    
    // True and false to recognise if the item is dragging or not
    private bool _dragging;

    // Vector2 in reference to the items positions
    private Vector2 _offset, _originalPosition;

    // Similar to start, the originsl items position can transform
    void Awake()
    {
        _originalPosition = transform.position;
    }

    
    void Update()
    {
        // To recognise if the item is being dragged or not
        if (!_dragging) return;

        // Collects function for mouse position
        var mousePosition = GetMousePos();

        // Transforms mouse position incluiding offset
        transform.position = mousePosition - _offset;
    }

    // If left click is not pressed
    void OnMouseUp()
    {
        // When button isnt pressed the dragging is false, so the position stays
        transform.position = _originalPosition;
        _dragging = false;
    }

    // If left click is pressed
    void OnMouseDown()
    {
        // The user is dragging the item
        _dragging = true;

        // Plays pick up sound
        _source.PlayOneShot(_pickUpClip);

        // Finds offset of mouse position and deducts vector2
        _offset = GetMousePos() - (Vector2)transform.position;
    }

    // Mouse position
    Vector2 GetMousePos()
    {
        // Returns screen to world point to find mouse position
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }




}
