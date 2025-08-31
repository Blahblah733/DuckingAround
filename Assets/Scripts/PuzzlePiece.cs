using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickUpClip, _dropClip;
    
    private bool _dragging;

    private Vector2 _offset;

    private void Update()
    {
        if (!_dragging) return;

        var mousePosition = GetMousePos();

        transform.position = mousePosition - _offset;
    }

    private void OnMouseDown()
    {
        _dragging = true;
        _source.PlayOneShot(_pickUpClip);

        _offset = GetMousePos() - (Vector2)transform.position;
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }




}
