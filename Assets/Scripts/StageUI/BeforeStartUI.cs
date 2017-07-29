using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeStartUI : MonoBehaviour {
    
    public GameObject lineDisplayPanel;
    public GameObject mission;
    public GameObject startButton;
    public GameObject stopButton;
    public GameObject allPlayerInformationPanel;
    public GameObject allEnemyFieldHPPanel;
    

    IEnumerator ShowMission(float second)
    {
        yield return new WaitForSeconds(second);
        InstantiateLineDisplayPanel();
        InstantiateStartButton();
        InstantiateStopButton();
        InstantiateAllPlayerInfoPanel();
        InstantiateAllEnemyFieldHPPanel();
    }
    
    private void InstantiateMission()
    {
        Instantiate(mission, this.transform);
    }
    private void InstantiateLineDisplayPanel()
    {
        Instantiate(lineDisplayPanel, this.transform);
    }
    private void InstantiateStartButton()
    {
        Instantiate(startButton, GameObject.Find("Canvas").transform);
    }
    private void InstantiateStopButton()
    {
        Instantiate(stopButton, GameObject.Find("Canvas").transform);
    }
    private void InstantiateAllPlayerInfoPanel()
    {
        Instantiate(allPlayerInformationPanel, GameObject.Find("Canvas").transform);
    }
    private void InstantiateAllEnemyFieldHPPanel()
    {
        Instantiate(allEnemyFieldHPPanel, GameObject.Find("Canvas").transform);
    }

    private void Start()
    {
        InstantiateMission();
        StartCoroutine(ShowMission(3.0f));
    }
    
}
