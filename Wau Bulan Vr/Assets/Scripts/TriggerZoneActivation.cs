using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneActivation : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject targetObject;
    [SerializeField] private bool deactivateOnExit = false;

    [Header("Optional Tag Filter")]
    [SerializeField] private bool filterByTag = true;
    [SerializeField] private string playerTag = "Player";

    private void Start()
    {
        // Ensure the target is off at the start if needed
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if we should filter by tag, and if the colliding object matches
        if (filterByTag && !other.CompareTag(playerTag)) return;

        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If enabled, turn the object back off when the player leaves
        if (deactivateOnExit)
        {
            if (filterByTag && !other.CompareTag(playerTag)) return;

            if (targetObject != null)
            {
                targetObject.SetActive(false);
            }
        }
    }
}