using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaButtonControl : MonoBehaviour {
    
    public void CharacterChooseButton(int num)
    {
        Characteristic characteristic = GameObject.FindObjectOfType<Characteristic>();
        characteristic.characterNum = num;
        characteristic.portrait.sprite = characteristic.playerList[num].portrait;
        characteristic.characterInfo.text = "플레이어 이름\n" + "HP : " + characteristic.playerList[num].maxHp + "/" + characteristic.playerList[num].hp;
        foreach (GameObject objects in characteristic.characteristicPanelList)
        {
            objects.SetActive(false);
        }
        characteristic.characteristicPanelList[num].SetActive(true);
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
