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
    public void Volume_Control()
    {
        AudioListener.volume = GameObject.Find("BGM_Slider").GetComponent<Slider>().value;
    }
    private void Start()
    {
        Screen.SetResolution(360, 640, false);
    }
}