using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    private List<Skill> nextSkills;

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