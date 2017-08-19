using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaSkillInfo : MonoBehaviour {

    private Skill skill;
    public string skillName;
    public string skillInfo;
    public Sprite skillImage;

    private void Start()
    {
        skill = new TestSkill("일격", "일격으로 친다");
        skillName = skill.skillName;
        skillInfo = skill.skillInfo;
    }
}
