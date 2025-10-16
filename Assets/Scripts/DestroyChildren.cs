using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyChildren : MonoBehaviour
{
    private int lastChildCount;

    private void Start()
    {
        lastChildCount = transform.childCount;
    }

    private void Update()
    {
        if (transform.childCount > lastChildCount)
        {
            for (int i = lastChildCount; i < transform.childCount; i++)
            {
                Transform newChild = transform.GetChild(i);

                if (newChild.CompareTag("Clothes"))
                {
                    Debug.Log("Correct");
                }
                else
                {
                    Debug.Log("Fail");
                    Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(scene.name);
                }

                Destroy(newChild.gameObject);
            }
        }

        lastChildCount = transform.childCount;
    }
}
