using UnityEngine;
using UnityEngine.UI;

public class VRSliderPhysical : MonoBehaviour
{
    public Slider slider;
    public Transform handle;

    void Update()
    {
        // Calculate the percentage of the handle's position relative to the slider width
        // Assumes handle moves from local X -50 to +50
        float minX = -50f;
        float maxX = 50f;

        float normalizedValue = Mathf.InverseLerp(minX, maxX, handle.localPosition.x);
        slider.value = normalizedValue;
    }
}