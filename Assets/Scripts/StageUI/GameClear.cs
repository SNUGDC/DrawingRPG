using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour {
    
    public static void Cleard()
    {
        GameObject Clear = Resources.Load("Clear") as GameObject;
        FadeOut.particleFadeOut(Clear.GetComponent<MissionClearUI>().Black, 1.0f);
        FadeOut.particleFadeOut(Clear.GetComponent<MissionClearUI>().Clear, 3.0f);
        //player.Next_Stage.SetActive(true);
        Clear.GetComponent<MissionClearUI>().NextStage.SetActive(true);
    }

    public static void GameOver()
    {
        GameObject Fail = Resources.Load("Fail") as GameObject;
        FadeOut.particleFadeOut(Fail.GetComponent<MissionFailUI>().Black, 1.0f);
        FadeOut.particleFadeOut(Fail.GetComponent<MissionFailUI>().Fail, 3.0f);
        //player.Next_Stage.SetActive(true);
        Fail.GetComponent<MissionFailUI>().AgainStage.SetActive(true);
    }
}
