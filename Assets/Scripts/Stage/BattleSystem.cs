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
    public static float check_Element(Element attack, Element damage)
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

    public static void Battle(Player player, Enemy enemy)
    {
        //List<string> element = new List<string>() { "water", "fire", "gold", "wood", "earth" };
        
        /*int enemyIndex;
        int playerIndex;
        float IncreasedElementalDamage = 1.2f;
        float DecreasedElementalDamage = 0.8f;
        */

        //player 공격phase
        enemy.hp -= (int)(player.atk * check_Element(player.element, enemy.element));
        /*enemyIndex = element.IndexOf(enemy.element);

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
        }*/



        //enemy 사망 check
        
        if (enemy.hp <= 0)
        {
            enemy.enemy_object.SetActive(false);
            enemy.Destroy_hpbar();
            GameObject.Destroy(enemy.gameObject);
            return;
        }

        //enemy 공격phase
        player.hp -= (int)(enemy.atk * check_Element(enemy.element, player.element));
        /*if (enemyIndex + 1 == playerIndex || (enemyIndex == 4 && playerIndex == 0))
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
        }*/
        
        //player 사망 check
        if (player.hp <= 0)
        {
            GameObject.Destroy(player.gameObject);
            Debug.Log("GameOver");
        }
    }
}