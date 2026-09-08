using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRPhysicsButton : MonoBehaviour
{
    [Header("Button Parts")]
    [SerializeField] private Transform buttonTop;   // The moving part of the button
    [SerializeField] private Transform upperLimit;  // Unpressed (starting) local position
    [SerializeField] private Transform lowerLimit;  // Fully pressed local position

    [Header("Settings")]
    [Range(0f, 1f)]
    [SerializeField] private float threshold = 0.5f; // Activation point between limits
    [SerializeField] private float returnForce = 10f; // Spring force pushing it back out

    [Header("Events")]
    public UnityEvent onPressed;
    public UnityEvent onReleased;

    private float totalTravelDistance;
    private bool isPressed = false;
    private bool previousPressState = false;

    void Start()
    {
        // 1. Ignore physical collision between the button frame/base and the moving top
        Collider baseCollider = GetComponent<Collider>();
        Collider topCollider = buttonTop.GetComponent<Collider>();
        if (baseCollider != null && topCollider != null)
        {
            Physics.IgnoreCollision(baseCollider, topCollider);
        }

        // 2. Calculate the maximum travel distance along the X-axis
        totalTravelDistance = Mathf.Abs(upperLimit.localPosition.x - lowerLimit.localPosition.x);
    }

    void FixedUpdate()
    {
        // 3. Keep the button strictly locked onto the local X-axis (prevent Y and Z shifting)
        Vector3 clampedPosition = buttonTop.localPosition;
        clampedPosition.y = upperLimit.localPosition.y;
        clampedPosition.z = upperLimit.localPosition.z;

        // Don't let it push past the upper limit on X
        if (clampedPosition.x > upperLimit.localPosition.x)
            clampedPosition.x = upperLimit.localPosition.x;

        // Don't let it go past the lower limit on X
        if (clampedPosition.x < lowerLimit.localPosition.x)
            clampedPosition.x = lowerLimit.localPosition.x;

        buttonTop.localPosition = clampedPosition;

        // 4. Apply spring return force if it's not resting at the upper limit
        if (buttonTop.localPosition.x < upperLimit.localPosition.x)
        {
            Rigidbody topRb = buttonTop.GetComponent<Rigidbody>();
            if (topRb != null)
            {
                // Push rightward along the local X-axis to return to start
                topRb.AddForce(buttonTop.transform.right * returnForce * Time.fixedDeltaTime, ForceMode.VelocityChange);
            }
        }

        // 5. Calculate press state based on current X distance to the lower limit
        float currentDistanceToLower = Mathf.Abs(buttonTop.localPosition.x - lowerLimit.localPosition.x);

        // If it gets close enough to the lower limit, register the press
        if (currentDistanceToLower < (totalTravelDistance * threshold))
        {
            isPressed = true;
        }
        else
        {
            isPressed = false;
        }

        // 6. Safeguard to only trigger the Unity Event ONCE per click
        if (isPressed && !previousPressState)
        {
            previousPressState = true;
            onPressed.Invoke();
            Debug.Log("VR Button Pressed!");
        }
        else if (!isPressed && previousPressState)
        {
            previousPressState = false;
            onReleased.Invoke();
        }
    }
}