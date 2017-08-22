using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoAndLevel : MonoBehaviour {

    public string characterName;
    public int level;
    public GameObject characterPanel;
    
    public PlayerInfoAndLevel FindPlayerInfoAndLevel(string charaName)
    {
        PlayerInfoAndLevel[] playerInfo = GameObject.FindObjectsOfType<PlayerInfoAndLevel>();
        PlayerInfoAndLevel newOne = new PlayerInfoAndLevel();
        foreach (PlayerInfoAndLevel playernewInfo in playerInfo)
        {
            playernewInfo.characterPanel.SetActive(false);
            if (playernewInfo.characterName == charaName)
            {
                newOne = playernewInfo;
            }
        }
        newOne.characterPanel.SetActive(true);
        return newOne;
    }
}
