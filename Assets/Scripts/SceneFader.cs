using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    public void FadeAndLoadScene(string sceneName)
    {
        StartCoroutine(FadeOutIn(sceneName));
    }

    IEnumerator FadeOutIn(string sceneName)
    {
        // Fade to black
        yield return StartCoroutine(Fade(0f, 1f));

        // Load the scene
        SceneManager.LoadScene(sceneName);

        // Wait one frame to allow scene to load
        yield return null;

        // Find the new fade image (assumes same setup in new scene)
        Image newFadeImage = GameObject.Find("FadeOverlay").GetComponent<Image>();
        newFadeImage.color = new Color(0, 0, 0, 1f); // Ensure it's black

        // Fade back in
        yield return StartCoroutine(Fade(1f, 0f, newFadeImage));
    }

    IEnumerator Fade(float startAlpha, float endAlpha, Image img = null)
    {
        if (img == null) img = fadeImage;
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float a = Mathf.Lerp(startAlpha, endAlpha, t / fadeDuration);
            img.color = new Color(0, 0, 0, a);
            yield return null;
        }
    }
}
