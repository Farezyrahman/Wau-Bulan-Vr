using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables; // Required for XRI v3.0+

public class GrabUIController : MonoBehaviour
{
    [Header("UI Element")]
    [SerializeField] private GameObject uiTarget;

    [Header("Settings")]
    [SerializeField] private bool hideOnRelease = true;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        // Automatically get the Grab Interactable component on this object
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void OnEnable()
    {
        // Subscribe to grab events
        grabInteractable.selectEntered.AddListener(OnGrabbed);
        grabInteractable.selectExited.AddListener(OnReleased);
    }

    private void OnDisable()
    {
        // Unsubscribe to prevent memory leaks
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        grabInteractable.selectExited.RemoveListener(OnReleased);
    }

    private void Start()
    {
        // Hide UI at launch
        if (uiTarget != null)
        {
            uiTarget.SetActive(false);
        }
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        if (uiTarget != null)
        {
            uiTarget.SetActive(true);
        }
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        if (hideOnRelease && uiTarget != null)
        {
            uiTarget.SetActive(false);
        }
    }
}