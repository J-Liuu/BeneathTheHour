using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmbitionGameManager : MonoBehaviour
{
    public GameObject introText;
    public GameObject ambitionPrefab;
    public RectTransform spawnArea;
    //public GameObject worthlessGameManager; 

    public float spawnIntervalStart = 1.5f;
    public float spawnIntervalMin = 0.05f;
    public float spawnDecay = 0.92f;
    public int maxAmbitions = 50;

    private int spawnedCount = 0;

    void Start()
    {
        StartCoroutine(PlaySequence());
    }

    IEnumerator PlaySequence()
    {
        yield return new WaitForSeconds(2f);
        introText.SetActive(true);

        yield return new WaitForSeconds(5f);
        introText.SetActive(false);

        yield return StartCoroutine(SpawnAmbitions());

        yield return new WaitForSeconds(2f);

        DespawnAllAmbitions();
        SceneManager.LoadScene("Ending");
        //worthlessGameManager.SetActive(true);
    }

    IEnumerator SpawnAmbitions()
    {
        float currentDelay = spawnIntervalStart;

        while (spawnedCount < maxAmbitions)
        {
            float x = Random.Range(-spawnArea.rect.width / 2f, spawnArea.rect.width / 2f);
            float y = Random.Range(-spawnArea.rect.height / 2f, spawnArea.rect.height / 2f);

            GameObject ambition = Instantiate(ambitionPrefab, spawnArea);
            ambition.tag = "AmbitionText"; // Ensure prefab is tagged
            RectTransform rt = ambition.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(x, y);

            spawnedCount++;
            yield return new WaitForSeconds(currentDelay);
            currentDelay = Mathf.Max(spawnIntervalMin, currentDelay * spawnDecay);
        }
    }

    void DespawnAllAmbitions()
    {
        GameObject[] ambitions = GameObject.FindGameObjectsWithTag("AmbitionText");
        foreach (GameObject a in ambitions)
        {
            Destroy(a);
        }
    }
}
