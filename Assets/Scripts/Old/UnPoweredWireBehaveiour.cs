using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnPoweredWireBehaveiour : MonoBehaviour
{
    UnPoweredWireStat unpoweredWireS;
    // Start is called before the first frame update
    void Start()
    {
        unpoweredWireS = gameObject.GetComponent<UnPoweredWireStat>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageLight();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<WireStat>())
        {
            WireStat poweredWireS = collision.GetComponent<WireStat>();
            if (poweredWireS.objectColor == unpoweredWireS.objectColor)
            {
                poweredWireS.connected = true;
                unpoweredWireS.connected = true;
                poweredWireS.connectedPosition = gameObject.transform.position;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<WireStat>())
        {
           WireStat poweredWireS = collision.GetComponent <WireStat>();
            poweredWireS.connected = false;
            unpoweredWireS.connected = false;
        }
    }

    void ManageLight()
    {
        if (unpoweredWireS.connected)
        {
            unpoweredWireS.poweredLight.SetActive(true);
            unpoweredWireS.unpoweredLight.SetActive(false);
        }
        else
        {
            unpoweredWireS.poweredLight.SetActive(false);
            unpoweredWireS.unpoweredLight.SetActive(true);
        }
    }
}
