using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Filtering;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class WauPaperSocketValidator : MonoBehaviour, IXRSelectFilter
{
    private XRSocketInteractor socket;

    [Header("Dependencies")]
    [Tooltip("Drag the Brush GameObject from your scene here")]
    public VRRevealBrush brushScript;

    void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    void OnEnable()
    {
        if (socket != null) socket.selectFilters.Add(this);
    }

    void OnDisable()
    {
        if (socket != null) socket.selectFilters.Remove(this);
    }

    public bool canProcess => true;

    public bool Process(IXRSelectInteractor interactor, IXRSelectInteractable interactable)
    {
        // 1. Check if the object is actually your cut Paper object (Tagged "Wau")
        if (!interactable.transform.CompareTag("Wau"))
        {
            return false;
        }

        // 2. Safety check: Has the brush been completely finalized?
        if (brushScript != null && !brushScript.isPaperFullyRevealed)
        {
            Debug.Log("Paper cannot be attached yet! Keep painting with your brush tool.");
            return false;
        }

        // 3. Physical status check: Has it been cleanly detached from its original frame?
        // Your TriggerAnimation script unparents the object (Sets parent to null)
        if (interactable.transform.parent != null)
        {
            Debug.Log("Paper cannot be attached yet! Use the scissors to cut it loose first.");
            return false;
        }

        Debug.Log("Paper successfully validated and snapped into the frame!");
        return true;
    }
}