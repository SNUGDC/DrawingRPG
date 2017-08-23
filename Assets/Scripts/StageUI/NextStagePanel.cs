using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStagePanel : MonoBehaviour
{
    public void Next()
    {
		SceneLoader.LoadPostStage();
    }

    public void Back()
    {
		SceneLoader.LoadPostStage();
    }
}
