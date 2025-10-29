using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    public float speed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 direction = (pointB.transform.position - transform.position).normalized;
        Vector2 newPosition = rb.position * direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);

    }

}
