using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    private List<Skill> nextSkills;
    public int skillLevel;

    public abstract void Use(Player player);

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

    }
}