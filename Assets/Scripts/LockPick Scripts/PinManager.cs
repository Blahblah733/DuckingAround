using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinManager : MonoBehaviour
{
    public PinMovement[] pins;          // assign in Inspector (the 6 UI pins)
    public RectTransform targetLine;    // the yellow line (UI Image)
    public float tolerance = 1500f;       // pixels
    public GameObject failText;
    public GameObject completeText;

    public string sceneToLoad;
    public string sceneFailed;

    int currentIndex = 0;

    void Awake()
    {
        // stop all pins so Inspector values can’t make them run
        foreach (var p in pins)
            if (p != null) p.Halt();
        if (failText != null)
            failText.SetActive(false);
        if (completeText != null)
            completeText.SetActive(false);
    }

    void Start()
    {
        ActivateCurrentPin();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            HandleClick();
    }

    void HandleClick()
    {
        if (currentIndex >= pins.Length) return;

        var pin = pins[currentIndex];
        pin.Halt(); // freeze the current one

        float distance = Mathf.Abs(pin.transform.position.y - targetLine.position.y);

        if (distance <= tolerance)
        {
            Debug.Log($"Pin {currentIndex} SUCCESS!");
            currentIndex++;
            if (currentIndex < pins.Length)
                ActivateCurrentPin();
            else
            {
                Debug.Log("Puzzle Complete!");
                if (completeText != null)
                    completeText.SetActive(true);

                
                PuzzleState.PuzzleComplete = true;

               
                StartCoroutine(LoadSceneAfterDelay(2f));
            }
        }
        else
        {
            Debug.Log($"Pin {currentIndex} FAIL!");
            StartCoroutine(ShowFailAndRestart());
        }
    }

    void ActivateCurrentPin()
    {
        // ensure only the current pin is moving
        for (int i = 0; i < pins.Length; i++)
        {
            if (pins[i] == null) continue;
            if (i == currentIndex) pins[i].Begin();
            else pins[i].Halt();
        }
    }

    IEnumerator ShowFailAndRestart()
    {
        if (failText != null)
            failText.SetActive(true);

        yield return new WaitForSeconds(2f);

        if (failText != null)
            failText.SetActive(false);

        RestartPuzzle();
    }

    void RestartPuzzle()
    {
        SceneManager.LoadScene(sceneFailed);
    }

    IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneToLoad);
    }
}

