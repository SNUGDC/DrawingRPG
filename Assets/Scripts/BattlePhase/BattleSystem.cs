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

public class ElementWeakAndStrong
{
    public Element myElement;
    public Element weakerThanMe;
    public Element strongerThanMe;

    public ElementWeakAndStrong(Element myElement, Element weakerThanMe, Element strongerThanMe)
    {
        this.myElement = myElement;
        this.weakerThanMe = weakerThanMe;
        this.strongerThanMe = strongerThanMe;
    }

    public float attackBuff(Element opponent)
    {
        if (opponent == weakerThanMe)
        {
            return 1.2f;
        }
        else if (opponent == strongerThanMe)
        {
            return 0.8f;
        }
        else
        {
            return 1.0f;
        }
    }
}

public static class BattleSystem
{

    public static ElementWeakAndStrong waterStrongAndWeak =
        new ElementWeakAndStrong(myElement: Element.Water, weakerThanMe: Element.Fire, strongerThanMe: Element.Earth);
    public static ElementWeakAndStrong fireStrongAndWeak =
        new ElementWeakAndStrong(myElement: Element.Fire, weakerThanMe: Element.Metal, strongerThanMe: Element.Water);
    public static ElementWeakAndStrong metalStrongAndWeak =
        new ElementWeakAndStrong(myElement: Element.Metal, weakerThanMe: Element.Wood, strongerThanMe: Element.Fire);
    public static ElementWeakAndStrong woodStrongAndWeak =
        new ElementWeakAndStrong(myElement: Element.Wood, weakerThanMe: Element.Earth, strongerThanMe: Element.Metal);
    public static ElementWeakAndStrong earthStrongAndWeak =
        new ElementWeakAndStrong(myElement: Element.Earth, weakerThanMe: Element.Water, strongerThanMe: Element.Wood);

    public static float CheckElement(Element attack, Element opponent)
    {
        if (attack == Element.Water)
        {
            return waterStrongAndWeak.attackBuff(opponent: opponent);
        }
        else if (attack == Element.Fire)
        {
            return fireStrongAndWeak.attackBuff(opponent: opponent);
        }
        else if (attack == Element.Metal)
        {
            return metalStrongAndWeak.attackBuff(opponent: opponent);
        }
        else if (attack == Element.Wood)
        {
            return woodStrongAndWeak.attackBuff(opponent: opponent);
        }
        else if (attack == Element.Earth)
        {
            return earthStrongAndWeak.attackBuff(opponent: opponent);
        }
        else
        {
            Debug.LogError("Invalid element " + attack);
            return 1.0f;
        }
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