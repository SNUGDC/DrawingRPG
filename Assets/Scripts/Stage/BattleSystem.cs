using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem
{
    public static void Battle(Player player, Enemy enemy)
    {
        enemy.hp -= player.atk;
        if (enemy.hp <= 0)
        {
            GameObject.Destroy(enemy.gameObject);
            return;
        }

        player.hp -= enemy.atk;
        if (player.hp <= 0)
        {
            GameObject.Destroy(player.gameObject);
            Debug.Log("GameOver");
        }
    }
}
