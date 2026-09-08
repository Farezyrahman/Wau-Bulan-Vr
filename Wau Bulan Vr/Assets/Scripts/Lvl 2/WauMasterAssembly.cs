using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.SceneManagement;

public class WauMasterAssembly : MonoBehaviour
{
    private XRSocketInteractor assemblySocket;

    [Header("Visual Model Elements to Activate")]
    [Tooltip("Assign your 6 hidden structural visual Lidi components here in order")]
    public GameObject[] visualLidiParts = new GameObject[6];
    [Tooltip("Assign your hidden visual main Wau paper mesh component here")]
    public GameObject visualPaperPart;

    [Header("Tool/Script References")]
    public VRRevealBrush brushScript;

    [Header("Scene Progression")]
    public string nextSceneName = "Level 3";
    public float delayBeforeTransition = 2.5f;

    private int currentLidiIndex = 0;
    private bool isPaperAssembled = false;
    private bool isTransitioning = false;

    void Awake()
    {
        assemblySocket = GetComponent<XRSocketInteractor>();
    }

    void OnEnable()
    {
        if (assemblySocket != null)
            assemblySocket.selectEntered.AddListener(OnItemPlacedInSocket);
    }

    void OnDisable()
    {
        if (assemblySocket != null)
            assemblySocket.selectEntered.RemoveListener(OnItemPlacedInSocket);
    }

    private void OnItemPlacedInSocket(SelectEnterEventArgs args)
    {
        GameObject placedObject = args.interactableObject.transform.gameObject;

        // --- CHECKING FOR BAMBOO LIDI ---
        BambooBender bender = placedObject.GetComponentInChildren<BambooBender>();
        if (bender != null)
        {
            if (bender.isFullyBent)
            {
                if (currentLidiIndex < visualLidiParts.Length)
                {
                    // Activate the corresponding visual piece step-by-step
                    if (visualLidiParts[currentLidiIndex] != null)
                    {
                        visualLidiParts[currentLidiIndex].SetActive(true);
                        Debug.Log($"Lidi parts activated: {currentLidiIndex + 1}/6");
                        currentLidiIndex++;
                    }

                    // Delete the grabbable physical prop from the table slot
                    StartCoroutine(ConsumePlacedItem(placedObject));
                }
            }
            else
            {
                Debug.Log("Cannot assembly: This bamboo lidi strip must be bent to 100% limit first!");
            }
            return; // Finished checking bamboo
        }

        // --- CHECKING FOR WAUPAPER ---
        if (placedObject.CompareTag("Wau"))
        {
            // 1. Verifies if scissors Cut it loose (Gunting script resets parent to null)
            bool isCutLoose = placedObject.transform.parent == null;

            // 2. Verifies if brush tool scratched off the cover layer
            bool isScratched = brushScript != null && brushScript.isDoneBrushing;

            if (isCutLoose && isScratched)
            {
                if (!isPaperAssembled)
                {
                    if (visualPaperPart != null)
                    {
                        visualPaperPart.SetActive(true);
                        Debug.Log("Wau Bulan pattern cover paper perfectly applied!");
                        isPaperAssembled = true;
                    }

                    StartCoroutine(ConsumePlacedItem(placedObject));
                }
            }
            else
            {
                Debug.Log("The paper must be fully scratched off AND cut loose with the scissors tool first!");
            }
        }
    }

    private IEnumerator ConsumePlacedItem(GameObject item)
    {
        yield return new WaitForEndOfFrame();

        // Disconnect XR Tracking safe states
        if (assemblySocket.hasSelection)
        {
            assemblySocket.interactionManager.SelectExit(assemblySocket, assemblySocket.hasSelection ? assemblySocket.interactablesSelected[0] : null);
        }

        // Delete the loose world object
        Destroy(item);

        // Evaluate level completion states
        CheckCompletionStatus();
    }

    private void CheckCompletionStatus()
    {
        if (currentLidiIndex >= 6 && isPaperAssembled && !isTransitioning)
        {
            isTransitioning = true;
            StartCoroutine(LoadNextLevelScene());
        }
    }

    private IEnumerator LoadNextLevelScene()
    {
        yield return new WaitForSeconds(delayBeforeTransition);
        SceneManager.LoadScene(nextSceneName);
    }
}