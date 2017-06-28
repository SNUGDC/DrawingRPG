using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float duration = 0.2f;
    public Image image;

    public void StartFadeIn()
    {
        image.CrossFadeAlpha(0, duration, true);
        Invoke("DestroyThis", duration);
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
