using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject lineDisplayPanel;
    private GameObject lineDisplay;
    public GameObject mission;
    public GameObject startButton;
    public GameObject stopButton;
    public GameObject allPlayerInformationPanel;
    public GameObject allEnemyFieldHPPanel;

    public GameObject turnDisplayPanel;

    public FadeOut blockPrefab;
    public FadeOut clearPrefab;
    public FadeOut failPrefab;
    public GameObject nextStagePrefab;
    public GameObject againStagePrefab;

    public int maxLine;
    public int maxTurn;

    public GameObject[] players;

    public static UIManager Instance;

    void Awake()
    {
        Instance = this;
    }

    //Instatniate UI
    IEnumerator ShowMission(float second)
    {
        yield return new WaitForSeconds(second);
        InitiateUI();
    }


    private void InitiateUI()
    {
        lineDisplay = Instantiate(lineDisplayPanel, this.transform);
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

    public void OnStartButtonClick()
    {
        InstantiateStartPanel();
        Destroy(lineDisplay);
        var drawingPhase = FindObjectOfType<DrawingPhase>();
        var playerAndGoalsList = drawingPhase.StopDrawingPhase();
        int maxTurnCount = drawingPhase.totalLineCount;
        FindObjectOfType<BattlePhase>().StartBattlePhase(playerAndGoalsList, maxTurnCount);
    }

    private void InstantiateStartPanel()
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
    public void Cleard()
    {
        FadeOut block = Instantiate(blockPrefab);
        block.StartFadeOut(onEnd: () =>
        {
            FadeOut clear = Instantiate(clearPrefab);
            clear.StartFadeOut(onEnd: () =>
            {
                Instantiate(nextStagePrefab);
            });
        });
    }

    public void GameOver()
    {
        FadeOut block = Instantiate(blockPrefab);
        block.StartFadeOut(onEnd: () =>
        {
            FadeOut fail = Instantiate(failPrefab);
            fail.StartFadeOut(onEnd: () =>
            {
                Instantiate(againStagePrefab);
            });
        });
    }
}
