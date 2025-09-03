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

    void Start()
    {
        timeLeft = countdownTime;
        if (countdownText) countdownText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (triggerText == null) return;

        // Start if triggerText active and not already counting
        if (triggerText.activeSelf && !isCounting)
        {
            // If you want restart every time it activates:
            // timeLeft = countdownTime;

            countdownCoroutine = StartCoroutine(Countdown());
        }
        // Stop if triggerText deactivated while counting
        else if (!triggerText.activeSelf && isCounting)
        {
            StopCoroutine(countdownCoroutine);
            countdownCoroutine = null;
            isCounting = false;
            if (countdownText) countdownText.gameObject.SetActive(false);
        }
    }

    private IEnumerator Countdown()
    {
        isCounting = true;
        if (countdownText) countdownText.gameObject.SetActive(true);

        while (timeLeft > 0f)
        {
            if (!triggerText.activeSelf) // safety check
                break;

            countdownText.text = Mathf.CeilToInt(timeLeft).ToString();
            yield return null; // smoother per-frame decrement
            timeLeft -= Time.deltaTime;
        }

        if (timeLeft <= 0f)
        {
            countdownText.text = "0";
            SceneManager.LoadScene(sceneToLoad);
            Debug.Log("Game Over");
        }
        else
        {
            // countdown was interrupted
            isCounting = false;
        }
    }

    public void ResetCountdown()
    {
        timeLeft = countdownTime;
        if (countdownText) countdownText.gameObject.SetActive(false);
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
            countdownCoroutine = null;
            isCounting = false;
        }
    }
}


