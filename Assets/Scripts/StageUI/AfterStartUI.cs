using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterStartUI : MonoBehaviour {
    
    public GameObject turnDisplayPanel;
    public GameObject movePhasePanel;
    public GameObject battlePhasePanel;
    public GameObject missionClearPanel;
    public GameObject missionFailPanel;

    public GameObject[] players;
   
    public void InstantiateStartPanel()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        Instantiate(turnDisplayPanel, this.transform);
    }
    
    
}
