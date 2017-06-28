using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public static int? currentStage = null;
    public int stage;
    void Awake()
    {
        if (stage <= 0)
        {
			Debug.LogError("Invalid stage");
			return;
        }

		currentStage = stage;
    }

	public void MoveNextStage()
	{
		SceneLoader.LoadStage(stage + 1);
	}

	public void MoveToStageSelect()
	{
		SceneLoader.LoadStageSelect();
	}
}
