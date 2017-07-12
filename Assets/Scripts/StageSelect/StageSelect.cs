using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    public void OnProtoButton()
    {
        SceneLoader.LoadProto();
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
}