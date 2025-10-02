using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SortTracker : MonoBehaviour
{
    public static SortTracker Instance;

    public int totalItems;       // total number of items that must be sorted
    public int correctItems = 0;

    public TextMeshProUGUI resultText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void RegisterItem()
    {
        totalItems++;
    }

    public void ItemSorted(bool correct)
    {
        if (correct)
        {
            correctItems++;

            if (correctItems >= totalItems)
            {
                WinCheck();
            }
        }
        // if wrong, just ignore (don’t count toward completion)
    }

    private void WinCheck()
    {
        Debug.Log("win");
        resultText.text = "You Win! All items sorted correctly!";
    }
}
