using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StayAwakeGame : MonoBehaviour
{
    public Image fadeOverlay;
    public Button stayAwakeButton;

    public float fadeSpeed = 0.2f;
    public float resetFadeSpeed = 0.5f;
    public string nextSceneName = "NextScene"; // <-- Set this in Inspector

    private float currentAlpha = 0f;
    private bool isFading = false;
    private int clickCount = 0;

    void OnEnable()
    {
        currentAlpha = 0f;
        fadeOverlay.color = new Color(0, 0, 0, currentAlpha);
        stayAwakeButton.gameObject.SetActive(false);
        stayAwakeButton.onClick.RemoveAllListeners();
        stayAwakeButton.onClick.AddListener(OnButtonClick);
        isFading = true;
        clickCount = 0;
    }

    void Update()
    {
        if (!isFading) return;

        currentAlpha += fadeSpeed * Time.deltaTime;
        currentAlpha = Mathf.Clamp01(currentAlpha);
        fadeOverlay.color = new Color(0, 0, 0, currentAlpha);

        if (currentAlpha >= 0.5f)
        {
            stayAwakeButton.gameObject.SetActive(true);
        }

        if (currentAlpha >= 1f)
        {
            Debug.Log("You fell asleep!");
            isFading = false;
            // Optional: show game over screen here
        }
    }

    void OnButtonClick()
    {
        stayAwakeButton.gameObject.SetActive(false);
        isFading = false;
        clickCount++;

        if (clickCount >= 4)
        {
            SceneManager.LoadScene(nextSceneName);
            return;
        }

        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        while (currentAlpha > 0f)
        {
            currentAlpha -= resetFadeSpeed * Time.deltaTime;
            currentAlpha = Mathf.Clamp01(currentAlpha);
            fadeOverlay.color = new Color(0, 0, 0, currentAlpha);
            yield return null;
        }

        isFading = true;
    }
}
