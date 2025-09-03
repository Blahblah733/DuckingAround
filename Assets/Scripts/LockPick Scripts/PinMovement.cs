using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class PinMovement : MonoBehaviour
{
    [Header("Motion")]
    public float moveSpeed = 2f;    // oscillations per second-ish
    public float moveRange = 50f;   // pixels up/down from start

    RectTransform rt;
    Vector2 startPos;
    float timer;
    bool running = false;           // private, not serialized

    void Awake()
    {
        rt = GetComponent<RectTransform>();
        startPos = rt.anchoredPosition;
        running = false;            // hard stop on load
    }

    void Update()
    {
        if (!running) return;

        timer += Time.deltaTime * moveSpeed;
        float offset = Mathf.Sin(timer) * moveRange;

        rt.anchoredPosition = new Vector2(startPos.x, startPos.y + offset);
    }

    public void Begin(bool randomizePhase = true)
    {
        if (randomizePhase) timer = Random.Range(0f, Mathf.PI * 2f);
        running = true;
    }

    public void Halt()
    {
        running = false;            // truly stops motion
    }

    public float CurrentY()
    {
        return rt.anchoredPosition.y;
    }

    public float CurrentYWorld()
    {
        return rt.position.y; 
    }
}


