using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystemForTemp : MonoBehaviour
{
    public static float CheckElement(Element attack, Element damage)
    {
        float IncreasedElementalDamage = 1.2f;
        float DecreasedElementalDamage = 0.8f;
        if (attack == Element.Water)
        {
            if (damage == Element.Earth)
                return DecreasedElementalDamage;
            else if (damage == Element.Fire)
                return IncreasedElementalDamage;
            else
                return 1.0f;
        }
        else if (attack == Element.Fire)
        {
            if (damage == Element.Water)
                return DecreasedElementalDamage;
            else if (damage == Element.Metal)
                return IncreasedElementalDamage;
            else
                return 1.0f;
        }
        else if (attack == Element.Metal)
        {
            if (damage == Element.Fire)
                return DecreasedElementalDamage;
            else if (damage == Element.Wood)
                return IncreasedElementalDamage;
            else
                return 1.0f;
        }
        else if (attack == Element.Wood)
        {
            if (damage == Element.Metal)
                return DecreasedElementalDamage;
            else if (damage == Element.Earth)
                return IncreasedElementalDamage;
            else
                return 1.0f;
        }
        else if (attack == Element.Earth)
        {
            if (damage == Element.Wood)
                return DecreasedElementalDamage;
            else if (damage == Element.Water)
                return IncreasedElementalDamage;
            else
                return 1.0f;
        }
        else
            return 1.0f;

    }

    public static void AttackEnemy(GameObject player, GameObject enemy)
    {
        PlayerStatus playerStatus = player.gameObject.GetComponent<PlayerStatus>();
        EnemyStatus enemyStatus = enemy.gameObject.GetComponent<EnemyStatus>();
        enemyStatus.hp -= (int)(playerStatus.atk * CheckElement(playerStatus.element, enemyStatus.element));
    }

    public static void AttackPlayer(GameObject player, GameObject enemy)
    {
        PlayerStatus playerStatus = player.gameObject.GetComponent<PlayerStatus>();
        EnemyStatus enemyStatus = enemy.gameObject.GetComponent<EnemyStatus>();
        playerStatus.hp -= (int)(enemyStatus.atk * CheckElement(enemyStatus.element, playerStatus.element));
    }

    public static void DestroyDeadCharacter(GameObject player, GameObject enemy)
    {
        PlayerStatus playerStatus = player.gameObject.GetComponent<PlayerStatus>();
        EnemyStatus enemyStatus = enemy.gameObject.GetComponent<EnemyStatus>();

        if (playerStatus.hp <= 0)
        {
            GameObject.Destroy(player.gameObject);
        }

        if (enemyStatus.hp <= 0)
        {
            GameObject.Destroy(enemy.gameObject);
        }
    }


    public static void Battle(GameObject player, GameObject enemy)
    {
        AttackEnemy(player, enemy);
        AttackPlayer(player, enemy);
        DestroyDeadCharacter(player, enemy);
    }
}