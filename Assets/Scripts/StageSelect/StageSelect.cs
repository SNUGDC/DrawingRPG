﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour {
	public void OnStageButtonClick(int stage)
	{
		SceneLoader.LoadStage(stage);
	}
}
