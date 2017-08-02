using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject lineDisplayPanel;
    public GameObject mission;
    public GameObject startButton;
    public GameObject stopButton;
    public GameObject allPlayerInformationPanel;
    public GameObject allEnemyFieldHPPanel;

    public GameObject turnDisplayPanel;
    public GameObject movePhasePanel;
    public GameObject battlePhasePanel;
    public GameObject missionClearPanel;
    public GameObject missionFailPanel;

    public GameObject[] players;

    IEnumerator ShowMission(float second)
    {
        yield return new WaitForSeconds(second);
        InitiateUI();
    }

    private void InstantiateMission()
    {
        Instantiate(mission, this.transform);
    }

    private void InitiateUI()
    {
        Instantiate(lineDisplayPanel, this.transform);
        Instantiate(startButton, GameObject.Find("Canvas").transform);
        Instantiate(stopButton, GameObject.Find("Canvas").transform);
        Instantiate(allPlayerInformationPanel, GameObject.Find("Canvas").transform);
        Instantiate(allEnemyFieldHPPanel, GameObject.Find("Canvas").transform);
    }

    public void InstantiateStartPanel()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        Instantiate(turnDisplayPanel, this.transform);
    }

    private void Start()
    {
        InstantiateMission();
        StartCoroutine(ShowMission(3.0f));
    }

}
