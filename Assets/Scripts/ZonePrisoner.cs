using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonePrisoner : MonoBehaviour
{

    public GameObject characterPrisoner;
    public GameObject characterGuard;

    public GameObject targetObject;

    private void OnTriggerEnter2D(Collider other)
    {
        if(targetObject.name.Contains(characterPrisoner.name))
        {

        }
    }


}
