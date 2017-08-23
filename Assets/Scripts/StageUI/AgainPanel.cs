using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgainPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Again()
	{
		SceneLoader.RestartStage();
	}

	public void Back()
	{
		SceneLoader.LoadScene("Stage_Select");
	}
}
