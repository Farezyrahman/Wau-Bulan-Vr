using UnityEngine;

public class WindZoneEffect : MonoBehaviour
{
    [Header("Wind Settings")]
    [SerializeField] private float windStrength = 10f;

    private void OnTriggerStay(Collider other)
    {
        // Don't blow wind if the game hasn't started
        if (!VRGameController.isGameStarted) return;

        // Check if the object entering the zone is tagged "Wau"
        if (other.CompareTag("Wau"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // FORCE: Wake up the rigidbody so it listens to the trigger forces
                if (rb.IsSleeping())
                {
                    rb.WakeUp();
                }

                // transform.forward pushes along the local Z-Axis of this Windzone cube
                Vector3 windDirection = transform.forward;

                // Applies a constant physics push
                rb.AddForce(windDirection * windStrength, ForceMode.Force);
            }
        }
    }
}