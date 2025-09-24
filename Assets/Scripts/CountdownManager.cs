using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CountdownManager : MonoBehaviour
{
    public GameObject triggerText;      // Wrong Costume Text
    public TextMeshProUGUI countdownText;          // The countdown UI Text 
    public float countdownTime = 5f;    // total seconds
    public string sceneToLoad;          // scene name to load when timer finishes

    private Coroutine countdownCoroutine;
    private float timeLeft;             
    private bool isCounting = false;

    void Update()
    {
        if (triggerText == null) return;

        // Start if triggerText active and not already counting
        if (triggerText.activeSelf && !isCounting)
        {
            // Always reset before starting
            ResetCountdown();
            countdownCoroutine = StartCoroutine(Countdown());
        }
        // Stop + reset if triggerText deactivated while counting
        else if (!triggerText.activeSelf && isCounting)
        {
            ResetCountdown();
        }
    }

    private IEnumerator Countdown()
    {
        isCounting = true;
        if (countdownText) countdownText.gameObject.SetActive(true);

        while (timeLeft > 0f)
        {
            if (!triggerText.activeSelf) // safety check
                yield break;  // exit immediately

            countdownText.text = Mathf.CeilToInt(timeLeft).ToString();
            yield return null; // update per frame
            timeLeft -= Time.deltaTime;
        }

        // If we get here, countdown reached 0
        countdownText.text = "0";

        Debug.Log("Game Over - loading scene: " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ResetCountdown()
    {
        timeLeft = countdownTime;
        if (countdownText) countdownText.gameObject.SetActive(false);
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
            countdownCoroutine = null;
        }
        isCounting = false;
    }
}


