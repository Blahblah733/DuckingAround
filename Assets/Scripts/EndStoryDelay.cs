using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStoryDelay : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject endPanel;

    // Start is called before the first frame update
    void Start()
    {
        text1.SetActive(false);
        endPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("lineOne", 1);
        Invoke("lineTwo", 15);
        Invoke("endScene", 22);
    }

    void lineOne()
    {
        text1.SetActive(true);
    }

    void lineTwo()
    {
        text1.SetActive(false);
        text2.SetActive(true);
    }

    void endScene()
    {
        text2.SetActive(false);
        endPanel.SetActive(true);

    }
}
