using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static Score instance;
    public TextMeshProUGUI inventoryText;

    // Separate counts for different items
    private int redCrystals = 0;
    private int blueCrystals = 0;
    private int goldCoins = 0;

    void Awake() => instance = this;

    public void CollectItem(ItemType type)
    {
        switch (type)
        {
            case ItemType.RedCrystal: redCrystals++; break;
            case ItemType.BlueCrystal: blueCrystals++; break;
            case ItemType.GoldCoin: goldCoins++; break;
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        inventoryText.text = $"Kertas: {redCrystals} | Buluh: {blueCrystals} | Tali: {goldCoins}";
    }

    public bool IsQuestFinished()
    {
        // Returns true only if all 3 items are collected
        return (redCrystals >= 1 && blueCrystals >= 1 && goldCoins >= 1);
    }

}

// Define the types outside the class
public enum ItemType { RedCrystal, BlueCrystal, GoldCoin }


