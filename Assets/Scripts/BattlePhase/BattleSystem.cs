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

public class BattleSystem : MonoBehaviour
{

    BattlePhase battlePhase;
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

    public static float CheckChainCount(GameObject player, GameObject enemy, Dictionary<GameObject, List<Element>> whichElementReachEnemy)
    {
        List<Element> playerElementList;
        if (whichElementReachEnemy.ContainsKey(enemy))
        {
            playerElementList = whichElementReachEnemy[enemy];
        }
        else
        {
            playerElementList = new List<Element>();
        }

        int chainCount = 0;
        Player playerStatus = player.gameObject.GetComponent<Player>();
        Enemy enemyStatus = enemy.gameObject.GetComponent<Enemy>();
        if (playerStatus.element == Element.Water)
        {
            if (playerElementList.Contains(Element.Wood))
            {
                chainCount++;
                if (playerElementList.Contains(Element.Fire))
                {
                    chainCount++;
                    if (playerElementList.Contains(Element.Earth))
                    {
                        chainCount++;
                        if (playerElementList.Contains(Element.Metal))
                        {
                            chainCount++;
                        }
                    }
                }
            }
            if (playerElementList.Contains(Element.Metal))
            {
                chainCount++;
                if (playerElementList.Contains(Element.Earth))
                {
                    chainCount++;
                    if (playerElementList.Contains(Element.Fire))
                    {
                        chainCount++;
                        if (playerElementList.Contains(Element.Wood))
                        {
                            chainCount++;
                        }
                    }
                }
            }
        }

        else if (playerStatus.element == Element.Wood)
        {
            if (playerElementList.Contains(Element.Fire))
            {
                chainCount++;
                if (playerElementList.Contains(Element.Earth))
                {
                    chainCount++;
                    if (playerElementList.Contains(Element.Metal))
                    {
                        chainCount++;
                        if (playerElementList.Contains(Element.Water))
                        {
                            chainCount++;
                        }
                    }
                }
            }
            if (playerElementList.Contains(Element.Water))
            {
                chainCount++;
                if (playerElementList.Contains(Element.Metal))
                {
                    chainCount++;
                    if (playerElementList.Contains(Element.Earth))
                    {
                        chainCount++;
                        if (playerElementList.Contains(Element.Fire))
                        {
                            chainCount++;
                        }
                    }
                }
            }
        }

        else if (playerStatus.element == Element.Fire)
        {
            if (playerElementList.Contains(Element.Earth))
            {
                chainCount++;
                if (playerElementList.Contains(Element.Metal))
                {
                    chainCount++;
                    if (playerElementList.Contains(Element.Water))
                    {
                        chainCount++;
                        if (playerElementList.Contains(Element.Wood))
                        {
                            chainCount++;
                        }
                    }
                }
            }
            if (playerElementList.Contains(Element.Wood))
            {
                chainCount++;
                if (playerElementList.Contains(Element.Water))
                {
                    chainCount++;
                    if (playerElementList.Contains(Element.Metal))
                    {
                        chainCount++;
                        if (playerElementList.Contains(Element.Earth))
                        {
                            chainCount++;
                        }
                    }
                }
            }
        }
        else if (playerStatus.element == Element.Earth)
        {
            if (playerElementList.Contains(Element.Metal))
            {
                chainCount++;
                if (playerElementList.Contains(Element.Water))
                {
                    chainCount++;
                    if (playerElementList.Contains(Element.Wood))
                    {
                        chainCount++;
                        if (playerElementList.Contains(Element.Fire))
                        {
                            chainCount++;
                        }
                    }
                }
            }
            if (playerElementList.Contains(Element.Fire))
            {
                chainCount++;
                if (playerElementList.Contains(Element.Wood))
                {
                    chainCount++;
                    if (playerElementList.Contains(Element.Water))
                    {
                        chainCount++;
                        if (playerElementList.Contains(Element.Metal))
                        {
                            chainCount++;
                        }
                    }
                }
            }
        }
        else if (playerStatus.element == Element.Metal)
        {
            if (playerElementList.Contains(Element.Water))
            {
                chainCount++;
                if (playerElementList.Contains(Element.Wood))
                {
                    chainCount++;
                    if (playerElementList.Contains(Element.Fire))
                    {
                        chainCount++;
                        if (playerElementList.Contains(Element.Earth))
                        {
                            chainCount++;
                        }
                    }
                }
            }
            if (playerElementList.Contains(Element.Earth))
            {
                chainCount++;
                if (playerElementList.Contains(Element.Fire))
                {
                    chainCount++;
                    if (playerElementList.Contains(Element.Wood))
                    {
                        chainCount++;
                        if (playerElementList.Contains(Element.Water))
                        {
                            chainCount++;
                        }
                    }
                }
            }
        }

        if (chainCount > 4)
        {
            chainCount = 4;
        }

        if (chainCount == 0)
        {
            return 1.0f;
        }
        else if (chainCount == 1)
        {
            return 1.5f;
        }
        else if (chainCount == 2)
        {
            return 2.25f;
        }
        else if (chainCount == 3)
        {
            return 3.375f;
        }
        else if (chainCount == 4)
        {
            return 5.0625f;
        }
        else
            return 1.0f;
    }

    public static void AttackEnemy(GameObject player, GameObject enemy, Dictionary<GameObject, List<Element>> whichElementReachEnemy)
    {
        Player playerStatus = player.gameObject.GetComponent<Player>();
        Enemy enemyStatus = enemy.gameObject.GetComponent<Enemy>();
        enemyStatus.hp -= (int)(playerStatus.atk * CheckElement(playerStatus.element, enemyStatus.element) * CheckChainCount(player, enemy, whichElementReachEnemy));
    }

    public static void AttackPlayer(GameObject player, GameObject enemy)
    {
        Player playerStatus = player.gameObject.GetComponent<Player>();
        Enemy enemyStatus = enemy.gameObject.GetComponent<Enemy>();
        playerStatus.hp -= (int)(enemyStatus.atk * CheckElement(enemyStatus.element, playerStatus.element));
    }


    public static bool DestroyDeadPlayer(GameObject player)
    {
        Player playerStatus = player.gameObject.GetComponent<Player>();

        if (playerStatus.hp <= 0)
        {
            GameObject.Destroy(player.gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }


    public static bool DestroyDeadEnemy(GameObject enemy)
    {
        Enemy enemyStatus = enemy.gameObject.GetComponent<Enemy>();

        if (enemyStatus.hp <= 0)
        {
            GameObject.Destroy(enemy.gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }



    public static void Battle(GameObject player, GameObject enemy, Dictionary<GameObject, List<Element>> whichElementReachEnemy)
    {
        AttackEnemy(player, enemy, whichElementReachEnemy);
        bool enemyDie = DestroyDeadEnemy(enemy);

        if (enemyDie != true)
        {
            AttackPlayer(player, enemy);
            DestroyDeadPlayer(player);
        }

    }
}