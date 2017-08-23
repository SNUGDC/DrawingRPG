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
        PlayerInfoAndLevel[] playerInfo = GameObject.FindObjectsOfType<PlayerInfoAndLevel>();
        foreach(PlayerInfoAndLevel player in playerInfo)
        {
            if (charaInfo.character == player.characterName)
            {
                if (charaInfo.skill.skillLevel != charaInfo.LimitLevel && player.SkillLevelUP())
                {
                    charaInfo.skill.skillLevel++;
                    charaInfo.skill.SkillInfomation();
                    SkillDetail(charaInfo);
                    PlayerPrefs.SetInt(charaInfo.skillname, charaInfo.skill.skillLevel);
                    charaInfo.SetSkillLevelText();
                    skillLevel.text = charaInfo.skill.skillLevel.ToString();
                    return;
                }
            }
        }return;
    }
    public void SkillLevelDown()
    {
        PlayerInfoAndLevel[] playerInfo = GameObject.FindObjectsOfType<PlayerInfoAndLevel>();
        foreach (PlayerInfoAndLevel player in playerInfo)
        {
            if (charaInfo.character == player.characterName)
            {
                if (charaInfo.skill.skillLevel != 0 && player.SkillLevelDown())
                {
                    charaInfo.skill.skillLevel--;
                    charaInfo.skill.SkillInfomation();
                    SkillDetail(charaInfo);
                    PlayerPrefs.SetInt(charaInfo.skillname, charaInfo.skill.skillLevel);
                    charaInfo.SetSkillLevelText();
                    skillLevel.text = charaInfo.skill.skillLevel.ToString();
                    return;
                }
            }
        }
        return;
    }
}
