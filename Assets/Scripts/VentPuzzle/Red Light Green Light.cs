using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedLightGreenLight : MonoBehaviour
{
    public GameObject guardSpeach;

    public GameObject guardWarn;

    public string loseSceneName = "G-O Vent";

    public float minWaitTime = 2f;

    public float maxWaitTime = 5f;

    [HideInInspector] public bool isGuardSpeaking = false;

    void Start()
    {
        StartCoroutine(LightCycle());
    }


    void Update()
    {
        if (isGuardSpeaking)
        {
            if (Input.GetAxisRaw("Horizontal") !=0)
            {
                Debug.Log("Player Moved During Guard Speaking");
                SceneManager.LoadScene(loseSceneName);
            }
        }
    }

    IEnumerator LightCycle()
    {
        while (true)
        {
            // Safe to Go
            isGuardSpeaking = false;
            guardSpeach.SetActive(false);
            guardWarn.SetActive(false);
            Debug.Log("Good to Go!");
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));

            // Warning Phase
            Debug.Log("Stop soon");
            guardWarn.SetActive(true);
            yield return new WaitForSeconds(1.0f); // short warning before red light

            // Not Safe
            guardWarn.SetActive(false);
            isGuardSpeaking =true;
            guardSpeach.SetActive(true);
            Debug.Log("Not Safe");
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        }    
    }


}
