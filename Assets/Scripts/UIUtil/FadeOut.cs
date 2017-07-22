using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public float duration = 0.2f;
    public Image image;

    public static void particle_fade_out(GameObject one, float duration)
    {
        one.GetComponent<Image>().canvasRenderer.SetAlpha(0);
        one.SetActive(true);
        one.GetComponent<Image>().CrossFadeAlpha(1, duration, true);
    }

    public void StartFadeOut(Action onEnd)
    {
        image.canvasRenderer.SetAlpha(0);
        image.CrossFadeAlpha(1, duration, true);
        StartCoroutine(FadeOutCoroutine(onEnd));
    }

    private IEnumerator FadeOutCoroutine(Action onEnd)
    {
        yield return new WaitForSeconds(duration);
        onEnd();
    }
}
