﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    // --------------씬 전환 Button--------------//
    public void MainMenuScene()
    {
        SceneLoader.LoadScene_using_string("Main_Menu");
    }
    public void OptionScene()
    {
        SceneLoader.LoadScene_using_string("Option");
    }
    public void StageSelectScene()
    {
        SceneLoader.LoadScene_using_string("Stage_Select");
    }
    public void StageScene(int stage)
    {
        SceneLoader.LoadStage(stage);
    }
    public void CreditsScene()
    {
        SceneLoader.LoadScene_using_string("Credits");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void OnClearAllButtonClick()
    {
        SaveManager.ClearAllStage();
        StageSelectScene();
    }
    public void OnLockAllButtonClick()
    {
        SaveManager.ResetSave();
        StageSelectScene();
    }

 
    // --------------게임 내 상태 조작 Button------------//
   
    //라인 그리고 난 후 스타트
    public void StartGame(GameObject startButton)
    {
        Destroy(startButton);
    }
    public void StartGameStartUI(GameObject startUI)
    {
        Instantiate(startUI);
    }

}
