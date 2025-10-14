using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireConnector : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LineRenderer wirePrefab;

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
                currentWire = Instantiate(wirePrefab);
                currentWire.positionCount = 2;
                currentWire.SetPosition(0, startPoint.transform.position);
            }
        }
        // While Dragging
        if (currentWire)
        {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            currentWire.SetPosition(1, mousePos);
        }

        // Release to Connect
        if (Input.GetMouseButtonUp(0) && currentWire)
        {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);
            if (hit && hit.TryGetComponent(out ConnectionPoint endPoint) && endPoint.side == ConnectionPoint.Side.Right)
            {
                if (endPoint.colourName == startPoint.colourName)
                {
                    currentWire.SetPosition(1, endPoint.transform.position);
                    completedWires.Add(new WireConnection(startPoint, endPoint, currentWire));
                    startPoint = null;
                    endPoint = null;

                    CheckPuzzleComplete();
                    return;
                }
            }

            Destroy(currentWire.gameObject);
            currentWire = null;
            startPoint = null;
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
