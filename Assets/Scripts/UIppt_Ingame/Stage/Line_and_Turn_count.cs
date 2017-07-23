using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Line_and_Turn_count : MonoBehaviour {
    
    public static void Line_Counting(LineDrawer LineDrawer, MaxLine_Turn maxline, Text text)
    {
        text.text = LineDrawer.used_line_count + "/" + maxline.Max_Line;
    }
    public static void Turn_Counting(Player player, MaxLine_Turn maxturn, Text text)
    {
        if (player.move_count > maxturn.Max_Turn && player.is_clear == false)
        {
            GameClear.game_Over(player);
        }
        text.text = player.move_count + "/" + maxturn.Max_Turn;
    }
}
