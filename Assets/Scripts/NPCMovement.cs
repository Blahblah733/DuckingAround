using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public float speed = 5f;

    private Transform targetPoint;

    private void Start()
    {
        targetPoint = pointB;
    } 

    private void Update()
    {
        // Move toward the target point
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        // Check if we've reached the target
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            // Switch direction
            targetPoint = (targetPoint == pointB) ? pointA : pointB;

            // Flip sprite immediately upon direction change
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

}
