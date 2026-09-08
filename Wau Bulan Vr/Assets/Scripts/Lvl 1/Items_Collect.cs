using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class Items_Collect : MonoBehaviour
{
    // You can reference an Inventory Manager here
    public ItemType type;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object touching this is the VR Player/Hand
        if (other.CompareTag("Player") || other.CompareTag("GameController"))
        {
            Score.instance.CollectItem(type);

            // Optional: Spawn a small particle effect at this position
            // Instantiate(collectEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }

    void Collect()
    {
        // Add logic for inventory or UI updates here
        Debug.Log("Item Collected!");

        // Destroy the object or disable it
        Destroy(gameObject);
    }
}
