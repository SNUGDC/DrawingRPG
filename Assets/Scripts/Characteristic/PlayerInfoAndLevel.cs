using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoAndLevel : MonoBehaviour {

    public string characterName;
    public int remainLevelPoint;
    public int level;
    public GameObject characterPanel;
    public Text characterSkillPoint;

    private void Start()
    {
        remainLevelPoint = PlayerPrefs.GetInt("remainLevel" + characterName);
        level = PlayerPrefs.GetInt("level" + characterName) + 10;
        CharacterSkillPointText();
    }

    public void CharacterSkillPointText()
    {
        characterSkillPoint.text = remainLevelPoint + "/" + level;
    }
    public void ResetSkillPoint()
    {
        remainLevelPoint = 0;
    }
    public bool SkillLevelUP()
    {
        if (remainLevelPoint < level)
        {
            remainLevelPoint++;
            CharacterSkillPointText();
            PlayerPrefs.SetInt("remainLevel" + characterName, remainLevelPoint);
            return true;
        }
        else
            return false;
    }

    public bool SkillLevelDown()
    {
        if (remainLevelPoint != 0)
        {
            remainLevelPoint--;
            CharacterSkillPointText();
            PlayerPrefs.SetInt("remainLevel" + characterName, remainLevelPoint);
            return true;
        }
        else
            return false;
    }
    
    public PlayerInfoAndLevel FindPlayerInfoAndLevel(string charaName)
    {
        PlayerInfoAndLevel[] playerInfo = GameObject.FindObjectsOfType<PlayerInfoAndLevel>();
        PlayerInfoAndLevel newOne = new PlayerInfoAndLevel();
        foreach (PlayerInfoAndLevel playernewInfo in playerInfo)
        {
            playernewInfo.characterPanel.SetActive(false);
            if (playernewInfo.characterName == charaName)
            {
                newOne.level = PlayerPrefs.GetInt("level" + charaName);
                newOne.remainLevelPoint = PlayerPrefs.GetInt("remainLevel" + charaName);
                newOne = playernewInfo;
            }
        }
        newOne.characterPanel.SetActive(true);
        return newOne;
    }
}
