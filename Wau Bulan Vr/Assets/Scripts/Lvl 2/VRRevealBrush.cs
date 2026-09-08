using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRRevealBrush : MonoBehaviour
{
    [Header("Pen Settings")]
    public Transform tip;
    public int brushSize = 10;
    public float maxDrawDistance = 0.05f;
    public Color hiddenColor = Color.white; // The "scratch-off" layer color

    [Header("Raycast Settings")]
    public LayerMask drawingLayer;

    [Header("Paper Reference")]
    [Tooltip("Drag your Paper GameObject here so it turns white instantly on Start!")]
    public Renderer paperRenderer;

    // --- ADDED FOR SINGLE SOCKET CHECK ---
    [Header("Crafting Status")]
    public bool isDoneBrushing = false;
    // -------------------------------------

    private Texture2D activeTexture;
    private Texture2D originalTexture;
    private Vector2 lastVisualUV;
    private bool isDrawingLastFrame = false;
    private bool isInitialized = false;

    void Start()
    {
        if (paperRenderer != null)
        {
            InitializeTextures(paperRenderer);
        }
    }

    void Update()
    {
        Reveal();
    }

    void Reveal()
    {
        RaycastHit hit;
        if (Physics.Raycast(tip.position, tip.forward, out hit, maxDrawDistance, drawingLayer))
        {
            if (paperRenderer == null)
            {
                paperRenderer = hit.collider.GetComponent<Renderer>();
                if (paperRenderer == null) return;
            }

            if (!isInitialized)
            {
                InitializeTextures(paperRenderer);
            }

            Vector2 uv = hit.textureCoord;
            int x = (int)(uv.x * activeTexture.width);
            int y = (int)(uv.y * activeTexture.height);

            EraseCircle(x, y);

            if (isDrawingLastFrame)
            {
                InterpolateErase(lastVisualUV, uv);
            }

            activeTexture.Apply();

            lastVisualUV = uv;
            isDrawingLastFrame = true;

            // --- TRACK PROGRESS ---
            // If the player actively uses the brush on the target layer, mark brushing complete!
            isDoneBrushing = true;
            // -----------------------
        }
        else
        {
            isDrawingLastFrame = false;
        }
    }

    void InitializeTextures(Renderer renderer)
    {
        Texture2D textureOnMaterial = renderer.material.mainTexture as Texture2D;

        if (textureOnMaterial == null)
        {
            Debug.LogError("Please assign a texture to the Paper Material in the inspector first!");
            return;
        }

        originalTexture = textureOnMaterial;
        activeTexture = new Texture2D(originalTexture.width, originalTexture.height);

        Color[] pixels = new Color[activeTexture.width * activeTexture.height];
        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = hiddenColor;
        }

        activeTexture.SetPixels(pixels);
        activeTexture.Apply();

        renderer.material.mainTexture = activeTexture;
        isInitialized = true;
    }

    void EraseCircle(int cx, int cy)
    {
        for (int x = -brushSize; x <= brushSize; x++)
        {
            for (int y = -brushSize; y <= brushSize; y++)
            {
                if (x * x + y * y <= brushSize * brushSize)
                {
                    int resX = cx + x;
                    int resY = cy + y;

                    if (resX >= 0 && resX < activeTexture.width && resY >= 0 && resY < activeTexture.height)
                    {
                        Color originalPixel = originalTexture.GetPixel(resX, resY);
                        activeTexture.SetPixel(resX, resY, originalPixel);
                    }
                }
            }
        }
    }

    void InterpolateErase(Vector2 startUV, Vector2 endUV)
    {
        float distance = Vector2.Distance(startUV, endUV);
        int steps = Mathf.CeilToInt(distance * activeTexture.width / (brushSize * 0.5f));

        for (int i = 0; i < steps; i++)
        {
            float t = (float)i / steps;
            Vector2 lerpUV = Vector2.Lerp(startUV, endUV, t);
            int x = (int)(lerpUV.x * activeTexture.width);
            int y = (int)(lerpUV.y * activeTexture.height);
            EraseCircle(x, y);
        }
    }
}