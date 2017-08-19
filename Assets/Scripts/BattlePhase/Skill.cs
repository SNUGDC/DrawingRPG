using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    private List<Skill> nextSkills;
    public int skillLevel = 1;
    public bool activated = true;

    public abstract void Use(Player player);
    public virtual void Use(Enemy enemy) { }

    public virtual float GetWeightedValue() { return 0.2f*skillLevel; }

    public abstract void SkillLevelUp(Player player);

    public Skill()
    {
        nextSkills = new List<Skill>();
    }

    public void addNextSkill(Skill skill)
    {
        nextSkills.Add(skill);
    }
}

public class Strike : Skill
{
    public override void Use(Player player)
    {
        player.atk = player.atk + 0.1f * skillLevel;
    }

    public override void SkillLevelUp(Player player)
    {
        skillLevel++;
        Use(player);
    }
}

public class EnhanceWeakpoint : Skill
{
    public new bool activated = false;

    public override void Use(Player player) { }

    public override void SkillLevelUp(Player player)
    {
        skillLevel++;
        Use(player);
    }
}

public class EnhanceChain : Skill
{
    public new bool activated = false;

    public override void Use(Player player) { }

    public override float GetWeightedValue()
    {
        return 0.1f * skillLevel;
    }

    public override void SkillLevelUp(Player player)
    {
        skillLevel++;
        Use(player);
    }
}

public class BreakWeakpoint : Skill
{
    public new bool activated = false;

    public override void Use(Player player) { }

    public override void SkillLevelUp(Player player)
    {
        skillLevel++;
        Use(player);
    }
}

public class BreakChain : Skill
{
    public new bool activated = false;

    public override void Use(Player player) { }

    public override float GetWeightedValue()
    {
        return 0.3f * skillLevel;
    }

    public override void SkillLevelUp(Player player)
    {
        skillLevel++;
        Use(player);
    }
}


public class EnhanceHealth : Skill
{
    public override void Use(Player player)
    {
        player.maxHp = player.maxHp + 0.2f * skillLevel;
    }

    public override void SkillLevelUp(Player player)
    {
        skillLevel++;
        Use(player);
    }
}

public class ProtectWeakpoint : Skill
{
    public new bool activated = false;

    public override void Use(Player player) { }

    public override float GetWeightedValue()
    {
        return 0.1f * skillLevel;
    }

    public override void SkillLevelUp(Player player)
    {
        skillLevel++;
        Use(player);
    }
}

public class Weaken : Skill
{
    public new bool activated = false;

    public override void Use(Player player) { }

    public override void Use(Enemy enemy)
    {
        enemy.atk = enemy.atk - 0.05f * skillLevel;
    }

    public override void SkillLevelUp(Player player)
    {
        skillLevel++;
        Use(player);
    }
}


public class HpAbsorption : Skill
{
    public new bool activated = false;

    public override void Use(Player player)
    {
        player.hp = player.hp + 0.2f * skillLevel;
    }

    public override void SkillLevelUp(Player player)
    {
        skillLevel++;
        Use(player);
    }
}

public class HpRecovery : Skill
{
    public new bool activated = false;

    public override void Use(Player player)
    {
        player.hp = player.hp + 0.03f * skillLevel;
    }

    public override void SkillLevelUp(Player player)
    {
        skillLevel++;
        Use(player);
    }
}
