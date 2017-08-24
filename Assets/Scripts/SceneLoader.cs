using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    private static bool sceneLoadSetup = false;
    public static void LoadPreStage(int stage)
    {
        LoadScene("pre_Stage" + stage);
    }
    public static void LoadStage(int stage)
    {
        LoadScene("Stage" + stage);
    }

    public static void RestartStage()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        LoadScene(sceneName);
    }

    public static void LoadPostStage()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        // Stage1 -> 1
        int stage = int.Parse(sceneName.Substring(5));
        Debug.Log("Clear stage " + stage);

        int lastClearedStage = SaveManager.LoadLastClearedStage();
		if (stage > lastClearedStage) {
			SaveManager.SaveLastClearedStage(stage);
		}
        
        LoadScene("post_" + sceneName);
    }

    public static void LoadScene(string sceneName)
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
