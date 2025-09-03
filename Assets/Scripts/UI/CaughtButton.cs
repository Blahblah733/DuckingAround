using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CaughtButton : MonoBehaviour
{
    public string sceneToLoad;

    public void Again()
    {
        Debug.Log("Load Main Level");
        SceneManager.LoadScene(sceneToLoad);
    }
}
