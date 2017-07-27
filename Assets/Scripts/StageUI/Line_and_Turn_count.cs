using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Line_and_Turn_count : MonoBehaviour {
    
    public static void LineCounting(LineDrawer LineDrawer, MaxLine_Turn maxline, Text text)
    {
        text.text = LineDrawer.used_line_count + "/" + maxline.MaxLine;
    }
    public static void TurnCounting(Player player, MaxLine_Turn maxturn, Text text)
    {
        if (player.moveCount > maxturn.MaxTurn && player.isClear == false)
        {
            GameClear.GameOver();
        }
        text.text = player.moveCount + "/" + maxturn.MaxTurn;
    }
}
