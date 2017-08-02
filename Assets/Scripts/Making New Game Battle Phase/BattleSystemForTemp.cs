using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystemForTemp
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

    public static void AttackEnemy(PlayerScript player, Enemy enemy)
    {
        enemy.hp -= (int)(player.atk * CheckElement(player.element, enemy.element));
    }

    public static void AttackPlayer(PlayerScript player, Enemy enemy)
    {
        player.hp -= (int)(enemy.atk * CheckElement(enemy.element, player.element));
    }

    //public static void UpdateStates(PlayerScript player, Enemy enemy)
    //{
    //    if (player.DeadCheck())
    //    {
    //        //GameObject.Destroy(player.gameObject);
    //        Debug.Log("GameOver");
    //    }

    //    if (enemy.DeadCheck())
    //    {
    //        GameObject.Find("EnemyDetailInfo").SetActive(true);
    //        GameObject.Destroy(enemy.gameObject);
    //    }
    //}

    public static void Battle(PlayerScript player, Enemy enemy)
    {
        AttackEnemy(player, enemy);
        AttackPlayer(player, enemy);

        //UpdateStates(player, enemy);
    }
}