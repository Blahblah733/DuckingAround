using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PuzzleFailed : MonoBehaviour
{
    public string sceneToLoad;
    public void TryAgain()
    {
        Debug.Log("Load LockPick");
        SceneManager.LoadScene(sceneToLoad);
    }
}
