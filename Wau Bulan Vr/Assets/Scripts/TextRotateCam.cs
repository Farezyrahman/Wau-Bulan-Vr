using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRotateCam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0); // Flip it so the text isn't mirrored
    }
}
