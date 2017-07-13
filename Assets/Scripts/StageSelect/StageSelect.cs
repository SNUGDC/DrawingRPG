using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    public void OnClickQuit()
    {
        Application.Quit();

    }
    public void OnProtoButton()
    {
        SceneLoader.LoadProto();
    }

    public void OnClickMainMenu()
    {
        SceneLoader.LoadScene_using_string("Main_Menu");
    }

    public void OnStageButtonClick(int stage)
    {
        SceneLoader.LoadStage(stage);
    }

    public void OnClearAllButtonClick()
    {
        SaveManager.ClearAllStage();
        SceneLoader.LoadStageSelect();
    }

    public void OnLockAllButtonClick()
    {
        SaveManager.ResetSave();
        SceneLoader.LoadStageSelect();
    }

    private void Start()
    {
        Screen.SetResolution(360, 640, false);
    }
}