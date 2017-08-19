using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaDetailPanel : MonoBehaviour {

    public Image skillImage;
    public Text skillName;
    public Text skillInfo;
    public Text skillDetailInfo;
    public Text skillNextLevelText;

    public Button Up;
    public Button Down;

    public void SkillDetail(CharaSkillInfo charaSkillInfo)
    {
        skillImage.sprite = charaSkillInfo.skillImage;
        skillName.text = charaSkillInfo.skillName;
        skillInfo.text = charaSkillInfo.skillInfo;
    }
}
