using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour {
    
    public static void Cleard(Player player)
    {
        FadeOut.particleFadeOut(player.Black, 1.0f);
        FadeOut.particleFadeOut(player.Clear, 3.0f);
        //player.Next_Stage.SetActive(true);
        player.MoveBattlePanel.SetActive(false);
    }

    public static void GameOver(Player player)
    {
        FadeOut.particleFadeOut(player.Black, 1.0f);
        FadeOut.particleFadeOut(player.Fail, 3.0f);
        player.AgainStage.SetActive(true);
        player.MoveBattlePanel.SetActive(false);
    }
}
