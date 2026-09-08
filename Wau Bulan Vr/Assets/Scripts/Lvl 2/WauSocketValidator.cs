using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Filtering;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class WauSocketValidator : MonoBehaviour, IXRSelectFilter
{
    private XRSocketInteractor socket;

    void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    void OnEnable()
    {
        // Automatically register this script as a select filter when the game starts
        if (socket != null)
        {
            socket.selectFilters.Add(this);
        }
    }

    void OnDisable()
    {
        if (socket != null)
        {
            socket.selectFilters.Remove(this);
        }
    }

    // Required by the IXRSelectFilter interface
    public bool canProcess => true;

    // This function automatically checks the object BEFORE allowing it to snap
    public bool Process(IXRSelectInteractor interactor, IXRSelectInteractable interactable)
    {
        // Look for the BambooBender script on the object trying to snap into the socket
        // It checks the object itself or its children (like the Armature child)
        BambooBender bender = interactable.transform.GetComponentInChildren<BambooBender>();

        if (bender != null)
        {
            if (bender.isFullyBent)
            {
                Debug.Log("Success: Bamboo is fully bent! Allowing socket connection.");
                return true; // ALLOW the object to snap into place
            }
            else
            {
                Debug.Log("Blocked: Cannot attach yet. Move slider to 100% first!");
                return false; // REJECT the object smoothly (it stays in your hand)
            }
        }

        // If something else entirely tries to enter the socket, reject it
        return false;
    }
}