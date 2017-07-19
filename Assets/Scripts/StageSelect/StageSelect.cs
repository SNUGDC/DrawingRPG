using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    public GameObject backgroundmusic;
    
    private void Awake()
    {
        DontDestroyOnLoad(backgroundmusic);
    }
    public void OnOptionButtonClick()
    {
        SceneLoader.LoadScene_using_string("Option");
    }
    public void Volume_Control()
    {
        AudioListener.volume = GameObject.Find("BGM_Slider").GetComponent<Slider>().value;
    }
    public void OnClickCredits()
    {
        SceneLoader.LoadScene_using_string("Credits");
    }
    public void OnClickQuit()
    {
        Application.Quit();

    }
    public void OnProtoButton()
    {
        SceneLoader.LoadProto();
    }
    public void OnClickSelect()
    {
        SceneLoader.LoadScene_using_string("Stage_Select");
    }
    public void OnClickMainMenu()
    {
        SceneLoader.LoadScene_using_string("Main_Menu");
        Destroy(GameObject.Find("BGM"));
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