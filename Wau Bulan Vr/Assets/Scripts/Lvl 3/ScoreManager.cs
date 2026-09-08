using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Required for TextMesh Pro

public class ScoreManager : MonoBehaviour
{
    [Header("UI Reference")]
    [SerializeField] private TextMeshProUGUI scoreText; // For UI Canvas, use TextMeshPro for 3D world text

    [Header("Setup")]
    [SerializeField] private string Wau = "Wau"; // Only destroy objects with this tag

    // CHANGED: "static" means ALL copies of this script share this ONE variable
    private static int currentScore = 0;

    private void Start()
    {
        UpdateScoreUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the collider has the correct tag
        if (other.CompareTag(Wau))
        {
            // Add points BEFORE destroying this script's object
            AddPoint();

            // Destroy THIS object (the scoring zone), not the one that entered
            Destroy(gameObject);
        }
    }

    private void AddPoint()
    {
        currentScore += 1;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
        else
        {
            Debug.LogWarning("Score Text reference is missing on " + gameObject.name);
        }
    }
}