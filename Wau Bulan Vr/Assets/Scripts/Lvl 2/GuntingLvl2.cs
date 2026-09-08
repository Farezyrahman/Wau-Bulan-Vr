using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    private Animator Gunting;
    public bool isAnimating = false;

    void Start()
    {
        Gunting = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // 1. Check if GameObject C collided with GameObject B (Tagged "Wau")
        if (other.CompareTag("Wau") && !isAnimating)
        {
            isAnimating = true;
            Gunting.SetBool("Gunting", true);

            // 2. Handle the detachment and physics of GameObject B
            DetachAndDrop(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wau") && isAnimating)
        {
            isAnimating = false;
            Gunting.SetBool("Gunting", false);
        }
    }

    private void DetachAndDrop(GameObject objB)
    {
        // Disconnect GameObject B from GameObject A (its parent)
        objB.transform.SetParent(null);

        // Get the Rigidbody component on GameObject B
        Rigidbody rb = objB.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Turn off Is Kinematic so physics takes over
            rb.isKinematic = false;
            // Ensure gravity is enabled
            rb.useGravity = true;
        }
        else
        {
            Debug.LogWarning("GameObject B is missing a Rigidbody component!");
        }
    }
}