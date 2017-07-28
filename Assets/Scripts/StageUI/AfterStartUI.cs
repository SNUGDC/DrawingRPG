using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterStartUI : MonoBehaviour {
    
    public GameObject turnDisplayPanel;
    public GameObject[] players;

    private void InstantiateTurnDisplayPanel()
    {
        Instantiate(turnDisplayPanel, this.transform);
    }

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        InstantiateTurnDisplayPanel();
        
    }
    
}
