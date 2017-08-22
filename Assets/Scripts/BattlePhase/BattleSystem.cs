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

public class Damage
{
    public float damageWeight = 1.0f;
    public bool damageLoss = false;
    public bool damageAdd = false;
};

public class ChainWeight
{
    public float chainWeight = 1.0f;
    public bool chainActive = true;
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

    public Damage attackBuff(Element opponent)
    {
        Damage damage = new Damage();

        if (opponent == weakerThanMe)
        {
            damage.damageWeight = 1.2f;
            damage.damageAdd = true;
            return damage;
        }
        else if (opponent == strongerThanMe)
        {
            damage.damageWeight = 0.8f;
            damage.damageLoss = true;
            return damage;
        }
        else
        {
            damage.damageWeight = 1.0f;
        }

        return damage;
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

    
    public static Damage CheckElement(Element attack, Element opponent)
    {
        Damage damage = new Damage();
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
            return damage;
        }
    }

    public static ChainWeight CheckChainCount(GameObject player, GameObject enemy, Dictionary<GameObject, List<Element>> whichElementReachEnemy)
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

        ChainWeight chainWeight = new ChainWeight();

        if (chainCount > 4)
        {
            chainCount = 4;
        }

        if (chainCount == 0)
        {
            chainWeight.chainActive = false;
        }
        else if (chainCount == 1)
        {
            chainWeight.chainWeight = 1.5f;
        }
        else if (chainCount == 2)
        {
            chainWeight.chainWeight = 2.25f;
        }
        else if (chainCount == 3)
        {
            chainWeight.chainWeight = 3.375f;
        }
        else if (chainCount == 4)
        {
            chainWeight.chainWeight = 5.0625f;
        }

        return chainWeight;
    }

    public static void AttackEnemy(GameObject player, GameObject enemy, Dictionary<GameObject, List<Element>> whichElementReachEnemy)
    {
        Player playerStatus = player.gameObject.GetComponent<Player>();
        Enemy enemyStatus = enemy.gameObject.GetComponent<Enemy>();
        Damage elementDamage = CheckElement(playerStatus.element, enemyStatus.element);
        float elementWeight = 1.0f;
        ChainWeight chainDamage = CheckChainCount(player, enemy, whichElementReachEnemy);
        float chainWeight = 1.0f;
        Skill skill;

        if (playerStatus.characterName == Player.CharacterName.Roserian) 
        {
            if (elementDamage.damageAdd)
            {
                skill = new EnhanceWeakpoint();
                if (skill.activated)
                    elementWeight = elementDamage.damageWeight + skill.GetWeightedValue();
            }

            else if (elementDamage.damageLoss)
            {
                skill = new BreakWeakpoint();
                if (skill.activated)
                    elementWeight = elementDamage.damageWeight + skill.GetWeightedValue();
            }

            if (chainDamage.chainActive)
            {
                skill = new EnhanceChain();
                if(skill.activated)
                chainWeight = chainDamage.chainWeight + skill.GetWeightedValue();
            }

            else if(!chainDamage.chainActive)
            {
                skill = new BreakChain();
                if (skill.activated)
                    chainWeight = chainDamage.chainWeight + skill.GetWeightedValue();
            }
        }

        if (playerStatus.characterName == Player.CharacterName.Hesmen)
        {
            if(chainDamage.chainActive)
            {
                skill = new Weaken();
                if (skill.activated)
                    skill.Use(enemyStatus);
            }

            skill = new HpAbsorption();
            if (skill.activated)
                skill.Use(playerStatus);
        }

        enemyStatus.hp -= (int)(playerStatus.atk * elementWeight * chainWeight);
    }

    public static void AttackPlayer(GameObject player, GameObject enemy)
    {
        Player playerStatus = player.gameObject.GetComponent<Player>();
        Enemy enemyStatus = enemy.gameObject.GetComponent<Enemy>();
        Damage elementDamage = CheckElement(playerStatus.element, enemyStatus.element);
        float elementWeight = 1.0f;
        Skill skill;

        if (playerStatus.characterName == Player.CharacterName.Hesmen)
        {
            if (elementDamage.damageAdd)
            {
                skill = new ProtectWeakpoint();
                if (skill.activated)
                    elementWeight = elementDamage.damageWeight - skill.GetWeightedValue();
            }
        } 

        playerStatus.hp -= (int)(enemyStatus.atk * elementWeight);
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

    public static bool DestroyDeadEnemy(GameObject enemy, Dictionary<GameObject, List<GameObject>> whichPlayerReachEnemy)
    {
        Enemy enemyStatus = enemy.gameObject.GetComponent<Enemy>();

        if (enemyStatus.hp <= 0)
        {
            ExperiencePoint.passExperiencePoint(enemy, whichPlayerReachEnemy);
            GameObject.Destroy(enemy.gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void Battle(GameObject player, GameObject enemy, Dictionary<GameObject, List<Element>> whichElementReachEnemy,
        Dictionary<GameObject, List<GameObject>> whichPlayerReachEnemy)
    {
        AttackEnemy(player, enemy, whichElementReachEnemy);
        bool enemyDie = DestroyDeadEnemy(enemy,whichPlayerReachEnemy);

        if (enemyDie != true)
        {
            AttackPlayer(player, enemy);
            DestroyDeadPlayer(player);
        }

    }
}