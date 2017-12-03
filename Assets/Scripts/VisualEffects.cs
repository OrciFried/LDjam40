using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualEffects : MonoBehaviour
{

    [SerializeField]
    float redOnScreenTime = 0.1f;

    [SerializeField]
    GameObject redScreen;

    public void HitEffect()
    {
        StartCoroutine(HitEffectCoroutine());
    }

    IEnumerator HitEffectCoroutine()
    {
        redScreen.SetActive(true);
        yield return new WaitForSecondsRealtime(redOnScreenTime);
        redScreen.SetActive(false);
    }

}
