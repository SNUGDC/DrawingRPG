using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPanelUI : MonoBehaviour {

    public List<PlayerUI> AllPlayers;
    private int playerNum;
    
    private void Start()
    {
        GameObject[] taggingPlayers;
        taggingPlayers = GameObject.FindGameObjectsWithTag("Player");
        playerNum = 0;

        foreach(GameObject player in taggingPlayers)
        {
            PlayerUI.MakePanel(AllPlayers[playerNum], player.GetComponent<Player>());
            playerNum++;
        }
        
        while (playerNum < 4)
        {
            AllPlayers[playerNum].gameObject.SetActive(false);
            playerNum++;
            //AllPlayers.RemoveAt(playerNum);
        }
    }
}
