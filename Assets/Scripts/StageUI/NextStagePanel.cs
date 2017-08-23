using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStagePanel : MonoBehaviour
{
    public void Next()
    {
        SceneLoader.LoadScene("Stage_Select");
    }

    public void Back()
    {
        SceneLoader.LoadScene("Stage_Select");
    }
}
