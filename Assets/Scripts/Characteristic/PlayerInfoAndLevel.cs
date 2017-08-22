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
        foreach(PlayerInfoAndLevel playernewInfo in playerInfo)
        {
            if (playernewInfo.characterName == charaName)
                return playernewInfo;
        }
        return null;
    }
}
