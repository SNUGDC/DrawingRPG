using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Characteristic : MonoBehaviour {

    public Image portrait;
    public Text characterInfo;
    public List<Player> playerList;
    public List<GameObject> characteristicPanelList;
    public int characterNum;
    
    public void CharacterInfoText(Player player)
    {
        characterInfo.text = "플레이어 이름\n" + "HP : " + player.maxHp + "/" + player.hp;
    }
    public void CharacterChooseButton(int num)
    {
        characterNum = num;
        portrait.sprite = playerList[num].portrait;
        CharacterInfoText(playerList[num]);
        foreach(GameObject objects in characteristicPanelList)
        {
            objects.SetActive(false);
        }
        characteristicPanelList[num].SetActive(true);
    }
    public void OpenDetailCharacteristicInfo()
    {
        GameObject DetailPanel = characteristicPanelList[characterNum].transform.Find("DetailPanel").gameObject;
        DetailPanel.SetActive(true);
    }

    public void UpCharacterHP()
    {
        Player player = playerList[characterNum];
        player.maxHp++;
    }
    public void DownCharacterHP()
    {
        Player player = playerList[characterNum];
        player.maxHp--;
    }
    
    public void CloseDetailCharacteristicInfo()
    {
        GameObject DetailPanel = characteristicPanelList[characterNum].transform.Find("DetailPanel").gameObject;
        DetailPanel.SetActive(false);
    }
}
