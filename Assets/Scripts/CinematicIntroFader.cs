using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CinematicIntroFader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;
    public float delayBeforeFadeOut = 4f;
    public string nextSceneName = "MainScene";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayIntro());
    }
    IEnumerator PlayIntro()
    {
        // Start fully black → fade in
        yield return StartCoroutine(Fade(1f, 0f));

        // Wait during intro
        yield return new WaitForSeconds(delayBeforeFadeOut);

        // Fade out
        yield return StartCoroutine(Fade(0f, 1f));

        // Load next scene
        SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator Fade(float from, float to)
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float a = Mathf.Lerp(from, to, t / fadeDuration);
            fadeImage.color = new Color(0f, 0f, 0f, a);
            yield return null;
        }

        fadeImage.color = new Color(0f, 0f, 0f, to);
    }
}
