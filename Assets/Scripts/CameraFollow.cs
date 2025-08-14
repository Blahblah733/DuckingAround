using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Vector3 offset; // Optional offset
    public float smoothSpeed = 0.125f;

    public GameObject targetObject;
    public GameObject characterPrisoner;
    public GameObject characterGuard;

    void LateUpdate()
    {
        if (targetObject == null) return;

        Transform targetTransform = targetObject.transform;
        Debug.Log("Target object's position: " + targetTransform.position);

        if (targetObject == characterPrisoner || targetObject == characterGuard)
        {
            Vector3 desiredPosition = targetTransform.position + offset;
            desiredPosition.z = transform.position.z;

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}


