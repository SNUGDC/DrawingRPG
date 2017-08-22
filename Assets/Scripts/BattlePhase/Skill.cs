using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    private List<Skill> nextSkills;
    public int skillLevel = 0;
    public bool activated = true;
    public string skillName;
    public string skillInfo;

    public abstract void Use(Player player);
    public virtual void Use(Enemy enemy) { }

    public virtual float GetWeightedValue() { return 0.2f*skillLevel; }

    public abstract void SkillLevelUp(Player player);

    public virtual void SkillInfomation() { }
    public Skill()
    {
        nextSkills = new List<Skill>();
    }
    

    public void addNextSkill(Skill skill)
    {
        nextSkills.Add(skill);
    }
}

public class TestSkill : Skill
{
    public override void SkillInfomation()
    {
        skillName = "테스트";
        skillInfo = "스킬을 테스트한닼";
    }
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

//Roserian
public class Strike : Skill
{
    public override void SkillInfomation()
    {
        skillName = "일격";
        skillInfo = "공격력이" + 10 * skillLevel + "% 증가한다.";
    }
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
    public override void SkillInfomation()
    {
        skillName = "약점강화";
        skillInfo = "약점 공격 시 데미지가 "+(120 + 20*skillLevel)+"%로 변경된다.";
    }
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
    public override void SkillInfomation()
    {
        skillName = "결속";
        skillInfo = "체인 공격 시 체인의 데미지가 "+ (150 + 10*skillLevel)+"%로 변경된다.";
    }
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
    public override void SkillInfomation()
    {
        skillName = "돌파";
        skillInfo = "강점 공격 시 데미지가 " + (80 + 20*skillLevel)+"%로 변경된다.";
    }
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
    public override void SkillInfomation()
    {
        skillName = "???";
        skillInfo = "체인이 걸리지 않을 경우 "+ skillLevel * 30+"%만큼 데미지가 증가된다.";
    }
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

//Hesmen
public class EnhanceHealth : Skill
{
    public override void SkillInfomation()
    {
        skillName = "강화";
        skillInfo = "체력이 "+skillLevel * 20+"%만큼 증가한다.";
    }
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
    public override void SkillInfomation()
    {
        skillName = "약점 보호";
        skillInfo = "약점 피격 시 데미지가 " + skillLevel * 10+"%만큼 감소한다.";
    }
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
    public override void SkillInfomation()
    {
        skillName = "약화";
        skillInfo = "체인 공격 시 적의 공격력을 "+ skillLevel*5+"%만큼 영구히 감소한다.";
    }
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
    public override void SkillInfomation()
    {
        skillName = "흡수";
        skillInfo = "공격 시 가한 데미지의 "+skillLevel*20 + "%만큼 체력을 회복한다.";
    }
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
    public override void SkillInfomation()
    {
        skillName = "휴식";
        skillInfo = "매 이동 페이즈 시작 시 " + skillLevel*3+"%만큼  체력을 회복한다.";
    }
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
