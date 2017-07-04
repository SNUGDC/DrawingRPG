using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public int stage;
    void Awake()
    {
        if (stage <= 0)
        {
			Debug.LogError("Invalid stage");
			return;
        }
    }
	public void MoveNextStage()
	{
		int lastClearedStage = SaveManager.LoadLastClearedStage();
		if (stage > lastClearedStage) {
			SaveManager.SaveLastClearedStage(stage);
		}
		SceneLoader.LoadStage(stage + 1);
	}

	public void MoveToStageSelect()
	{
		SceneLoader.LoadStageSelect();
	}

    
}
