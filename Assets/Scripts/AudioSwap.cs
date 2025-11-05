using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwap : MonoBehaviour
{
    public AudioSource soundBefore;   // Sound to stop when WiresDone = true
    public AudioSource soundAfter;    // Sound to start when WiresDone = true

    private bool hasSwapped = false;

    void Start()
    {
        if (GameManager.Instance != null && GameManager.Instance.WiresDone)
        {
            SwapSounds();
        }
    }

    void Update()
    {
        if (!hasSwapped && GameManager.Instance != null && GameManager.Instance.WiresDone)
        {
            SwapSounds();
        }
    }

    private void SwapSounds()
    {
        if (soundBefore != null && soundBefore.isPlaying)
        {
            soundBefore.Stop();  // stop 
        }

        if (soundAfter != null)
        {
            if (!soundAfter.isPlaying)
                soundAfter.Play(); // just play it directly
        }

        hasSwapped = true;
        Debug.Log("[SwapSoundAfterWires] Switched background music after WiresDone = true");
    }
}

