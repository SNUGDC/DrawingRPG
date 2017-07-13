using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_select : MonoBehaviour {
    public void OnContinueButtonClick()
    {
        SceneLoader.LoadProto();
    }
    public void OnStageButtonClick()
    {
        SceneLoader.LoadScene_using_string("Stage_Select");
    }
    public void OnOptionButtonClick()
    {
        SceneLoader.LoadScene_using_string("Option");
    }
    public void OnClickQuit()
    {
        Application.Quit();

    }
    private void Start()
    {
        Screen.SetResolution(600, 1080, true);
    }
}
