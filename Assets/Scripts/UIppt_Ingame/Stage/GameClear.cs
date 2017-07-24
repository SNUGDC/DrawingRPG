using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour {
    
    public static void cleard(Player player)
    {
        FadeOut.particle_fade_out(player.Black, 1.0f);
        FadeOut.particle_fade_out(player.Clear, 3.0f);
        //player.Next_Stage.SetActive(true);
        player.Move_Battle_Panel.SetActive(false);
    }

    public static void game_Over(Player player)
    {
        FadeOut.particle_fade_out(player.Black, 1.0f);
        FadeOut.particle_fade_out(player.Fail, 3.0f);
        player.Again_Stage.SetActive(true);
        player.Move_Battle_Panel.SetActive(false);
    }
}
