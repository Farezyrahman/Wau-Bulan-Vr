using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class NPC_Text : MonoBehaviour
{
    public GameObject uiCanvas; // Drag your Canvas here
    public TextMeshProUGUI npcDialogueText; // Drag the Text component here
    public SceneFader fader;
    public string nextLevelName;


    [Header("Dialogues")]
    public string questIncomplete = "Please collect all 3 items first!";
    public string questComplete = "Great job! Go to the bridge for next level.";

    private void Start()
    {
        if (uiCanvas != null) uiCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UpdateDialogue();
            uiCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiCanvas.SetActive(false);
        }
    }

    void UpdateDialogue()
    {
        // Check if the Score/Inventory Manager has reached the goal
        // Assuming your manager script is named 'Score' or 'InventoryManager'
        if (Score.instance.IsQuestFinished())
        {
            npcDialogueText.text = questComplete;
            // Optional: Trigger a portal or next level logic here

            if (fader != null)
            {
                fader.FadeToLevel(nextLevelName);
            }

        }
        else
        {
            npcDialogueText.text = questIncomplete;
        }
    }

}