using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaSkillInfo : MonoBehaviour {

    public string skillname;
    public int LimitLevel;
    public Skill skill;
    public Text skillLevelInfo;
    public Sprite skillImage;

    private void Start()
    {
        CheckSkillName();
        skill.SkillInfomation();
        if (PlayerPrefs.HasKey(skill.skillName))
        {
            SetSkill();
        }
        else
            SetNewSkill();

        skillLevelInfo.text = skill.skillLevel + "/" + LimitLevel;
    }
    public void CheckSkillName()
    {
        if (skillname == "TestSkill")
            skill = new TestSkill();
        else if (skillname == "Strike")
            skill = new Strike();
        else if (skillname == "EnhanceWeakpoint")
            skill = new EnhanceWeakpoint();
        else if (skillname == "EnhanceChain")
            skill = new EnhanceChain();
        else if (skillname == "BreakWeakpoint")
            skill = new BreakWeakpoint();
        else if (skillname == "BreakChain")
            skill = new BreakChain();
        else if (skillname == "EnhanceHealth")
            skill = new EnhanceHealth();
        else if (skillname == "ProtectWeakpoint")
            skill = new ProtectWeakpoint();
        else if (skillname == "Weaken")
            skill = new Weaken();
        else if (skillname == "HpAbsorption")
            skill = new HpAbsorption();
        else if (skillname == "HpRecovery")
            skill = new HpRecovery();
        else
            return;
    }

    public void SetNewSkill()
    {
        PlayerPrefs.SetInt(skillname, 0);
    }

    public void SetSkill()
    {
        skill.skillLevel = PlayerPrefs.GetInt(skillname);
    }
}
