using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardDestroy : MonoBehaviour
{
    [SerializeField] GameObject guard;

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
