using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DayTextManager : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject minigameManager;

    void Start()
    {
        minigameManager.SetActive(false);
        StartCoroutine(ShowTexts());
    }

    IEnumerator ShowTexts()
    {
        yield return new WaitForSeconds(1f); // Delay after scene loads

        text1.SetActive(true);
        yield return new WaitForSeconds(3f);

        text1.SetActive(false);
        text2.SetActive(true);
        yield return new WaitForSeconds(3f);

        text2.SetActive(false);

        minigameManager.SetActive(true);
    }
}
