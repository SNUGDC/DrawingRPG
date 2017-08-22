using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaDetailPanel : MonoBehaviour {

    public CharaSkillInfo charaInfo;
    public Image skillImage;
    public Text skillName;
    public Text skillLevel;
    public Text skillInfo;

    public Text skillNextLevelText;

    public Button Up;
    public Button Down;

    public void SkillDetail(CharaSkillInfo charaSkillInfo)
    {
        charaInfo = charaSkillInfo;
        skillImage.sprite = charaSkillInfo.skillImage;
        skillLevel.text = charaSkillInfo.skill.skillLevel.ToString();
        skillName.text = charaSkillInfo.skill.skillName;
        skillInfo.text = charaSkillInfo.skill.skillInfo;
    }

    public void SkillLevelUp()
    {
        if (charaInfo.skill.skillLevel == charaInfo.LimitLevel)
        {
            return;
        }
        else
        {
            charaInfo.skill.skillLevel++;
            charaInfo.skill.SkillInfomation();
            SkillDetail(charaInfo);
            PlayerPrefs.SetInt(charaInfo.skillname, charaInfo.skill.skillLevel);
            charaInfo.skillLevelInfo.text = charaInfo.skill.skillLevel + "/" + charaInfo.LimitLevel;
            skillLevel.text = charaInfo.skill.skillLevel.ToString();
        }
    }
    public void SkillLevelDown()
    {
        if (charaInfo.skill.skillLevel == 0)
        {
            return;
        }
        else
        {
            charaInfo.skill.skillLevel--;

            charaInfo.skill.SkillInfomation();
            SkillDetail(charaInfo);
            PlayerPrefs.SetInt(charaInfo.skillname, charaInfo.skill.skillLevel);
            charaInfo.skillLevelInfo.text = charaInfo.skill.skillLevel + "/" + charaInfo.LimitLevel;

            skillLevel.text = charaInfo.skill.skillLevel.ToString();
        }
    }
}
