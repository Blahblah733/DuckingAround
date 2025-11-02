using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorylineTextDelay : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        text1.SetActive(false);
        text2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("lineOne", 1);
        Invoke("characterName", 9);
        Invoke("lineTwo", 12);
        Invoke("lineThree", 30);
        Invoke("continueButton", 38);
    }

    void lineOne()
    {
        text1.SetActive(true);
    }

    void characterName()
    {
        text2.SetActive(true);
    }

    void lineTwo()
    {
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(true);
    }

    void lineThree()
    {
        text3.SetActive(false);
        text4.SetActive(true);
    }

    void continueButton()
    {
        button.SetActive(true);
    }
}
