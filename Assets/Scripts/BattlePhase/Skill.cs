using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    private List<Skill> nextSkills;
    public int skillLevel = 1;
    public bool activated = true;

    public abstract void Use(Player player);

    public float GetWeightedValue() { return 0.2f*skillLevel; }

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
        player.atk = player.atk * (1 + 0.1f * skillLevel);
    }

    public override void SkillLevelUp(Player player)
    {
        skillLevel++;
        Use(player);
    }
}

public class EnhanceWeakpoint : Skill
{
    public bool activated = false;

    public override void Use(Player player) { }

    public override void SkillLevelUp(Player player)
    {
        skillLevel++;
        Use(player);
    }
}

public class BreakWeakpoint : Skill
{
    public bool activated = false;

    public override void Use(Player player) { }

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
        player.hp = player.hp * (1 + 0.2f * skillLevel);
    }

    public override void SkillLevelUp(Player player)
    {
        skillLevel++;
        Use(player);
    }
}