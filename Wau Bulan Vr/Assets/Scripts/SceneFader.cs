using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public CanvasGroup fadeGroup;
    public float fadeSpeed = 1.5f;

    public void FadeToLevel(string Level_2)
    {
        StartCoroutine(FadeOut(Level_2));
    }

    IEnumerator FadeOut(string Level_2)
    {
        while (fadeGroup.alpha < 1)
        {
            fadeGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }
        SceneManager.LoadScene(Level_2);
    }
}