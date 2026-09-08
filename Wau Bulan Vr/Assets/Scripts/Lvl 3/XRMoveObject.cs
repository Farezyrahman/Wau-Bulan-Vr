using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class XRMoveObject : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField] private InputActionProperty leftHandJoystick;
    [SerializeField] private InputActionProperty rightHandJoystick;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float verticalSpeed = 4f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Stop entirely if the game hasn't started yet
        if (!VRGameController.isGameStarted)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        // 1. Read Left Joystick values (Forward/Backward, Left/Right)
        Vector2 leftInput = leftHandJoystick.action.ReadValue<Vector2>();

        // 2. Read Right Joystick values (Up/Down)
        Vector2 rightInput = rightHandJoystick.action.ReadValue<Vector2>();

        // 3. Combine them into 3D directions:
        // X = Left/Right (Inverted)
        // Y = Up/Down (Normal)
        // Z = Forward/Backward (FIXED: Added '-' to invert the Z-axis push)
        float moveX = -leftInput.x * moveSpeed;
        float moveY = rightInput.y * verticalSpeed;
        float moveZ = -leftInput.y * moveSpeed;

        // 4. Apply the calculated movement smoothly via physics velocity
        rb.velocity = new Vector3(moveX, moveY, moveZ);
    }
}