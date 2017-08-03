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

    public GameObject block;
    public GameObject clear;
    public GameObject fail;
    public GameObject nextStage;
    public GameObject againStage;

    public int maxLine;
    public int maxTurn;

    public GameObject[] players;

    //Instatniate UI
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

    //Game over and clear control
    public static void Cleard()
    {
        GameObject UIManager = GameObject.Find("UIManager");
        FadeOut.particleFadeOut(UIManager.GetComponent<UIManager>().block, 1.0f);
        FadeOut.particleFadeOut(UIManager.GetComponent<UIManager>().clear, 3.0f);
        //player.Next_Stage.SetActive(true);
        UIManager.GetComponent<UIManager>().nextStage.SetActive(true);
    }

    public static void GameOver()
    {
        GameObject UIManager = GameObject.Find("UIManager");
        FadeOut.particleFadeOut(UIManager.GetComponent<UIManager>().block, 1.0f);
        FadeOut.particleFadeOut(UIManager.GetComponent<UIManager>().fail, 3.0f);
        //player.Next_Stage.SetActive(true);
        UIManager.GetComponent<UIManager>().againStage.SetActive(true);
    }


}
