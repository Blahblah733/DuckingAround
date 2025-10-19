using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.Instance != null && GameManager.Instance.hasSavedPosition)
        {
            var player = GameObject.FindWithTag("Player");
            player.transform.position = GameManager.Instance.playerPosition;
            player.transform.rotation = GameManager.Instance.playerRotation;
        }
        else
        {
            Debug.Log("No Saved Position");
        }
    }
}
