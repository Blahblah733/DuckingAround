using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweredWireBehaveiour : MonoBehaviour
{
   
    bool mouseDown = false;
    public WireStat powerWireS;
    LineRenderer line;
    
    // Start is called before the first frame update
    void Start()
    {
        powerWireS = gameObject.GetComponent<WireStat>();
        line = gameObject.GetComponentInParent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveWire();
        line.SetPosition(3, new Vector3(gameObject.transform.localPosition.x - .1f, gameObject.transform.localPosition.y - .1f, 0));
        line.SetPosition(2, new Vector3(gameObject.transform.localPosition.x - .4f, gameObject.transform.localPosition.y - .1f, 0));

    }

    void OnMouseDown()
    {
       mouseDown = true;
    }

    void OnMouseOver()
    {
        powerWireS.moveable = true;
    }

    void OnMouseExit()
    {
       if (!powerWireS.moving)
            powerWireS.moveable = false;
    }

    void OnMouseUp()
    {
        mouseDown = false;
        if (!powerWireS.connected)
            gameObject.transform.position = powerWireS.startPosition;
        if (powerWireS.connected)
            gameObject.transform.position = powerWireS.connectedPosition;
    }

    void MoveWire()
    {
        if (mouseDown && powerWireS.moveable)
        {
            powerWireS.moving = true;
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3 (mouseX, mouseY, 1));
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, transform.parent.transform.position.z);
        }
        else
            powerWireS.moving = false;
    }


}
