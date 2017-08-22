using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaButtonControl : MonoBehaviour {
    
    public void CharacterChooseButton(string charaName)
    {
        PlayerInfoAndLevel playerInfo = new PlayerInfoAndLevel();
        playerInfo = playerInfo.FindPlayerInfoAndLevel(charaName);
        CharacterInfo characterInfo = GameObject.FindObjectOfType<CharacterInfo>();
        characterInfo.CharacterInfomation(playerInfo);
    }
    
    public void OpenDetailCharacteristicInfo(CharaSkillInfo charaSkillInfo)
    {
        GameObject DetailPanel = GameObject.Find("Canvas").transform.Find("DetailPanel").gameObject;
        DetailPanel.SetActive(true);
        DetailPanel.GetComponent<CharaDetailPanel>().SkillDetail(charaSkillInfo);
    }

    public void CloseDetailCharacteristicInfo()
    {
        GameObject DetailPanel = GameObject.Find("Canvas").transform.Find("DetailPanel").gameObject;
        DetailPanel.SetActive(false);
    }
    
}
