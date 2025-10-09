using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HTPbutton : MonoBehaviour
{

    public string sceneToLoad;

    public void StartGame()
    {
        Debug.Log("Load MainLevel");
        SceneManager.LoadScene(sceneToLoad);
    }
}
