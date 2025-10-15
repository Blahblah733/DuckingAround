using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireConnector : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LineRenderer wirePrefab;


    public LineRenderer redWirePrefab;
    public LineRenderer greenWirePrefab;
    public LineRenderer blueWirePrefab;
    public LineRenderer yellowWirePrefab;


    private LineRenderer currentWire;
    private ConnectionPoint startPoint;
    private List<WireConnection> completedWires = new();

    public class WireConnection
    {
        public ConnectionPoint start;
        public ConnectionPoint end;
        public LineRenderer wire;

        public WireConnection(ConnectionPoint s, ConnectionPoint e, LineRenderer l)
        {
            start = s;
            end = e;
            wire = l;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit && hit.TryGetComponent(out ConnectionPoint point) && point.side == ConnectionPoint.Side.Left)
            {
                startPoint = point;
                LineRenderer prefabToUse = null;

                switch (startPoint.colourName)
                {
                    case "Red": prefabToUse = redWirePrefab; break;
                    case "Blue": prefabToUse = blueWirePrefab; break;
                    case "Yellow": prefabToUse = yellowWirePrefab; break;
                    case "Green": prefabToUse = greenWirePrefab; break;
                }

                if (prefabToUse != null)
                {
                    currentWire = Instantiate(prefabToUse);
                    currentWire.positionCount = 2;

                    
                    currentWire.useWorldSpace = true;
                    currentWire.alignment = LineAlignment.Local;
                    currentWire.sortingOrder = 10; // ensures visibility over background
                    currentWire.transform.rotation = Quaternion.identity; // keeps wire flat in 2D

                    Vector3 startPos = startPoint.transform.position;
                    startPos.z = 0; // ensure correct 2D depth
                    currentWire.SetPosition(0, startPos);
                    currentWire.SetPosition(1, startPos);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (currentWire != null)
            {
                Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                Collider2D hit = Physics2D.OverlapPoint(mousePos);

                if (hit && hit.TryGetComponent(out ConnectionPoint endPoint) && endPoint.side == ConnectionPoint.Side.Right)
                {
                    if (endPoint.colourName == startPoint.colourName)
                    {
                        // Snap final wire position
                        Vector3 endPos = endPoint.transform.position;
                        endPos.z = 0;
                        currentWire.SetPosition(1, endPos);

                        // Lock wire flat and save connection
                        currentWire.transform.rotation = Quaternion.identity;
                        completedWires.Add(new WireConnection(startPoint, endPoint, currentWire));
                        currentWire = null;
                        startPoint = null;

                        CheckPuzzleComplete();
                        return;
                    }
                }

                // Invalid end point 
                Destroy(currentWire.gameObject);
                currentWire = null;
                startPoint = null;
            }

            return;
        }

        // Drag Wire
        if (currentWire != null && Input.GetMouseButton(0))
        {
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            currentWire.SetPosition(1, mousePos);

            
            currentWire.transform.rotation = Quaternion.identity;
        }
    }

    void CheckPuzzleComplete()
    {
        if (completedWires.Count >= 4)
        {
            Debug.Log("Puzzle Complete");
        }
    }
}
