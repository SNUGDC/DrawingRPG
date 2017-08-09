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

    //static이랑 뭐랑 문제난거 같은데 잘 모르겠어서 일단 주석처리 ㅜㅜ
    //public float CheckChainCount(GameObject player, GameObject enemy)
    //{
    //    int chainCount = 0;
    //    Player playerStatus = player.gameObject.GetComponent<Player>();
    //    Enemy enemyStatus = enemy.gameObject.GetComponent<Enemy>();
    //    if (playerStatus.element == Element.Water)
    //    {
    //        if (FindNearPlayerElement(enemy, Element.Wood))
    //        {
    //            chainCount++;
    //            if (FindNearPlayerElement(enemy, Element.Fire))
    //            {
    //                chainCount++;
    //                if (FindNearPlayerElement(enemy, Element.Earth))
    //                {
    //                    chainCount++;
    //                    if (FindNearPlayerElement(enemy, Element.Metal))
    //                    {
    //                        chainCount++;
    //                    }
    //                }
    //            }
    //        }
    //        if (FindNearPlayerElement(enemy, Element.Metal))
    //        {
    //            chainCount++;
    //            if (FindNearPlayerElement(enemy, Element.Earth))
    //            {
    //                chainCount++;
    //                if (FindNearPlayerElement(enemy, Element.Fire))
    //                {
    //                    chainCount++;
    //                    if (FindNearPlayerElement(enemy, Element.Wood))
    //                    {
    //                        chainCount++;
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    else if (playerStatus.element == Element.Wood)
    //    {
    //        if (FindNearPlayerElement(enemy, Element.Fire))
    //        {
    //            chainCount++;
    //            if (FindNearPlayerElement(enemy, Element.Earth))
    //            {
    //                chainCount++;
    //                if (FindNearPlayerElement(enemy, Element.Metal))
    //                {
    //                    chainCount++;
    //                    if (FindNearPlayerElement(enemy, Element.Water))
    //                    {
    //                        chainCount++;
    //                    }
    //                }
    //            }
    //        }
    //        if (FindNearPlayerElement(enemy, Element.Water))
    //        {
    //            chainCount++;
    //            if (FindNearPlayerElement(enemy, Element.Metal))
    //            {
    //                chainCount++;
    //                if (FindNearPlayerElement(enemy, Element.Earth))
    //                {
    //                    chainCount++;
    //                    if (FindNearPlayerElement(enemy, Element.Fire))
    //                    {
    //                        chainCount++;
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    else if (playerStatus.element == Element.Fire)
    //    {
    //        if (FindNearPlayerElement(enemy, Element.Earth))
    //        {
    //            chainCount++;
    //            if (FindNearPlayerElement(enemy, Element.Metal))
    //            {
    //                chainCount++;
    //                if (FindNearPlayerElement(enemy, Element.Water))
    //                {
    //                    chainCount++;
    //                    if (FindNearPlayerElement(enemy, Element.Wood))
    //                    {
    //                        chainCount++;
    //                    }
    //                }
    //            }
    //        }
    //        if (FindNearPlayerElement(enemy, Element.Wood))
    //        {
    //            chainCount++;
    //            if (FindNearPlayerElement(enemy, Element.Water))
    //            {
    //                chainCount++;
    //                if (FindNearPlayerElement(enemy, Element.Metal))
    //                {
    //                    chainCount++;
    //                    if (FindNearPlayerElement(enemy, Element.Earth))
    //                    {
    //                        chainCount++;
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    else if (playerStatus.element == Element.Earth)
    //    {
    //        if (FindNearPlayerElement(enemy, Element.Metal))
    //        {
    //            chainCount++;
    //            if (FindNearPlayerElement(enemy, Element.Water))
    //            {
    //                chainCount++;
    //                if (FindNearPlayerElement(enemy, Element.Wood))
    //                {
    //                    chainCount++;
    //                    if (FindNearPlayerElement(enemy, Element.Fire))
    //                    {
    //                        chainCount++;
    //                    }
    //                }
    //            }
    //        }
    //        if (FindNearPlayerElement(enemy, Element.Fire))
    //        {
    //            chainCount++;
    //            if (FindNearPlayerElement(enemy, Element.Wood))
    //            {
    //                chainCount++;
    //                if (FindNearPlayerElement(enemy, Element.Water))
    //                {
    //                    chainCount++;
    //                    if (FindNearPlayerElement(enemy, Element.Metal))
    //                    {
    //                        chainCount++;
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    else if (playerStatus.element == Element.Metal)
    //    {
    //        if (FindNearPlayerElement(enemy, Element.Water))
    //        {
    //            chainCount++;
    //            if (FindNearPlayerElement(enemy, Element.Wood))
    //            {
    //                chainCount++;
    //                if (FindNearPlayerElement(enemy, Element.Fire))
    //                {
    //                    chainCount++;
    //                    if (FindNearPlayerElement(enemy, Element.Earth))
    //                    {
    //                        chainCount++;
    //                    }
    //                }
    //            }
    //        }
    //        if (FindNearPlayerElement(enemy, Element.Earth))
    //        {
    //            chainCount++;
    //            if (FindNearPlayerElement(enemy, Element.Fire))
    //            {
    //                chainCount++;
    //                if (FindNearPlayerElement(enemy, Element.Wood))
    //                {
    //                    chainCount++;
    //                    if (FindNearPlayerElement(enemy, Element.Water))
    //                    {
    //                        chainCount++;
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    if (chainCount > 4)
    //    {
    //        chainCount = 4;
    //    }

    //    if (chainCount == 0)
    //    {
    //        return 1.0f;
    //    }
    //    else if (chainCount == 1)
    //    {
    //        return 1.5f;
    //    }
    //    else if (chainCount == 2)
    //    {
    //        return 2.25f;
    //    }
    //    else if (chainCount == 3)
    //    {
    //        return 3.375f;
    //    }
    //    else if (chainCount == 4)
    //    {
    //        return 5.0625f;
    //    }
    //    else
    //        return 1.0f;
    //}

    //public bool FindNearPlayerElement(GameObject enemy, Element element)
    //{
    //    List<Element> playerElementList = battlePhase.whoReachEnemy[enemy];
    //    return playerElementList.Contains(element);
    //}
    public static float CheckChainCount(GameObject player, GameObject enemy)
    {
        return 1.0f;
    }
    

    


    public static void AttackEnemy(GameObject player, GameObject enemy)
    {
        Player playerStatus = player.gameObject.GetComponent<Player>();
        Enemy enemyStatus = enemy.gameObject.GetComponent<Enemy>();
        enemyStatus.hp -= (int)(playerStatus.atk * CheckElement(playerStatus.element, enemyStatus.element)*CheckChainCount(player,enemy));
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
    


    public static void Battle(GameObject player, GameObject enemy)
    {
        AttackEnemy(player, enemy);
        bool enemyDie=DestroyDeadEnemy(enemy);

        if(enemyDie != true)
        {
            AttackPlayer(player, enemy);
            DestroyDeadPlayer(player);
        }
    
    }
}