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

    private void InitiateUI()
    {
        Instantiate(lineDisplayPanel, this.transform);
        GameObject canvas = GameObject.Find("Canvas");
        Instantiate(startButton, canvas.transform);
        Instantiate(stopButton, canvas.transform);
        Instantiate(allPlayerInformationPanel, canvas.transform);
        Instantiate(allEnemyFieldHPPanel, canvas.transform);

    }

    private void InstantiateMission()
    {
        Instantiate(mission, this.transform);
    }

    public void InactiveInitialUI()
    {
        lineDisplayPanel.SetActive(false);
        startButton.SetActive(false);
        stopButton.SetActive(false);
        allPlayerInformationPanel.SetActive(false);
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
