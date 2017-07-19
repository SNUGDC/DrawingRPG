using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem
{

    public static void Battle(Player player, Enemy enemy)
    {
        List<string> element = new List<string>() { "water", "fire", "gold", "wood", "earth" };
        int enemyIndex;
        int playerIndex;
        float IncreasedElementalDamage = 1.2f;
        float DecreasedElementalDamage = 0.8f;

        //player 공격phase
        enemyIndex = element.IndexOf(enemy.element);
        playerIndex = element.IndexOf(player.element);
        if (playerIndex + 1 == enemyIndex || (playerIndex == 4 && enemyIndex == 0))
        {
            enemy.hp -= (int)(player.atk * IncreasedElementalDamage);
        }
        else if (playerIndex - 1 == enemyIndex || (playerIndex == 0 && enemyIndex == 4))
        {
            enemy.hp -= (int)(player.atk * DecreasedElementalDamage);
        }  
        else
        {
            enemy.hp -= player.atk;
        }

        //enemy 사망 check
        if (enemy.hp <= 0)
        {
            GameObject.Destroy(enemy.gameObject);
            return;
        }

        //enemy 공격phase
        if (enemyIndex + 1 == playerIndex || (enemyIndex == 4 && playerIndex == 0))
        {
            player.hp -= (int)(enemy.atk*IncreasedElementalDamage);
        }
        else if (enemyIndex - 1 == playerIndex || (enemyIndex == 0 && playerIndex == 4))
        {
            player.hp -= (int)(enemy.atk*DecreasedElementalDamage);
        }
        else
        {
            player.hp -= enemy.atk;
        }
        
        //player 사망 check
        if (player.hp <= 0)
        {
            GameObject.Destroy(player.gameObject);
            Debug.Log("GameOver");
        }
    }
}