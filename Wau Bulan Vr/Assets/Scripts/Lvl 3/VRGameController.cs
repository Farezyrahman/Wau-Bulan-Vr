using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;

public class VRGameController : MonoBehaviour
{
    public static bool isGameStarted = false;

    [Header("References")]
    [SerializeField] private GameObject xrOrigin;

    // We will find these on your XR Origin automatically
    private ContinuousMoveProvider continuousMove;
    private ContinuousTurnProvider continuousTurn;
    private SnapTurnProvider snapTurn;

    private void Start()
    {
        if (xrOrigin != null)
        {
            // Find the movement and turning components on the XR Origin
            continuousMove = xrOrigin.GetComponentInChildren<ContinuousMoveProvider>();
            continuousTurn = xrOrigin.GetComponentInChildren<ContinuousTurnProvider>();
            snapTurn = xrOrigin.GetComponentInChildren<SnapTurnProvider>();
        }
        else
        {
            Debug.LogError("XR Origin is missing from VRGameController script!");
        }
    }

    public void ToggleGameStatus()
    {
        isGameStarted = !isGameStarted;

        if (isGameStarted)
        {
            // --- STATE 1: Player CANNOT move or turn | Control GameObject A ---
            SetPlayerLocomotion(false);
            Debug.Log("Game Active: Player frozen completely | Control shifted to Wau.");
        }
        else
        {
            // --- STATE 2: Player CAN move and turn | GameObject A is frozen ---
            SetPlayerLocomotion(true);
            Debug.Log("Game Paused: Player locomotion restored | Control disabled for Wau.");
        }
    }

    private void SetPlayerLocomotion(bool isEnabled)
    {
        // Turn walking on/off
        if (continuousMove != null) continuousMove.enabled = isEnabled;

        // Turn smooth turning on/off (if you use it)
        if (continuousTurn != null) continuousTurn.enabled = isEnabled;

        // Turn snap turning on/off (if you use it)
        if (snapTurn != null) snapTurn.enabled = isEnabled;
    }
}