using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveScene : MonoBehaviour
{
    public string SceneName;
    public KeyCode interactKey = KeyCode.E;

    private void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            if (!string.IsNullOrEmpty(SceneName))
            {
                SceneManager.LoadScene(SceneName);
            }
            else
            {
                Debug.LogWarning("Scene Name Not Set");
            }
        }
    }
}
