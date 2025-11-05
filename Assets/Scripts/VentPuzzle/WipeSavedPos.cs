using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WipeSavedPos : MonoBehaviour
{
    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ClearSavedPosition();
        }
    }

}
