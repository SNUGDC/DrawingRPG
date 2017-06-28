using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public float duration = 0.2f;
    public Image image;

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
