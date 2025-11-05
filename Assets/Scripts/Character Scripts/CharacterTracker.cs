using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CharacterTracker : MonoBehaviour
{
    public GameObject characterPrisoner;
    public GameObject characterGuard;
    public GameObject targetObject;

    // Private variable to store what type of character targetObject is
    public enum CharacterType { None, Prisoner, Guard, Unknown }
    public CharacterType currentTargetType = CharacterType.None;

    void Update()
    {
        if (targetObject == null)
        {
            currentTargetType = CharacterType.None;
            return;
        }

        if (targetObject.name.Contains(characterPrisoner.name))
        {
            currentTargetType = CharacterType.Prisoner;
        }
        else if (targetObject.name.Contains(characterGuard.name))
        {
            currentTargetType = CharacterType.Guard;
        }
        else
        {
            currentTargetType = CharacterType.Unknown;
        }
    }
}
