using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Vector3 offset; // Optional offset
    public float smoothSpeed = 0.125f;

    private GameObject targetObject;  // The object the camera follows

    void Start()
    {
        // Find the player object by tag at the start
        targetObject = GameObject.FindGameObjectWithTag("Player");
        if (targetObject == null)
        {
            Debug.LogError("[CameraFollow] Could not find object with tag 'Player'");
        }
    }

    void LateUpdate()
    {
        // Always check if the current player exists in case it was swapped
        GameObject currentPlayer = GameObject.FindGameObjectWithTag("Player");
        if (currentPlayer != null)
        {
            targetObject = currentPlayer;
        }

        if (targetObject == null) return; // Do nothing if no player

        Transform targetTransform = targetObject.transform;

        // Calculate the desired camera position with offset
        Vector3 desiredPosition = targetTransform.position + offset;
        desiredPosition.z = transform.position.z; // Keep camera Z constant

        // Smoothly move the camera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}


