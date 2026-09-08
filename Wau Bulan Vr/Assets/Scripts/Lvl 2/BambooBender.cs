using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class BambooBender : MonoBehaviour
{
    public Slider bendSlider;
    public Transform[] bones;
    public float maxBendAngle = 15f;

    // This will tell the socket if the bamboo is ready
    public bool isFullyBent { get; private set; }

    void Start()
    {
        if (bendSlider != null)
        {
            bendSlider.onValueChanged.RemoveListener(ApplyBend); // Avoid duplicate listeners
            bendSlider.onValueChanged.AddListener(ApplyBend);

            // Initialize the state based on the current slider value
            ApplyBend(bendSlider.value);
        }
    }

    void ApplyBend(float sliderValue)
    {
        float currentAngle = sliderValue * maxBendAngle;

        if (bones != null)
        {
            foreach (Transform bone in bones)
            {
                if (bone != null)
                    bone.localRotation = Quaternion.Euler(currentAngle, 0, 0);
            }
        }

        // Check if the slider is at maximum limit (assuming slider max is 1.0)
        isFullyBent = (sliderValue >= 0.99f);
    }
}