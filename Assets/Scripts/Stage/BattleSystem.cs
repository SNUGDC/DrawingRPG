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
        int IncreasedElementalDamage = 1;
        int DecreasedElemnetalDamage = 1;

        //player 공격phase
        enemy.hp -= player.atk;

        enemyIndex = element.IndexOf(enemy.element);
        Debug.Log("적인덱스" + enemyIndex);
        playerIndex = element.IndexOf(player.element);
        Debug.Log("플레이어인덱스" + playerIndex);
        if (playerIndex + 1 == enemyIndex || (playerIndex == 4 && enemyIndex == 0))
        {
            enemy.hp -= IncreasedElementalDamage;
            Debug.Log("속성추가대미지" + 1);
        }

        else if (playerIndex - 1 == enemyIndex || (playerIndex == 0 && enemyIndex == 4))
        {
            enemy.hp += DecreasedElemnetalDamage;
            Debug.Log("속성감소대미지" + enemy.hp);
        }
        Debug.Log("플레이어 공격턴 끝 적 남은체력"+ enemy.hp);

        //enemy 사망 check
        if (enemy.hp <= 0)
        {
            GameObject.Destroy(enemy.gameObject);
            return;
        }

        //enemy 공격phase
        player.hp -= enemy.atk;

        if (enemyIndex + 1 == playerIndex || (enemyIndex == 4 && playerIndex == 0))
        {
            player.hp -= IncreasedElementalDamage;
            Debug.Log("속성추가대미지");
        }

        else if (enemyIndex - 1 == playerIndex || (enemyIndex == 0 && playerIndex == 4))
        {
            player.hp += DecreasedElemnetalDamage;
            Debug.Log("속성감소대미지");
        }
        Debug.Log("적공격끝 플레이어 남은체력" + player.hp);

        //player 사망 check
        if (player.hp <= 0)
        {
            GameObject.Destroy(player.gameObject);
            Debug.Log("GameOver");
        }
    }
}