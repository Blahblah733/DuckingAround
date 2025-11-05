using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableColliderAfterWires : MonoBehaviour
{
    [Tooltip("If left empty the script will try to GetComponent<Collider2D>() on this GameObject.")]
    public Collider2D targetCollider; // The collider you want to disable

    private bool hasDisabled = false;

    void Start()
    {
        // Try to auto-assign if not set in inspector
        if (targetCollider == null)
        {
            targetCollider = GetComponent<Collider2D>();
            if (targetCollider != null)
                Debug.Log($"[DisableColliderAfterWires] Auto-found collider on {gameObject.name}.");
            else
                Debug.Log($"[DisableColliderAfterWires] No collider assigned and none found on {gameObject.name}.");
        }

        // If GameManager already says wires done, disable immediately
        if (GameManager.Instance != null && GameManager.Instance.WiresDone)
        {
            Debug.Log("[DisableColliderAfterWires] GameManager.WiresDone already true at Start -> disabling now.");
            DisableTargetCollider();
            return;
        }

        Debug.Log("[DisableColliderAfterWires] Waiting for GameManager.WiresDone to become true...");
    }

    void Update()
    {
        // If we already disabled, nothing to do
        if (hasDisabled) return;

        // Defensive checks and debug
        if (GameManager.Instance == null)
        {
            // If GameManager is missing, log once and wait
            Debug.LogWarning("[DisableColliderAfterWires] GameManager.Instance is null. Is GameManager in the scene / marked DontDestroyOnLoad?");
            return;
        }

        if (GameManager.Instance.WiresDone)
        {
            Debug.Log("[DisableColliderAfterWires] Detected GameManager.WiresDone == true in Update.");
            DisableTargetCollider();
        }
    }

    private void DisableTargetCollider()
    {
        if (targetCollider == null)
        {
            Debug.LogError("[DisableColliderAfterWires] Cannot disable collider: targetCollider is null.");
            hasDisabled = true; // prevent repeated errors
            return;
        }

        targetCollider.enabled = false;
        hasDisabled = true;
        Debug.Log($"[DisableColliderAfterWires] Disabled collider on {targetCollider.gameObject.name}.");
    }
}
