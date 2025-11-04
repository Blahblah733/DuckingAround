using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreTexts4 : MonoBehaviour
{
    private int keyPressCount = 0;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    private bool isInTrigger = false;
    public GameObject bubble;
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        bubble.SetActive(false);
        text1.SetActive(false);
        arrow.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInTrigger && Input.GetKeyUp(KeyCode.E))
        {
            keyPressCount++;
            if (keyPressCount == 1)
            {
                text1.SetActive(false);
                text2.SetActive(true);
                text3.SetActive(false);
                text4.SetActive(false);
            }
            if (keyPressCount == 2)
            {
                text1.SetActive(false);
                text2.SetActive(false);
                text3.SetActive(true);
                text4.SetActive(false);


            }
            if (keyPressCount == 3)
            {
                text1.SetActive(false);
                text2.SetActive(false);
                text3.SetActive(false);
                text4.SetActive(true);
            }
            if (keyPressCount == 4)
            {
                text1.SetActive(false);
                text2.SetActive(false);
                text3.SetActive(false);
                text4.SetActive(false);
                bubble.SetActive(false);
                arrow.SetActive(false);
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            bubble.SetActive(true);
            text1.SetActive(true);
            arrow.SetActive(true);
            isInTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            bubble.SetActive(false);
            arrow.SetActive(false);
            isInTrigger = false;
        }
    }
}
