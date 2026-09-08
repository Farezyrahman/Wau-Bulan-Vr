using UnityEngine;

public class CanvasDialogueManager : MonoBehaviour
{
    [Header("Dialogue Configuration")]
    [SerializeField] private GameObject[] dialogueLines; // Your TMP objects

    private int currentLineIndex = 0;
    private bool initialized = false;

    void Awake()
    {
        ResetAndInitializeDialogue();
    }

    void Start()
    {
        if (!initialized)
        {
            ResetAndInitializeDialogue();
        }
    }

    private void ResetAndInitializeDialogue()
    {
        if (dialogueLines == null || dialogueLines.Length == 0) return;

        currentLineIndex = 0;

        for (int i = 0; i < dialogueLines.Length; i++)
        {
            if (dialogueLines[i] != null)
            {
                dialogueLines[i].SetActive(i == 0);
            }
        }

        initialized = true;
        Debug.Log("Dialogue systematically reset. Starting at line 0.");
    }

    public void DisplayNextLine()
    {
        if (!initialized || dialogueLines.Length == 0) return;

        // Don't advance if we are already past the last line
        if (currentLineIndex >= dialogueLines.Length) return;

        // Turn OFF current line
        if (dialogueLines[currentLineIndex] != null)
        {
            dialogueLines[currentLineIndex].SetActive(false);
        }

        currentLineIndex++;

        // Turn ON next line if it exists
        if (currentLineIndex < dialogueLines.Length)
        {
            if (dialogueLines[currentLineIndex] != null)
            {
                dialogueLines[currentLineIndex].SetActive(true);
            }
        }
        else
        {
            Debug.Log("End of Dialogue Sequence reached.");
        }
    }

    // New Function for the Previous Button
    public void DisplayPreviousLine()
    {
        if (!initialized || dialogueLines.Length == 0) return;

        // If we are at the very first line, we can't go back further
        if (currentLineIndex <= 0)
        {
            Debug.Log("Already at the first line.");
            return;
        }

        // Turn OFF the current line (if we aren't completely past the end of the array)
        if (currentLineIndex < dialogueLines.Length && dialogueLines[currentLineIndex] != null)
        {
            dialogueLines[currentLineIndex].SetActive(false);
        }

        currentLineIndex--;

        // Turn ON the previous line
        if (dialogueLines[currentLineIndex] != null)
        {
            dialogueLines[currentLineIndex].SetActive(true);
        }

        Debug.Log("Moved back to line index: " + currentLineIndex);
    }
}