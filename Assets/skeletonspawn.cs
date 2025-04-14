using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonspawn : MonoBehaviour
{
    public GameObject skeleton;
    public float delay = 4f;

    void Start()
    {
        StartCoroutine(DelayedReveal());
    }

    IEnumerator DelayedReveal()
    {
        yield return new WaitForSeconds(delay);
        skeleton.SetActive(true);
    }
}
