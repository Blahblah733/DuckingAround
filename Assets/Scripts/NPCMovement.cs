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
    public bool npcInRange;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (npcInRange && pointA)
        {
            Vector2 direction = (pointA.transform.position - transform.position).normalized;
            Vector2 newPosition = rb.position * direction * speed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
        }

        if (npcInRange && pointB)
        {
            Vector2 direction = (pointA.transform.position - transform.position).normalized;
            Vector2 newPosition = rb.position * direction * speed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("npcRangeA"))
        {
            npcInRange = true;
        }

        if (other.CompareTag("npcRangeB"))
        {
            npcInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("npcRangeA"))
        {
            npcInRange = false;
        }

        if (other.CompareTag("npcRangeB"))
        {
            npcInRange = false;
        }
    }
}
