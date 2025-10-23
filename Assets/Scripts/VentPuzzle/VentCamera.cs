using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentCamera : MonoBehaviour
{
    public Vector3 offset; // Optional offset
    public float smoothSpeed = 0.125f;

    public GameObject targetObject;  // The object the camera follows (currentCharacter from SwapChar)

    


    void LateUpdate()
    {
        

        if (targetObject == null) return; // Do nothing if targetObject is null

        Transform targetTransform = targetObject.transform;

        // The camera follows the target regardless of whether it's a clone
        Vector3 desiredPosition = targetTransform.position + offset;
        desiredPosition.z = transform.position.z; // Keep the camera's Z-position constant

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
