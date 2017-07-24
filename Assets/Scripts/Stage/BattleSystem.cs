using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Element
{
    Water,
    Wood,
    Fire,
    Earth,
    Metal
};

public class BattleSystem
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

    public static void AttackEnemy(Player player, Enemy enemy, Enemy_HP enemy_hp_Bar)
    {
        enemy.hp -= (int)(player.atk * CheckElement(player.element, enemy.element));
        enemy.check_hp();
        enemy_hp_Bar.checkHp(enemy);
    }

    public static void AttackPlayer(Player player, Enemy enemy, HP player_hp_Bar)
    {
        player.hp -= (int)(enemy.atk * CheckElement(enemy.element, player.element));
        player.check_hp(player_hp_Bar);
    }

    public static void UpdateStates(Player player, Enemy enemy)
    {
        if (player.DeadCheck())
        {
            //GameObject.Destroy(player.gameObject);
            Debug.Log("GameOver");
        }

        if (enemy.DeadCheck())
        {
            enemy.Enemy_Information.SetActive(false);
            enemy.Destroy_hpbar();
            GameObject.Destroy(enemy.gameObject);
        }
    }

    public static void Battle(Player player, Enemy enemy, HP player_hp_Bar, Enemy_HP enemy_hp_Bar)
    {
        if (enemy.speed > player.speed)
        {
            AttackPlayer(player, enemy, player_hp_Bar);
            AttackEnemy(player, enemy, enemy_hp_Bar);
        }
        else
        {
            AttackEnemy(player, enemy, enemy_hp_Bar);
            AttackPlayer(player, enemy, player_hp_Bar);
        }

        UpdateStates(player, enemy);
    }
}