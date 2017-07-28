using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    private static bool sceneLoadSetup = false;
    public static void LoadStage(int stage)
    {
        LoadScene("Stage" + stage);
    }
    
    public static void LoadScene_using_string(string scene)
    {
        LoadScene(scene);
    }
    

    private static void LoadScene(string sceneName)
    {
        if (sceneLoadSetup == false)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            sceneLoadSetup = true;
        }

        GameObject fadeOutPrefab = Resources.Load("FadeOut") as GameObject;
        GameObject fadeOut = GameObject.Instantiate(fadeOutPrefab) as GameObject;
        fadeOut.GetComponent<FadeOut>().StartFadeOut(() =>
        {
            SceneManager.LoadScene(sceneName);
        });
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject fadeInPrefab = Resources.Load("FadeIn") as GameObject;
        GameObject fadeIn = GameObject.Instantiate(fadeInPrefab) as GameObject;
        fadeIn.GetComponent<FadeIn>().StartFadeIn();
    }
}
